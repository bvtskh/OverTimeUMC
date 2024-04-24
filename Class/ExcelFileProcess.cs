using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.Globalization;
using OverTime.Business;
using OverTime.DataBase;
using ExcelDataReader;

namespace OverTime
{
    public class ExcelFileProcess
    {
        public static List<TimeInOut> GetListItemQuotaFromExcel(string path)
        {
            List<TimeInOut> lstResult = new List<TimeInOut>();

            Workbook wbFromMaster = new Workbook();
            wbFromMaster.LoadFromFile(path);
            Worksheet sheet = wbFromMaster.Worksheets[0];
            using (var db = new DBContext())
            {
                for (int i = 2; i <= 20; i++)
                {
                    var result = new TimeInOut();
                    result.Code = (sheet.Range[i, 2].DisplayedText != "") ? sheet.Range[i, 2].DisplayedText : "";
                    result.Name = (sheet.Range[i, 3].DisplayedText != "") ? sheet.Range[i, 3].DisplayedText.Trim() : "";
                    //if (sheet.Range[i, 7].DisplayedText != "")
                    //{
                    //    result.TimeIn = Convert.ToDateTime(sheet.Range[i, 7].DisplayedText.Trim());
                    //}
                    //if (sheet.Range[i, 8].DisplayedText != "")
                    //{
                    //    result.TimeOut = Convert.ToDateTime(sheet.Range[i, 8].DisplayedText.Trim());
                    //}
                    lstResult.Add(result);
                }
            }

            return lstResult;
        }



        public static List<TimeInOut> GetListTimeInOutFromExcelUsingNPOI(string PathFile)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            List<TimeInOut> lstResult = new List<TimeInOut>();

            FileStream fs = new FileStream(PathFile, FileMode.Open);
            XSSFWorkbook wb = new XSSFWorkbook(fs);
            ISheet sheet = wb.GetSheetAt(0);
            var DateOT = new DateTime();
            var rowDate = sheet.GetRow(3);
            try
            {
                string Date = rowDate.GetCell(2).DateCellValue.ToString();
                string[] d = Date.Split('/').ToArray();
                int Day = Convert.ToInt16(d[0]);
                int Month = Convert.ToInt16(d[1]);
                int Year = Convert.ToInt16(d[2].Substring(0, 4));
                DateOT = new DateTime(Year, Month, Day, 0, 0, 0);
            }
            catch
            {
                string Date = rowDate.GetCell(2).StringCellValue.ToString();
                DateOT = DateTime.ParseExact(Date, "dd/MM/yyyy", provider);
            }
            for (int i = 8; i <= sheet.LastRowNum; i++)
            {
                var result = new TimeInOut();
                var nowRow = sheet.GetRow(i);
                result.Date = DateOT;
                if (nowRow.GetCell(1) != null)
                {
                    //result.Code = nowRow.GetCell(1).StringCellValue.ToString().Trim();

                    try { result.Code = nowRow.GetCell(1).StringCellValue.ToString(); }
                    catch { result.Code = nowRow.GetCell(1).NumericCellValue.ToString(); }

                    if (string.IsNullOrEmpty(result.Code))
                    {
                        break;
                    }
                    else
                    {
                        result.Name = (nowRow.GetCell(2) != null) ? nowRow.GetCell(2).StringCellValue : "";

                        if (nowRow.GetCell(3) != null)
                        {
                            try
                            {
                                string StTimeIn = nowRow.GetCell(3).StringCellValue.ToString();
                                result.TimeIn = TimeSpan.Parse(StTimeIn);
                            }
                            catch { result.TimeIn = TimeSpan.Parse("00:00:00"); }
                        }
                        if (nowRow.GetCell(4) != null)
                        {
                            try
                            {
                                string StTimeOut = nowRow.GetCell(4).StringCellValue.ToString();
                                result.TimeOut = TimeSpan.Parse(StTimeOut);
                            }
                            catch { result.TimeOut = TimeSpan.Parse("00:00:00"); }

                        }
                        if (nowRow.GetCell(5) != null)
                        {
                            try { result.OTDayShift = Convert.ToDouble(nowRow.GetCell(5).StringCellValue.Trim()); }
                            catch { result.OTDayShift = nowRow.GetCell(5).NumericCellValue; }
                        }
                        if (nowRow.GetCell(6) != null)
                        {
                            try { result.AdjustOTDayShift = Convert.ToDouble(nowRow.GetCell(6).StringCellValue.Trim()); }
                            catch { result.AdjustOTDayShift = nowRow.GetCell(6).NumericCellValue; }
                        }
                        if (nowRow.GetCell(7) != null)
                        {
                            try { result.OTNightShift = Convert.ToDouble(nowRow.GetCell(7).StringCellValue.Trim()); }
                            catch { result.OTNightShift = nowRow.GetCell(7).NumericCellValue; }
                        }
                        if (nowRow.GetCell(8) != null)
                        {
                            try { result.AdjustOTNightShift = Convert.ToDouble(nowRow.GetCell(8).StringCellValue.Trim()); }
                            catch { result.AdjustOTNightShift = nowRow.GetCell(8).NumericCellValue; }
                        }
                        if (!result.Code.Contains("UJ"))
                        {
                            lstResult.Add(result);
                        }
                    }
                }
            }
            return lstResult;
        }



