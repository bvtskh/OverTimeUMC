using CommonProject.Loading.LoadingClass;
using OverTime.Business;
using OverTime.DataBase;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public partial class FormInputFingerPrint : Form
    {
        public List<Tbl_DailyOverTime> lstFingerPrint = new List<Tbl_DailyOverTime>();
        public List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstMankichiOrigin = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();
        DateTime DateSelect;
        public FormInputFingerPrint()
        {
            InitializeComponent();
            BackgroundLoading BL = new BackgroundLoading(GetData, RequestCompleted);
            BL.Start(true);
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            lstFingerPrint.Clear();
            OpenFileDialog FileDlg = new OpenFileDialog();
            FileDlg.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            FileDlg.RestoreDirectory = true;
            if (FileDlg.ShowDialog() == DialogResult.OK)
            {
                var destinationPath = $@"\\172.28.10.12\DX Center\ThanhDX\Vân tay {DateTime.Now.ToString("ddMMyyyy hhmmss")}.xlsx";
                ATCommon.ATCommon.CopyExcelFile(FileDlg.FileName, destinationPath);
                Common.RunProcess("LoadTitle.exe");
                lstFingerPrint = ExcelFileProcess.NewGetDataFingerFromExcelUsingNPOI(FileDlg.FileName);

                if (lstFingerPrint.Count > 0)
                {
                    DateSelect = lstFingerPrint[0].DateOverTime;
                    // Update Ca làm việc
                    lstFingerPrint = UpdateCaLamViec(lstFingerPrint, DateSelect);
                    // Tính tổng thời gian overTime
                    lstFingerPrint = CalculationOverTime(lstFingerPrint, DateSelect);
                    Common.KillProcess("LoadTitle");
                    dgvTimeInOut.DataSource = null;
                    dgvTimeInOut.DataSource = lstFingerPrint;
                    dgvTimeInOut.Columns[0].Frozen = true;
                    dgvTimeInOut.Columns[1].Frozen = true;
                    dgvTimeInOut.Columns[2].Frozen = true;
                    EditViewDgvTimeInOut();
                    dgvTimeInOut.Refresh();
                }
            }
        }
        private List<Tbl_DailyOverTime> UpdateCaLamViec(List<Tbl_DailyOverTime> lstTimeInOut, DateTime DateSelect)
        {
            //Load bang du lieu ca lam viec
            List<Tbl_DailyOverTime> lstRes = new List<Tbl_DailyOverTime>();
            List<CALamViec> lstCaLV = new List<CALamViec>();
            using(var db = new DBContext())
            {
                //var lstMasterWorkingShift = PI_Lib.MankichiHelper.GetShiftWorking(DateSelect.Year, DateSelect.Month);
                List<PI_Lib.Entities.Tbl_ShiftWorking_Entity> lstMasterWorkingShift = OverTimeHelper.GetShiftWorking(DateSelect.Year, DateSelect.Month);
                foreach (var item in lstMasterWorkingShift)
                {
                    CALamViec c = new CALamViec();
                    c = getCaLamViec(item, DateSelect.Day);
                    lstCaLV.Add(c);
                }
                lstRes = (from t in lstTimeInOut
                          join k in lstCaLV on t.Code equals k.Code
                          select new Tbl_DailyOverTime
                          {
                              DateOverTime = t.DateOverTime,
                              Code = t.Code,
                              FullName = t.FullName,
                              TimeIn = t.TimeIn,
                              TimeOut = t.TimeOut,
                              OTDayShift = t.OTDayShift,
                              AdjustOTDayShift = t.AdjustOTDayShift,
                              OTNightShift = t.OTNightShift,
                              AdjustOTNightShift = t.AdjustOTNightShift,
                              CaLV = k.ToDayShiftCode.ToUpper().ToString(),
                          }).ToList();
            }
            return lstRes;
        }

        public static CALamViec getCaLamViec(PI_Lib.Entities.Tbl_ShiftWorking_Entity item, int Day)
        {
            CALamViec c = new CALamViec();
            c.Code = item.Code;
            switch (Day)
            {
                case 1:
                    c.ToDayShiftCode = item.Day1;
                    break;
                case 2:
                    c.ToDayShiftCode = item.Day2;
                    break;
                case 3:
                    c.ToDayShiftCode = item.Day3;
                    break;
                case 4:
                    c.ToDayShiftCode = item.Day4;
                    break;
                case 5:
                    c.ToDayShiftCode = item.Day5;
                    break;
                case 6:
                    c.ToDayShiftCode = item.Day6;
                    break;
                case 7:
                    c.ToDayShiftCode = item.Day7;
                    break;
                case 8:
                    c.ToDayShiftCode = item.Day8;
                    break;
                case 9:
                    c.ToDayShiftCode = item.Day9;
                    break;
                case 10:
                    c.ToDayShiftCode = item.Day10;
                    break;
                case 11:
                    c.ToDayShiftCode = item.Day11;
                    break;
                case 12:
                    c.ToDayShiftCode = item.Day12;
                    break;
                case 13:
                    c.ToDayShiftCode = item.Day13;
                    break;
                case 14:
                    c.ToDayShiftCode = item.Day14;
                    break;
                case 15:
                    c.ToDayShiftCode = item.Day15;
                    break;
                case 16:
                    c.ToDayShiftCode = item.Day16;
                    break;
                case 17:
                    c.ToDayShiftCode = item.Day17;
                    break;
                case 18:
                    c.ToDayShiftCode = item.Day18;
                    break;
                case 19:
                    c.ToDayShiftCode = item.Day19;
                    break;
                case 20:
                    c.ToDayShiftCode = item.Day20;
                    break;
                case 21:
                    c.ToDayShiftCode = item.Day21;
                    break;
                case 22:
                    c.ToDayShiftCode = item.Day22;
                    break;
                case 23:
                    c.ToDayShiftCode = item.Day23;
                    break;
                case 24:
                    c.ToDayShiftCode = item.Day24;
                    break;
                case 25:
                    c.ToDayShiftCode = item.Day25;
                    break;
                case 26:
                    c.ToDayShiftCode = item.Day26;
                    break;
                case 27:
                    c.ToDayShiftCode = item.Day27;
                    break;
                case 28:
                    c.ToDayShiftCode = item.Day28;
                    break;
                case 29:
                    c.ToDayShiftCode = item.Day29;
                    break;
                case 30:
                    c.ToDayShiftCode = item.Day30;
                    break;
                case 31:
                    c.ToDayShiftCode = item.Day31;
                    break;
            }
            if(!string.IsNullOrEmpty(c.ToDayShiftCode))
            {
                c.ToDayShiftCode = c.ToDayShiftCode.ToUpper();
            }
            if(c.ToDayShiftCode == null)
            {
                c.ToDayShiftCode = "";
            }
            return c;
        }

        private List<Tbl_DailyOverTime> CalculationOverTime(List<Tbl_DailyOverTime> lstItem, DateTime dateTime)
        {
            List<Tbl_DailyOverTime> res = new List<Tbl_DailyOverTime>();
            
            int Month = dateTime.Month;
            int Year = dateTime.Year;
            int today = dateTime.Day;
            DateTime MonthOTPreShift = new DateTime(Year, Month, 1, 0, 0, 0);
            using (var db = new DBContext())
            {
                var lstOTPreShift = db.Tbl_OTBeforeShift.Where(x => x.MonthOfYear == MonthOTPreShift).ToList();
                var lstDetailOTPreShift = FormOTBeforeShift.ShowRegisterOTPreShift(lstOTPreShift,today);
                var lstMasterShift = db.Tbl_MasterShift.ToList();
                foreach (var item in lstItem)
                {
                    var findOTPreShift = lstDetailOTPreShift.FirstOrDefault(x => x.Code == item.Code);
                    if(findOTPreShift!= null)
                    {
                        if(!string.IsNullOrEmpty(findOTPreShift.Today))
                        {
                            var findShift = lstMasterShift.FirstOrDefault(x => x.ShiftCode == item.CaLV);
                            if(findShift != null)
                            {
                                if(item.TimeIn.Value.Hours != 0 && item.TimeIn.Value.TotalMinutes != 0)
                                {
                                    TimeSpan pre = findShift.TimeIn.Value - item.TimeIn.Value;
                                    int ot = (int)(pre.TotalMinutes / 30);
                                    double MinuteOver = ot * 30;
                                    item.TimeOTPreshift = (double)(MinuteOver / 60);
                                }                             
                            }     
                        }
                    }
                    item.TimeOTFinger = (double)(item.AdjustOTDayShift + item.AdjustOTNightShift) / 60;
                    if(item.TimeOTPreshift == null) { item.TimeOTPreshift = 0; }
                    item.TotalOT = item.TimeOTPreshift + item.TimeOTFinger;
                    res.Add(item);
                }
            }
            return res;
        }

        private void EditViewDgvTimeInOut()
        {
            dgvTimeInOut.Columns["Code"].Width = 60;
            dgvTimeInOut.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTimeInOut.Columns["OTDayShift"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTimeInOut.Columns["AdjustOTDayShift"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTimeInOut.Columns["OTNightShift"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTimeInOut.Columns["AdjustOTNightShift"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTimeInOut.Columns["TimeOTFinger"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTimeInOut.Columns["TimeOTPreshift"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTimeInOut.Columns["TotalOT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTimeInOut.Columns["CaLV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTimeInOut.Columns["Id"].Visible = false;
            dgvTimeInOut.Columns["CaLV"].Width = 60;
            dgvTimeInOut.Columns["TimeRegisted"].Visible = false;
            dgvTimeInOut.Columns["TimeOTDept"].Visible = false;
            dgvTimeInOut.Columns["Balance"].Visible = false;
            dgvTimeInOut.Columns["Comment"].Visible = false;
            dgvTimeInOut.Columns["Reason"].Visible = false;
            dgvTimeInOut.Columns["UserRegister"].Visible = false;
            dgvTimeInOut.Columns["Approve"].Visible = false;

        }
        private bool CheckDataFingerExited()
        {
            bool res = false;
            using (var db = new DBContext())
            {
                var SearchFinger = db.Tbl_DailyOverTime.FirstOrDefault(x => x.DateOverTime == DateSelect && x.TimeIn != null && x.TimeOut != null);
                if(SearchFinger != null) { res = true; }
                else { res = false; }
            }
            return res;

        }

        private void btnSaveTimeINOUT_Click(object sender, EventArgs e)
        {
            if (dgvTimeInOut.Rows.Count > 0)
            {
                if (CheckDataFingerExited() == false)
                {
                    SaveAllDataToDataBase();
                }
                else
                {
                    string mes = string.Format("Đã có Dữ liệu vân tay của ngày {0}\nYes để update lại\nNo để hủy bỏ", DateSelect.ToString("dd/MMM/yyyy"));
                    DialogResult d = MessageBox.Show(mes, "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        SaveAllDataToDataBase();

                    }
                }
            }           
        }

        private void SaveAllDataToDataBase()
        {
            Common.RunProcess("LoadTitle.exe");
            SaveDataFingerToDataBase();
            var lstUpdate = UpdateDataOverTimeToTableSummaryOT();
            lstUpdate = lstUpdate.OrderBy(x => x.Code).ToList();
            ConvertListDetilSummaryAndSaveToDB(lstUpdate);
            Common.KillProcess("LoadTitle");
        }

        private void SaveDataFingerToDataBase()
        {
            // Update lại Time vân tay
            using (var db = new DBContext())
            {
                var lstRegister = db.Tbl_DailyOverTime.Where(x => x.DateOverTime == DateSelect).ToList();
                var lstMasterShift = db.Tbl_MasterShift.ToList();
                List<Tbl_DailyOverTime> lstAddNew = new List<Tbl_DailyOverTime>();
                if (lstFingerPrint.Count > 0)
                {
                    Common.RunProcess("LoadTitle.exe");
                    foreach (var item in lstFingerPrint)
                    {
                        var findRegisItem = lstRegister.FirstOrDefault(x => x.Code == item.Code);
                        if (findRegisItem != null)
                        {
                            findRegisItem.TimeIn = item.TimeIn;
                            findRegisItem.TimeOut = item.TimeOut;
                            findRegisItem.OTDayShift = item.OTDayShift;
                            findRegisItem.AdjustOTDayShift = item.AdjustOTDayShift;
                            findRegisItem.OTNightShift = item.OTNightShift;
                            findRegisItem.AdjustOTNightShift = item.AdjustOTNightShift;
                            findRegisItem.CaLV = item.CaLV;
                            findRegisItem.TimeOTFinger = item.TimeOTFinger;
                            findRegisItem.TimeOTPreshift = item.TimeOTPreshift;
                            findRegisItem.TotalOT = item.TotalOT;
                            double NumberRegisOT = findRegisItem.TimeRegisted != null ? (double)findRegisItem.TimeRegisted : 0;
                            double Balance = (double)Math.Abs((double)NumberRegisOT - (double)item.TotalOT);
                            findRegisItem.Balance = Balance;
                            if(Balance == 0)
                            {
                                findRegisItem.TimeOTDept = item.TotalOT is double t ? t : 0;
                            }
                            db.Entry<Tbl_DailyOverTime>(findRegisItem).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            item.TimeRegisted = 0;
                            item.Balance = item.TotalOT;
                            lstAddNew.Add(item);
                        }
                    }
                    db.Tbl_DailyOverTime.AddRange(lstAddNew);
                    db.SaveChanges();
                    //Common.KillProcess("LoadTitle");
                    //MessageBox.Show("Update Success", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        //Updte DataOver Time
        private List<HistoryDetailOverTime> UpdateDataOverTimeToTableSummaryOT()
        {
            // Update dữ liệu tăng ca hàng ngày vào list Detail
            List<HistoryDetailOverTime> lstDetaiOT = new List<HistoryDetailOverTime>();
            int Day = DateSelect.Day;
            using (var db = new DBContext())
            {
                var lstUpdate = db.Tbl_DailyOverTime.Where(x => x.DateOverTime == DateSelect && x.TimeRegisted != 0 && x.Balance == 0).ToList();

                lstDetaiOT = GetListSummaryDetailOverTime(DateSelect, lstUpdate);
                // Update dữ liệu OT hàng ngày vào bảng summary
                foreach (var item in lstUpdate)
                {
                    var findItem = lstDetaiOT.FirstOrDefault(x => x.Day == Day && x.Code == item.Code);
                    if (findItem != null)
                    {
                        findItem.ActualOT = (double)item.TimeOTDept;
                        //findItem.Dept = item.Dept;
                    }
                    else
                    {
                        HistoryDetailOverTime d = new HistoryDetailOverTime();
                        var finDept = lstMankichiOrigin.FirstOrDefault(x => x.AltCode == item.Code);
                        if(finDept != null)
                        {
                            d.Code = item.Code;
                            d.Name = item.FullName;
                            d.Dept = finDept.Dept;
                            d.Direct = finDept.Direct_Indirect;
                            d.Day = Day;
                            d.ActualOT = (double)item.TimeOTDept;
                            lstDetaiOT.Add(d);
                        }
                    }
                }
            }
            
            return lstDetaiOT;
        }

        private void ConvertListDetilSummaryAndSaveToDB(List<HistoryDetailOverTime> lstItem)
        {
            List<Tbl_SummaryOverTime> lstResult = new List<Tbl_SummaryOverTime>();
            using (var db = new DBContext())
            {
                lstResult = db.Tbl_SummaryOverTime.Where(x => x.MonthOfYear.Value.Year == DateSelect.Year && x.MonthOfYear.Value.Month == DateSelect.Month).ToList();
                var lstGroup = lstItem.GroupBy(o => new { o.Code }).Select(o => new
                {
                    Code = o.Key.Code,
                }).ToList();
                if (lstGroup.Count > 0)
                {
                    foreach (var item in lstGroup)
                    {

                        var findList = lstItem.Where(x => x.Code == item.Code).ToList();
                        if (findList.Count > 0)
                        {
                            string Detail = string.Empty;
                            double SumOT = 0;
                            foreach (var itemDetail in findList)
                            {
                                Detail += itemDetail.Day.ToString() + ":" + itemDetail.ActualOT.ToString() + "|";
                                SumOT += itemDetail.ActualOT;
                            }
                            if (Detail.EndsWith("|"))
                            { Detail = Detail.Remove(Detail.Length - 1, 1).Trim(); }
                            var ExitedItem = lstResult.FirstOrDefault(x => x.Code == item.Code);
                            if (ExitedItem != null)
                            {
                                ExitedItem.Actual = Detail;
                                ExitedItem.TotalOverTime = SumOT;
                                ExitedItem.Dept = findList[0].Dept;
                                if (ExitedItem.TotalOverTime > ExitedItem.MaxOverTime)
                                {
                                    ExitedItem.Status = "ALARM";
                                }
                                else { ExitedItem.Status = "OK"; }
                                db.Entry<Tbl_SummaryOverTime>(ExitedItem).State = System.Data.Entity.EntityState.Modified;
                            }
                            else
                            {
                                Tbl_SummaryOverTime s = new Tbl_SummaryOverTime();
                                DateTime d = new DateTime(DateSelect.Year, DateSelect.Month, 1, 0, 0, 0);
                                s.MonthOfYear = d;
                                s.Code = item.Code;
                                s.FullName = findList[0].Name;
                                s.Dept = findList[0].Dept;
                                s.Direct_InDirect = findList[0].Direct;
                                if(findList[0].Direct.Contains("Trực tiếp")) { s.MaxOverTime = 30; }
                                else { s.MaxOverTime = 25; }
                                s.PlanOverTime = 0;
                                s.TotalOverTime = (double)SumOT;
                                s.Actual = Detail;
                                if (s.TotalOverTime > s.MaxOverTime)
                                {
                                    DateTime NowDay = DateTime.Now.Date;
                                    DateTime DateBlock = new DateTime(2023, 12, 1, 0, 0, 0);
                                    if(NowDay > DateBlock)
                                    {
                                        s.Status = "BLOCK";
                                    }
                                }
                                else { s.Status = "OK"; }
                                db.Tbl_SummaryOverTime.Add(s);
                            }
                        }
                    }
                    db.SaveChanges();
                }
            }

        }


        public static List<HistoryDetailOverTime> GetListSummaryDetailOverTime(DateTime dateSelect, List<Tbl_DailyOverTime> lstAdjust)
        {
            //Đọc DataBase và Convert sang list chi tiết overtime từng ngày từng người
            int Month = dateSelect.Month;
            int Year = dateSelect.Year;
            List<HistoryDetailOverTime> lstHistoryOT = new List<HistoryDetailOverTime>();
            using (var db = new DBContext())
            {
                var lstSummary = db.Tbl_SummaryOverTime.Where(x => x.MonthOfYear.Value.Year == Year && x.MonthOfYear.Value.Month == Month).ToList();

                lstSummary = (from s in lstSummary
                              join d in lstAdjust on s.Code equals d.Code
                              select s).ToList();

                if (lstSummary.Count > 0)
                {
                    foreach (var item in lstSummary)
                    {
                        if (!string.IsNullOrEmpty(item.Actual))
                        {
                            string[] ot = item.Actual.Split('|');
                            for (int i = 0; i < ot.Length; i++)
                            {
                                string[] s = ot[i].Split(':');
                                HistoryDetailOverTime h = new HistoryDetailOverTime();
                                h.Code = item.Code;
                                h.Name = item.FullName;
                                h.Dept = item.Dept;
                                h.Direct = item.Direct_InDirect;
                                h.Day = Convert.ToInt16(s[0]);
                                h.ActualOT = Convert.ToDouble(s[1]);
                                lstHistoryOT.Add(h);
                            }
                        }
                    }
                }
            }
            return lstHistoryOT;
        }


        private void FormInputFingerPrint_Load(object sender, EventArgs e)
        {
            
        }

        private void RequestCompleted(DataTable dt)
        {
            lstMankichiOrigin = GAMankuchiAll.Instance()._listAllStaff;
        }

        private DataTable GetData()
        {
            var init = GAMankuchiAll.Instance()._listAllStaff;
            return new DataTable();
        }


        private void FormInputFingerPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(dgvTimeInOut.RowCount > 0)
            {
                DialogResult dlr =
                MessageBox.Show("Bạn có muốn lưu lại dữ liệu trước khi thoát không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlr == DialogResult.Yes)
                {
                    btnSaveTimeINOUT_Click(null, null);
                }
            }
        }
    }


    public class CALamViec
    {
        public string Code { get; set; }
        public string ToDayShiftCode { get; set; }
    }
}
