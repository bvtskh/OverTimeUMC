using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OverTime.DataBase;
using Spire.Xls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OverTime.Business
{
    internal class FingerPrintsHelper
    {
        internal bool ExportFingerPrint(DataTable datatable)
        {
            try
            {
                // Create a new workbook
                Workbook workbook = new Workbook();
                Worksheet sheet = workbook.Worksheets[0];

                // Write the DataTable content to the Excel file
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    sheet.Range[1, i + 1].Text = datatable.Columns[i].ColumnName;
                    sheet.Range[1, i + 1].Style.Color = System.Drawing.Color.FromArgb(64, 64, 64); // Set header row color
                    sheet.Range[1, i + 1].Style.Font.Color = System.Drawing.Color.White; // Set header font color to white
                }

                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    for (int j = 0; j < datatable.Columns.Count; j++)
                    {
                        sheet.Range[i + 2, j + 1].Text = datatable.Rows[i][j].ToString();
                    }
                }
                // Auto-fit columns
                sheet.AllocatedRange.AutoFitColumns();
                // Save the Excel file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveToFile(saveFileDialog.FileName);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable GetDataForgetPrintList(string dept, DateTime selectDateFrom, DateTime selectDateTo, string typeUser, string[] arrDept)
        {
            using(var context = new DBContext())
            {
                var data = context.Tbl_DailyOverTime.Where( w => w.DateOverTime >= selectDateFrom && w.DateOverTime <= selectDateTo &&
                w.TimeIn !=null && w.TimeOut !=null && ((w.TimeIn == TimeSpan.Zero && w.TimeOut !=TimeSpan.Zero) ||(w.TimeIn != TimeSpan.Zero && w.TimeOut == TimeSpan.Zero))).ToList();
                return ConvertDataTable(data, dept, typeUser, arrDept);
            }
        }

        internal bool IsHaveFinger(DateTime selectDate)
        {
            using(var context = new DBContext())
            {
                return context.Tbl_DailyOverTime.Where(w => w.DateOverTime == selectDate && w.TimeIn != null).Count() > 0;
            }
        }

        private DataTable ConvertDataTable(List<Tbl_DailyOverTime> data, string dept, string typeUser, string[] arrDept)
        {
            // Create a new DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Ngày Quên", typeof(string));
            dataTable.Columns.Add("Mã Số", typeof(string)); 
            dataTable.Columns.Add("Họ và Tên", typeof(string));
            dataTable.Columns.Add("Bộ Phận", typeof(string));
            dataTable.Columns.Add("Khách Hàng", typeof(string));
//dataTable.Columns.Add("Ca làm việc", typeof(string));
            dataTable.Columns.Add("Giờ Vào", typeof(string));
            dataTable.Columns.Add("Giờ Về", typeof(string));
            dataTable.Columns.Add("Số Lần", typeof(int));
            dataTable.Columns.Add("Lý do", typeof(string));

            foreach (var item in data)
            {
                string deptNew = GAMankuchiAll.Instance()._listAllStaff.Where(w => w.AltCode == item.Code).Select(s => s.Dept).FirstOrDefault();
                string reason = GetStatus(item.TimeIn);
                string customer = GAMankuchiAll.Instance()._listAllStaff.Where(w => w.AltCode == item.Code).Select(s => s.Customer).FirstOrDefault();
                int times = data.Count(c => c.Code == item.Code);
                if (dept == "ALL" && typeUser == "Salary")
                {
                    dataTable.Rows.Add(item.DateOverTime.ToString("dd-MM-yyyy"), item.Code, item.FullName, deptNew, customer,/*item.CaLV,*/item.TimeIn, item.TimeOut, times, reason);
                }
                else if (dept == "ALL" && typeUser != "Salary")
                {
                    if (!arrDept.Contains(deptNew)) continue;
                    dataTable.Rows.Add(item.DateOverTime.ToString("dd-MM-yyyy"), item.Code, item.FullName, deptNew, customer, /*item.CaLV,*/item.TimeIn, item.TimeOut, times, reason);
                }
                else
                {
                    if (deptNew != dept) continue;
                    dataTable.Rows.Add(item.DateOverTime.ToString("dd-MM-yyyy"), item.Code, item.FullName, deptNew, customer, /*item.CaLV,*/ item.TimeIn, item.TimeOut, times, reason);
                }
            }
            return dataTable;
        }

        private string GetStatus(TimeSpan? timeIn)
        {
            return timeIn == TimeSpan.Zero ? "Quên giờ vào" : "Quên giờ về";
        }
    }
}