        public static List<Tbl_DailyOverTime> NewGetDataFingerFromExcelUsingNPOI(string PathFile)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            List<Tbl_DailyOverTime> lstResult = new List<Tbl_DailyOverTime>();

            FileStream fs = new FileStream(PathFile, FileMode.Open, FileAccess.Read);
            XSSFWorkbook wb = new XSSFWorkbook(fs);
            ISheet sheet = wb.GetSheetAt(0);
            var DateOT = new DateTime();
            var rowDate = sheet.GetRow(3);
            try
            {
                string Date = rowDate.GetCell(2).DateCellValue.ToString();
                string[] d = Date.Split('/').ToArray();
                int Day = Convert.ToInt16(d[0]);
                int Month = Convert.ToInt16(d[1]);
                int Year = Convert.ToInt16(d[2].Substring(0, 4));
                DateOT = new DateTime(Year, Month, Day, 0, 0, 0);
            }
            catch
            {
                string Date = rowDate.GetCell(2).StringCellValue.ToString();
                DateOT = DateTime.ParseExact(Date, "dd/MM/yyyy", provider);
            }
            for (int i = 8; i <= sheet.LastRowNum; i++)
            {
                var result = new Tbl_DailyOverTime();
                var nowRow = sheet.GetRow(i);
                result.DateOverTime = DateOT;
                if (nowRow.GetCell(1) != null)
                {
                    //result.Code = nowRow.GetCell(1).StringCellValue.ToString().Trim();

                    try { result.Code = nowRow.GetCell(1).StringCellValue.ToString(); }
                    catch { result.Code = nowRow.GetCell(1).NumericCellValue.ToString(); }

                    if (string.IsNullOrEmpty(result.Code))
                    {
                        break;
                    }
                    else
                    {
                        result.FullName = (nowRow.GetCell(2) != null) ? nowRow.GetCell(2).StringCellValue : "";

                        if (nowRow.GetCell(3) != null)
                        {
                            try
                            {
                                string StTimeIn = nowRow.GetCell(3).StringCellValue.ToString();
                                result.TimeIn = TimeSpan.Parse(StTimeIn);
                            }
                            catch { result.TimeIn = TimeSpan.Parse("00:00:00"); }
                        }
                        if (nowRow.GetCell(4) != null)
                        {
                            try
                            {
                                string StTimeOut = nowRow.GetCell(4).StringCellValue.ToString();
                                result.TimeOut = TimeSpan.Parse(StTimeOut);
                            }
                            catch { result.TimeOut = TimeSpan.Parse("00:00:00"); }

                        }
                        if (nowRow.GetCell(5) != null)
                        {
                            try { result.OTDayShift = Convert.ToDouble(nowRow.GetCell(5).StringCellValue.Trim()); }
                            catch { result.OTDayShift = nowRow.GetCell(5).NumericCellValue; }
                        }
                        if (nowRow.GetCell(6) != null)
                        {
                            try { result.AdjustOTDayShift = Convert.ToDouble(nowRow.GetCell(6).StringCellValue.Trim()); }
                            catch { result.AdjustOTDayShift = nowRow.GetCell(6).NumericCellValue; }
                        }
                        if (nowRow.GetCell(7) != null)
                        {
                            try { result.OTNightShift = Convert.ToDouble(nowRow.GetCell(7).StringCellValue.Trim()); }
                            catch { result.OTNightShift = nowRow.GetCell(7).NumericCellValue; }
                        }
                        if (nowRow.GetCell(8) != null)
                        {
                            try { result.AdjustOTNightShift = Convert.ToDouble(nowRow.GetCell(8).StringCellValue.Trim()); }
                            catch { result.AdjustOTNightShift = nowRow.GetCell(8).NumericCellValue; }
                        }
                        if (!result.Code.Contains("UJ"))
                        {
                            lstResult.Add(result);
                        }
                    }
                }
            }
            return lstResult;
        }


        public static List<Tbl_RestrictOT> GetListRetrictOTFromExcel(string PathFile)
        {
            List<Tbl_RestrictOT> lstResult = new List<Tbl_RestrictOT>();
            Workbook wbFromMaster = new Workbook();
            wbFromMaster.LoadFromFile(PathFile);
            Worksheet sheet = wbFromMaster.Worksheets[0];
            for (int i = 2; i <= sheet.LastRow; i++)
            {
                Tbl_RestrictOT r = new Tbl_RestrictOT();
                r.Code = (sheet.Range[i, 1].DisplayedText != "") ? sheet.Range[i, 1].DisplayedText : "";
                r.Name = (sheet.Range[i, 2].DisplayedText != "") ? sheet.Range[i, 2].DisplayedText : "";
                r.Dept = (sheet.Range[i, 3].DisplayedText != "") ? sheet.Range[i, 3].DisplayedText : "";
                r.Reason = (sheet.Range[i, 4].DisplayedText != "") ? sheet.Range[i, 4].DisplayedText.Trim() : "";
                if (sheet.Range[i, 5].DisplayedText != "")
                {
                    r.DateLimit = Convert.ToDateTime(sheet.Range[i, 5].DisplayedText);
                }
                lstResult.Add(r);
            }
            return lstResult;
        }


        public static List<TimeInOut> GetListTimeInOutFromExcelUsingEPPLUS(string PathFile)
        {
            List<TimeInOut> lstResult = new List<TimeInOut>();

            return lstResult;
        }


        public static void ExportExceDaiLyOverTime(List<Tbl_DailyOverTime> lstDailyOT, string FileName)
        {
            string pathformMaster = Path.Combine(Application.StartupPath + "\\ExcelFile", "MasterDailyOT.xlsx");
            Workbook wb = new Workbook();
            wb.LoadFromFile(pathformMaster);
            Worksheet sheet = wb.Worksheets[0];

            var lstMankichi = GAMankuchiAll.Instance()._listAllStaff;
            var lstDailyOTFullInfo = (from d in lstDailyOT
                                      join k in lstMankichi on d.Code equals k.AltCode
                                      select new
                                      {
                                          Code = d.Code,
                                          Code2 = d.Code.TrimStart('0'),
                                          FullName = k.Name,
                                          Dept = k.Dept,
                                          //Position = k.Position,
                                          ShiftCode = k.Direct_Indirect,
                                          TimeIn = d.TimeIn,
                                          TimeOut = d.TimeOut,
                                          OTDayShift = d.OTDayShift,
                                          AdjustOTDayShift = d.AdjustOTDayShift,
                                          OTNightShift = d.OTNightShift,
                                          AdjustOTNightShift = d.AdjustOTNightShift,
                                          TimeOTFinger = d.TimeOTFinger,
                                          TimeOTPreshift = d.TimeOTPreshift,
                                          TotalOT = d.TotalOT,
                                          TimeOTDept = d.TimeOTDept,
                                          TimeRegisted = d.TimeRegisted,
                                          Balance = d.Balance,
                                          Comment = d.Comment,
                                      }).ToList();


            wb.Worksheets[0].Range["C5"].Value = lstDailyOT[0].DateOverTime.ToString("dd/MM/yyyy");
            int No = 1;
            foreach (var item in lstDailyOTFullInfo)
            {
                wb.Worksheets[0].Range[No + 8, 1].Text = No.ToString();// STT
                wb.Worksheets[0].Range[No + 8, 2].Text = item.Code.ToString();// Code 1
                wb.Worksheets[0].Range[No + 8, 3].Text = item.Code2.ToString(); //Code 2
                wb.Worksheets[0].Range[No + 8, 4].Text = item.FullName.ToString(); // Full Name
                wb.Worksheets[0].Range[No + 8, 5].Text = item.Dept.ToString(); // Dept
                                                                               // wb.Worksheets[0].Range[No + 8, 6].Text = item.Position.ToString();// Chức vụ
                wb.Worksheets[0].Range[No + 8, 6].Text = item.ShiftCode != null ? item.ShiftCode.ToString() : "";//Ca làm việc

                wb.Worksheets[0].Range[No + 8, 7].Text = item.TimeIn != null ? item.TimeIn.Value.ToString() : ""; // Giờ vào
                wb.Worksheets[0].Range[No + 8, 8].Text = item.TimeOut != null ? item.TimeOut.Value.ToString() : ""; // Giờ ra

                wb.Worksheets[0].Range[No + 8, 9].NumberValue = item.OTDayShift != null ? (double)item.OTDayShift : 0; // Tăng ca ngày
                wb.Worksheets[0].Range[No + 8, 10].NumberValue = item.AdjustOTDayShift != null ? (double)item.AdjustOTDayShift : 0; // Điều chỉnh tăng ca ngày
                wb.Worksheets[0].Range[No + 8, 11].NumberValue = item.OTNightShift != null ? (double)item.OTNightShift : 0; // Tăng ca đêm
                wb.Worksheets[0].Range[No + 8, 12].NumberValue = item.AdjustOTNightShift != null ? (double)item.AdjustOTNightShift : 0; // Điều chỉnh tăng ca đêm
                wb.Worksheets[0].Range[No + 8, 13].NumberValue = item.TimeOTFinger != null ? (double)item.TimeOTFinger : 0; // Giờ vân tay
                wb.Worksheets[0].Range[No + 8, 14].NumberValue = item.TimeOTPreshift != null ? (double)item.TimeOTPreshift : 0; //Tăng ca trước giờ
                wb.Worksheets[0].Range[No + 8, 15].NumberValue = item.TotalOT != null ? (double)item.TotalOT : 0; //Total OT
                wb.Worksheets[0].Range[No + 8, 16].NumberValue = item.TimeOTDept != null ? (double)item.TimeOTDept : 0; // Giờ bộ phận
                wb.Worksheets[0].Range[No + 8, 17].NumberValue = item.TimeRegisted != null ? (double)item.TimeRegisted : 0; // Giờ đăng ký
                wb.Worksheets[0].Range[No + 8, 18].NumberValue = item.Balance != null ? (double)item.Balance : 0; // Chênh lệch
                if (item.Comment != null)
                {
                    wb.Worksheets[0].Range[No + 8, 19].Text = item.Comment.ToString();
                }
                No++;
            }

            wb.SaveToFile(FileName);
            System.Diagnostics.Process.Start(FileName);
        }

        public static string ExportExcelTotalSummaryOT(List<HistoryDetailOverTime> lstTotalOT, string FileName, DateTime DateSelect)
        {
            try
            {
                string pathformMaster = Path.Combine(Application.StartupPath + "\\ExcelFile", "MasterTotalOT.xlsx");
                Workbook wb = new Workbook();
                wb.LoadFromFile(pathformMaster);
                Worksheet sheet = wb.Worksheets[0];
                var month = DateSelect.Month.ToString();
                month = month.PadLeft(2, '0');
                wb.Worksheets[0].Range["A4"].Text = month;
                wb.Worksheets[0].Range["B4"].Value = DateSelect.Year.ToString();
                wb.Worksheets[0].Range["K2"].Text = string.Format("{0}/{1}", month, DateSelect.Year);
                string PreCode = "";
                int shortCode;
                int No = 0;
                var s = lstTotalOT.Where(m => m.Customer == null).ToList();

                foreach (var item in lstTotalOT)
                {
                    if(item.Code == "39972")
                    {
                        Console.Write("");
                    }
                    if (item.Code != PreCode)
                    {
                        No++;
                        PreCode = item.Code;
                        wb.Worksheets[0].Range[No + 11, 1].Value = No.ToString();
                        wb.Worksheets[0].Range[No + 11, 2].Text = item.Code.ToString();
                        if (int.TryParse(item.Code, out shortCode))
                        {
                            wb.Worksheets[0].Range[No + 11, 3].Text = shortCode.ToString();
                        }
                        else
                        {
                            wb.Worksheets[0].Range[No + 11, 3].Text = item.Code.ToString();
                        }
                        wb.Worksheets[0].Range[No + 11, 4].Text = item.Name.ToString();
                        wb.Worksheets[0].Range[No + 11, 5].Text = item.Dept.ToString();
                        wb.Worksheets[0].Range[No + 11, 6].Text = item.Customer == null ? "" : item.Customer;
                        wb.Worksheets[0].Range[No + 11, 7].Text = item.Direct;
                        wb.Worksheets[0].Range[No + 11, 8].Value = lstTotalOT.Where(m => m.Code == item.Code).Sum(m => m.ActualOT).ToString();
                    }

                    if (item.ActualOT != 0)
                    {
                        wb.Worksheets[0].Range[No + 11, item.Day + 8].Value = item.ActualOT.ToString();
                    }

                }
                int days = DateTime.DaysInMonth(DateSelect.Year, DateSelect.Month);
                sheet.DeleteColumn(days + 9, 3);
                wb.SaveToFile(FileName);
                System.Diagnostics.Process.Start(FileName);
                return "";
            }
            catch(Exception ex)
            {
                return ex.Message.ToString();
            }
           
        }

        internal static DataTable GetShiftCaData(string filePath)
        {
            try
            {
                // Create a new DataTable
                DataTable dataTable = new DataTable();

                // Open and read Excel file using ExcelDataReader
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        // DataSet - The result of each spreadsheet will be created in the result.Tables
                        var result = reader.AsDataSet();

                        // Assume we are interested in the first table only
                        return result.Tables[0];
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
