using CommonProject.Entities;
using NPOI.SS.Formula.Functions;
using NPOI.Util;
using Org.BouncyCastle.Utilities;
using OverTime.DataBase;
using PI_Lib.Entities;
using Spire.Xls;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime.Business
{
    public static class StatisticOvertimeHelper
    {
        internal static DataTable GetDataOverTime(DataTable table, string dept, string typeUser, string[] arrayDept, DateTime date)
        {
            try
            {
                var humanInfo = GAMankuchiAll.Instance()._listAllStaff;
                if (typeUser == "Salary" && dept == "ALL")
                {
                    var deptList = humanInfo.Select(s => s.Dept).Distinct().ToList();
                    GetOverTimeDataRow(humanInfo, table, date, deptList);
                }
                else if (dept == "ALL" && typeUser != "Salary")
                {
                    List<Tbl_Mankichi_Entity> mankichiList = new List<Tbl_Mankichi_Entity>();
                    foreach (var subDept in arrayDept)
                    {
                        mankichiList.AddRange(humanInfo.Where(s => s.Dept == subDept).ToList());
                    }
                    GetOverTimeDataRow(mankichiList, table, date, arrayDept.ToList());
                }
                else
                {
                    var listUserOfDept = humanInfo.Where(w => w.Dept == dept).ToList();
                    GetOverTimeDataRow(listUserOfDept, table, date, new List<string> { dept });
                }

                return table;
            }
            catch (Exception)
            {
                throw;
            }          
        }

        private static void GetOverTimeDataRow(List<Tbl_Mankichi_Entity> listUserOfDept, DataTable dataMaster, DateTime date, List<string> deptList)
        {
            DataTable table = new DataTable();
            table.Columns.Add("StaffCode");
            table.Columns.Add("FullName");
            table.Columns.Add("Dept");
            table.Columns.Add("Customer");
            table.Columns.Add("Job");

            foreach (var item in listUserOfDept)
            {
                table.Rows.Add(item.AltCode,item.Name,item.Dept,item.Customer,item.Direct_Indirect);
            }
            try
            {
                SQLHelper.ConnectString(new OvertimeConfig());
                using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRINGS))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand object for your stored procedure
                    using (SqlCommand command = new SqlCommand("GetStatisticOverTime", connection))
                    {
                        // Specify that the command is a stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter parameter = command.Parameters.AddWithValue("@Data", table);
                        parameter.SqlDbType = SqlDbType.Structured;
                        parameter.TypeName = "[dbo].[udt_HumanInfo]";

                        // Execute the command (you can use ExecuteNonQuery, ExecuteScalar, ExecuteReader based on your requirement)
                        //command.ExecuteNonQuery();
                        // Create a DataTable to store the results
                        DataTable dataTable = new DataTable();

                        // Create a SqlDataAdapter to fill the DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Fill the DataTable with the results of the stored procedure
                            adapter.Fill(dataTable);
                        }
                        if (dataTable.Rows.Count > 0)
                        {                           
                            int numberDayInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                            for (int day = 1; day <= numberDayInMonth; day++)
                            {
                                string TotalForecastOfday = GetTotalForecastOT(day, deptList);
                                string TotalOTOfDay = GetTotalOtByDay(dataTable, 17 + day);
                                string balanceOT = GetBalanceOT(TotalForecastOfday, TotalOTOfDay);
                                dataMaster.Rows[0][6 + date.Month + day] = TotalForecastOfday;
                                dataMaster.Rows[1][6 + date.Month + day] = TotalOTOfDay;
                                dataMaster.Rows[2][6 + date.Month + day] = balanceOT;
                            }
                            int number = 1;
                            foreach(DataRow row in dataTable.Rows)
                            {
                                DataRow dataRow = dataMaster.NewRow();
                                dataRow[0] = number;
                                dataRow[1] = row[0];
                                dataRow[2] = row[1];
                                dataRow[3] = row[2];
                                dataRow[4] = row[3];
                                dataRow[5] = row[4];
                                dataRow[6] = row[5];
                                for(int month =1; month<=date.Month; month++)
                                {
                                    dataRow[6+month] = row[5+month];
                                }
                                for(int day =1; day<=date.Day; day++)
                                {
                                    dataRow[6+date.Month+day] = row[17+day];                                   
                                }
                                
                                number++;
                                dataMaster.Rows.Add(dataRow);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi!"+ex.Message);
            }
        }

        private static string GetBalanceOT(string totalForecastOfday, string totalOTOfDay)
        {
            try
            {
                if (!string.IsNullOrEmpty(totalForecastOfday) && !string.IsNullOrEmpty(totalOTOfDay))
                {
                    var balance = double.Parse(totalForecastOfday) - double.Parse(totalOTOfDay);
                    return balance.ToString();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetTotalForecastOT(int columnDay, List<string> deptList)
        {
            try
            {
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, columnDay);
                using (var context = new DBContext())
                {
                    double totalForeCast = 0;
                    foreach (var dept in deptList)
                    {
                        var foreCastData = context.Tbl_ForecastOT.Where(w => w.DEPT == dept && w.DAY == date).FirstOrDefault();
                        if (foreCastData == null) return null;
                        double? forecast = context.Tbl_ForecastOT.Where(w => w.DEPT == dept && w.DAY == date && w.TIME_OT != null && !string.IsNullOrEmpty(w.TIME_OT.ToString())).Sum(s => s.TIME_OT);
                        if (forecast != null && forecast != 0)
                        {
                            totalForeCast += (double)forecast;
                        }
                    }
                    return totalForeCast.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetTotalOtByDay(DataTable dataTable, int columnDay)
        {
            try
            {
                double result;
                var total = dataTable.AsEnumerable().Where(w => w[columnDay] != null && !string.IsNullOrEmpty(w[columnDay].ToString()) && double.TryParse(w[columnDay].ToString(), out result) == true).Sum(s => double.Parse(s[columnDay].ToString()));
                return total == 0f ? null : total.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static bool ExportData(DataGridView dgv, string dept)
        {
            try
            {
                // Create a SaveFileDialog instance
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                // Set the file filter and initial directory
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Title = "Save Over Time Data";
                saveFileDialog.FileName = $"OverTime_{DateTime.Now.ToString("ddMMyyyy hhmmss")}";

                // Show the save file dialog
                DialogResult result = saveFileDialog.ShowDialog();

                // If the user clicked OK, save the workbook
                if (result == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    Workbook workbook = new Workbook();

                    // Add a worksheet
                    Worksheet sheet = workbook.Worksheets[0];

                    int lastColumnIndex = dgv.ColumnCount;


                    // tittle row
                    string lastColumnName = GetExcelColumnName(lastColumnIndex);
                    var tittle = sheet.Range["A1:" + lastColumnName + "1"];

                    // set style
                    SetStyleRange(tittle, "ĐĂNG KÝ TĂNG CA HÀNG THÁNG", 20, true, true, 30);

                    // set department
                    var department = sheet.Range["A2:B2"];
                    SetStyleRange(department, dept, 12, true, true, 26);
                    SetBorder(department, false, true);

                    // Set datetime
                    var month = sheet.Range["A3"];
                    var year = sheet.Range["B3"];

                    SetStyleRange(month, "Tháng", 10, true, false, 26);
                    SetStyleRange(year, "Năm", 10, true, false, 26);
                    SetBorder(month, false, true);
                    SetBorder(year, false, true);

                    var monthValue = sheet.Range["A4"];
                    var yearValue = sheet.Range["B4"];

                    SetStyleRange(monthValue, DateTime.Now.Month.ToString(), 10, true, false, 26);
                    SetStyleRange(yearValue, DateTime.Now.Year.ToString(), 10, true, false, 26);
                    SetBorder(monthValue, false, true);
                    SetBorder(yearValue, false, true);


                    // Tổng dự toán
                    string toLastmonth = GetExcelColumnName(7 + DateTime.Now.Month);
                    var totalForecast = sheet.Range["G5:" + toLastmonth + "5"];
                    var totalOTByDay = sheet.Range["G6:" + toLastmonth + "6"];
                    var totalBalance = sheet.Range["G7:" + toLastmonth + "7"];
                    // set style
                    SetStyleRange(totalForecast, "Tổng dự toán theo ngày", 12, true, true, 26);
                    SetStyleRange(totalOTByDay, "Tổng thực tế theo ngày", 12, true, true, 26);
                    SetStyleRange(totalBalance, "Chênh lệch theo ngày", 12, true, true, 26);
                    SetBorder(totalForecast, false, true);
                    SetBorder(totalOTByDay, false, true);
                    SetBorder(totalBalance, false, true);

                    // value statistic
                    string beginValue = GetExcelColumnName(7 + DateTime.Now.Month + 1);
                    var forcastValue = sheet.Range[beginValue + "5" + ":" + lastColumnName + "5"];
                    var OTvalue = sheet.Range[beginValue + "6" + ":" + lastColumnName + "6"];
                    var balanceValue = sheet.Range[beginValue + "7" + ":" + lastColumnName + "7"];
                    SetBorder(forcastValue, true, true);
                    SetBorder(OTvalue, true, true);
                    SetBorder(balanceValue, true, true);

                    // header row

                    SetStyleRange(sheet.Range["A8:A9"], "STT", 12, true, true, 17);
                    SetStyleRange(sheet.Range["B8:B9"], "Code", 12, true, true, 17);
                    SetStyleRange(sheet.Range["C8:C9"], "Họ tên", 12, true, true, 17);
                    SetStyleRange(sheet.Range["D8:D9"], "Bộ phận", 12, true, true, 17);
                    SetStyleRange(sheet.Range["E8:E9"], "Khách hàng", 12, true, true, 17);
                    SetStyleRange(sheet.Range["F8:F9"], "Trực tiếp/ Gián tiếp", 12, true, true, 17);
                    SetStyleRange(sheet.Range["G8:G9"], "Năm", 12, true, true, 17);

                    SetBorder(sheet.Range["A8:A9"], false, true);
                    SetBorder(sheet.Range["B8:B9"], false, true);
                    SetBorder(sheet.Range["C8:C9"], false, true);
                    SetBorder(sheet.Range["D8:D9"], false, true);
                    SetBorder(sheet.Range["E8:E9"], false, true);
                    SetBorder(sheet.Range["F8:F9"], false, true);
                    SetBorder(sheet.Range["G8:G9"], false, true);


                    // Total OT for month
                    string beforeToLastmonth = GetExcelColumnName(7 + DateTime.Now.Month - 1);
                    SetStyleRange(sheet.Range["H8:" + beforeToLastmonth + "8"], "Tổng tăng ca thực tế", 12, true, true, 17);
                    SetBorder(sheet.Range["H8:" + beforeToLastmonth + "8"], false, true);

                    for (int i = 1; i <= DateTime.Now.Month; i++)
                    {
                        string column = GetExcelColumnName(7 + i);
                        string sortMonth = new DateTime(DateTime.Now.Year, i, 1).Date.ToString("MMM");
                        SetStyleRange(sheet.Range[column + "9"], sortMonth, 12, true, false, 17);
                        SetBorder(sheet.Range[column + "9"], false, true);
                        if (i == DateTime.Now.Month)
                        {
                            SetStyleRange(sheet.Range[column + "8:" + column + "9"], "Thực tế tăng ca", 12, true, true, 17);
                            sheet.Range[column + "8:" + column + "9"].Style.WrapText = true;
                        }
                    }

                    // set day
                    int numberDayInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                    for (int i = 1; i <= numberDayInMonth; i++)
                    {
                        string beginDayValue = GetExcelColumnName(7 + DateTime.Now.Month + i);
                        SetStyleRange(sheet.Range[beginDayValue + "8"], i.ToString().PadLeft(2, '0'), 9, true, false, 17);
                        SetBorder(sheet.Range[beginDayValue + "8"], false, true);

                        string day = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i).Date.ToString("ddd");
                        SetStyleRange(sheet.Range[beginDayValue + "9"], day, 11, true, false, 17);
                        SetBorder(sheet.Range[beginDayValue + "9"], false, true);
                    }

                    // tô màu header

                    sheet.Range["A8:" + lastColumnName + "9"].Style.Color = Color.FromArgb(255, 192, 0);


                    // giãn cột
                    sheet.Columns[2].ColumnWidth = 30;
                    sheet.Columns[4].ColumnWidth = 18;
                    sheet.Columns[5].ColumnWidth = 24;
                    //Fill data from dgv

                    for (int row = 5; row < dgv.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgv.Columns.Count; col++)
                        {
                            int startSheetRow = 5 + row;
                            string value = dgv.Rows[row].Cells[col].Value == null ? "" : dgv.Rows[row].Cells[col].Value.ToString();
                            SetStyleRange(sheet.Range[startSheetRow, col + 1], value, 10, false, false, 22);
                            SetBorder(sheet.Range[startSheetRow, col + 1], false, true);
                        }
                    }
                    // lũy kế
                    for (int row = 0; row < 3; row++)
                    {
                        int startValueCol = 6 + DateTime.Now.Month + 1;
                        int startSheetRow = 5 + row;
                        for (int col = startValueCol; col < dgv.Columns.Count; col++)
                        {

                            string startColName = GetExcelColumnName(col + 1);
                            string value = dgv.Rows[row].Cells[col].Value == null ? "" : dgv.Rows[row].Cells[col].Value.ToString();
                            SetStyleRange(sheet.Range[startColName + startSheetRow], value, 10, false, false, 22);
                        }
                    }

                    // Tô màu thứ 7,cn

                    for (int col = 7 + DateTime.Now.Month + 1; col <= lastColumnIndex; col++)
                    {
                        CellRange cell = sheet.Range[9, col];
                        if (cell.Text == "Sat")
                        {
                            string columnName = GetExcelColumnName(col);
                            int rowcount = sheet.Rows.Count();
                            var columnRange = sheet.Range[columnName + "10:" + columnName + rowcount];
                            columnRange.Style.Color = System.Drawing.Color.FromArgb(217, 217, 217);
                        }
                        if (cell.Text == "Sun")
                        {
                            string columnName = GetExcelColumnName(col);
                            int rowcount = sheet.Rows.Count();
                            var columnRange = sheet.Range[columnName + "10:" + columnName + rowcount];
                            columnRange.Style.Color = System.Drawing.Color.FromArgb(255, 0, 0);
                        }
                    }

                    // Save the workbook to the specified file path
                    workbook.SaveToFile(filePath, ExcelVersion.Version2013);

                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private static void SetBorder(CellRange range, bool inside, bool around)
        {
            try
            {
                if (inside)
                {
                    range.BorderInside(LineStyleType.Thin, Color.Black);
                }
                if (around)
                {
                    range.BorderAround(LineStyleType.Thin, Color.Black);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void SetStyleRange(CellRange range, string value, int fontSize, bool isBold, bool merge, int height)
        {
            try
            {
                if (merge)
                {
                    range.Merge();
                }
                range.Value = value;
                range.Style.HorizontalAlignment = HorizontalAlignType.Center;
                range.Style.VerticalAlignment = VerticalAlignType.Center;
                range.Style.Font.Size = fontSize;
                range.Style.Font.IsBold = isBold;
                range.RowHeight = height;
                range.Style.Font.FontName = "Times New Roman";
            }
            catch (Exception)
            {
                throw;
            }
        }

        static string GetExcelColumnName(int columnIndex)
        {
            int dividend = columnIndex;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

    }
}
