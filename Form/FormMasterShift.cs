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
using System.Globalization;
using OverTime.DataBase;

namespace OverTime
{
    public partial class FormMasterShift : Form
    {
        List<Tbl_MasterShift> lstShiftExcel = new List<Tbl_MasterShift>();
        public FormMasterShift()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDlg = new OpenFileDialog();
            FileDlg.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            FileDlg.RestoreDirectory = true;
            if (FileDlg.ShowDialog() == DialogResult.OK)
            {
                lbLink.Text = FileDlg.FileName.ToString();
                Common.RunProcess("LoadTitle.exe");
                lstShiftExcel = GetMasterShiftFromExcel(FileDlg.FileName);
                Common.KillProcess("LoadTitle");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lstShiftExcel;
                dataGridView1.Refresh();
            }
        }

        private List<Tbl_MasterShift> GetMasterShiftFromExcel(string PathFile)
        {
            List<Tbl_MasterShift> lstresult = new List<Tbl_MasterShift>();

            FileStream fs = new FileStream(PathFile, FileMode.Open);
            XSSFWorkbook wb = new XSSFWorkbook(fs);
            ISheet sheet = wb.GetSheetAt(0);
            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                var result = new Tbl_MasterShift();
                var nowRow = sheet.GetRow(i);
                if (nowRow.GetCell(3) != null)
                {
                    //result.Code = nowRow.GetCell(1).StringCellValue.ToString().Trim();
                    result.ShiftCode = nowRow.GetCell(1).StringCellValue.ToString().TrimStart('0');

                    string TimeIn = nowRow.GetCell(2).StringCellValue.ToString();
                    string[] IN = TimeIn.Split(':');
                    string Hin = IN[0];
                    string Min = IN[1];
                    int numHin = Convert.ToInt16(Hin);
                    int numMin = Convert.ToInt16(Min);
                    if(TimeIn.Contains("PM"))
                    {
                        result.Shift = "NIGHT";
                        numHin += 12;
                    }
                    else { result.Shift = "DAY"; }
                    TimeIn = string.Format("{0}:{1}", numHin, numMin);
                    result.TimeIn = TimeSpan.Parse(TimeIn);

                    string TimeOut = nowRow.GetCell(3).StringCellValue.ToString();
                    string[] OUT = TimeOut.Split(':');
                    string Hout = OUT[0];
                    string Mout = OUT[1];
                    int numHout = Convert.ToInt16(Hout);
                    int numMout = Convert.ToInt16(Mout);
                    if (TimeOut.Contains("PM"))
                    { numHout += 12; }
                    TimeOut = string.Format("{0}:{1}", numHout, numMout);
                    result.TimeOut = TimeSpan.Parse(TimeOut);
                    

                    result.WorkMinutes = Convert.ToInt16(nowRow.GetCell(4).NumericCellValue.ToString());

                    string TimeOT = nowRow.GetCell(5).StringCellValue.ToString();
                    string[] OT = TimeOT.Split(':');
                    string HOT = OT[0];
                    string MOT = OT[1];
                    int numHOT = Convert.ToInt16(HOT);
                    int numMOT = Convert.ToInt16(MOT);
                    if(TimeOT.Contains("PM")) { numHOT += 12; }
                    TimeOT = string.Format("{0}:{1}", numHOT, numMOT);
                    result.ApplyOverTime = TimeSpan.Parse(TimeOT);

                    lstresult.Add(result);
                }
            }

            return lstresult; 
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            using (var db = new DBContext())
            {
                if(lstShiftExcel.Count > 0)
                {
                    db.Tbl_MasterShift.AddRange(lstShiftExcel);
                    db.SaveChanges();
                    MessageBox.Show("Save Success","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
