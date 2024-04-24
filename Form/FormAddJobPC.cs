using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.IO;

namespace OverTime
{
    public partial class FormAddJobPC : Form
    {
        public List<JobPD> lstJobExcel = new List<JobPD>();
        //public List<Tbl_HumanInfo> lstHumanInfo = new List<Tbl_HumanInfo>();
        //public List<Tbl_HumanInfo> lstHumanUpdate = new List<Tbl_HumanInfo>();
        public FormAddJobPC()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDlg = new OpenFileDialog();
            FileDlg.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            FileDlg.RestoreDirectory = true;
            if (FileDlg.ShowDialog() == DialogResult.OK)
            {
                Common.RunProcess("LoadTitle.exe");
                lstJobExcel = GetJobPDFromExcel(FileDlg.FileName);
                Common.KillProcess("LoadTitle");
                dgvProcess.DataSource = null;
                dgvProcess.DataSource = lstJobExcel;
                dgvProcess.Refresh();
                string mes = string.Format("Tổng số người đọc từ file excel:{0}", lstJobExcel.Count);
                MessageBox.Show(mes, "Thông Báo", MessageBoxButtons.OK);
            }
        }

        public List<JobPD> GetJobPDFromExcel(string PathFile)
        {
            List<JobPD> lstResult = new List<JobPD>();


            FileStream fs = new FileStream(PathFile, FileMode.Open);
            XSSFWorkbook wb = new XSSFWorkbook(fs);
            ISheet sheet = wb.GetSheetAt(0);
            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                var result = new JobPD();
                var nowRow = sheet.GetRow(i);
                if (nowRow.GetCell(3) != null)
                {
                    //result.Code = nowRow.GetCell(1).StringCellValue.ToString().Trim();

                    try { result.Code = nowRow.GetCell(3).StringCellValue.ToString(); }
                    catch { result.Code = nowRow.GetCell(3).NumericCellValue.ToString(); }

                    if (string.IsNullOrEmpty(result.Code))
                    {
                        break;
                    }
                    else
                    {
                        result.Name = (nowRow.GetCell(4) != null) ? nowRow.GetCell(4).StringCellValue : "";
                        result.Dept = (nowRow.GetCell(5) != null) ? nowRow.GetCell(5).StringCellValue : "";
                        //result.GroupProcess = (nowRow.GetCell(11) != null) ? nowRow.GetCell(11).StringCellValue : "";
                        try { result.CustomerPD = (nowRow.GetCell(6) != null) ? nowRow.GetCell(6).StringCellValue : ""; }
                        catch { result.CustomerPD = (nowRow.GetCell(6) != null) ? nowRow.GetCell(6).NumericCellValue.ToString() : ""; }

                        try { result.GroupProcess = (nowRow.GetCell(7) != null) ? nowRow.GetCell(7).StringCellValue : ""; }
                        catch { result.GroupProcess = (nowRow.GetCell(7) != null) ? nowRow.GetCell(7).NumericCellValue.ToString() : ""; }

                        if (!result.Code.Contains("UJ"))
                        {
                            lstResult.Add(result);
                        }
                    }
                }
            }
            return lstResult;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Common.RunProcess("LoadTitle.exe");
            //int totalFind = 0;
            //using (var db = new ContextMaster())
            //{
            //    foreach (var item in lstJobExcel)
            //    {
            //        var findItem = db.Tbl_HumanInfo.FirstOrDefault(x => x.AltCode == item.Code);
            //        if (findItem != null)
            //        {
            //            findItem.CustomerPD = item.CustomerPD;
            //            findItem.Line = item.GroupProcess;
            //            db.Entry<Tbl_HumanInfo>(findItem).State = System.Data.Entity.EntityState.Modified;
            //            totalFind++;
            //        }
            //    }
            //    db.SaveChanges();
            //    Common.KillProcess("LoadTitle");
            //    string mes = string.Format("Total Update Success: {0}", totalFind);
            //    //MessageBox.Show("Update Success", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    MessageBox.Show(mes, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
    }

    public class JobPD
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string CustomerPD { get; set; }
        public string GroupProcess { get; set; }
    }
}
