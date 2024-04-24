using CommonProject.Business;
using CommonProject.Entities;
using OverTime.DataBase;
using OverTime.MsgBox_AQ;
using PI_Lib.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime.Business
{
    public static class OverTimeHelper
    {
        public static bool IsApprove(string dept, DateTime date)
        {
            using (var db = new DBContext())
            {

                var findListWaitApprove = db.Tbl_Approve.Where(x => x.Dept == dept && x.DateOT == date && !string.IsNullOrEmpty(x.Approve)).FirstOrDefault();
                return findListWaitApprove != null;
            }

        }
        public static bool SaveRegister(List<Tbl_DailyOverTime> lstDailyOverTime)
        {
            try
            {
                using (var db = new DBContext())
                {
                    foreach (var item in lstDailyOverTime)
                    {
                        var findExited = db.Tbl_DailyOverTime.FirstOrDefault(x => x.DateOverTime == item.DateOverTime && x.Code == item.Code);
                        if (findExited != null)
                        {
                                findExited.TimeRegisted = item.TimeRegisted;
                                findExited.Reason = item.Reason;
                                db.Entry<Tbl_DailyOverTime>(findExited).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            db.Tbl_DailyOverTime.Add(item);
                        }
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DataTable GetListUserOverTime(DateTime DateSelect,
            string dept,
            string code = "",
            bool allMonth = false,
            bool userDK = false)
        {
            try
            {
                using (var db = new DBContext())
                {
                    List<Tbl_DailyOverTime> lstSearch = new List<Tbl_DailyOverTime>();
                    List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstMankichiJoin = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();
                    if (allMonth)
                    {
                        var firstMonth = new DateTime(DateSelect.Year, DateSelect.Month, 1);
                        var endMonth = firstMonth.AddMonths(1).AddDays(-1);
                        lstSearch = db.Tbl_DailyOverTime.Where(x => x.DateOverTime >= firstMonth && x.DateOverTime <= endMonth).ToList();
                    }
                    else
                    {
                        lstSearch = db.Tbl_DailyOverTime.Where(x => x.DateOverTime == DateSelect).ToList();
                    }
                    if (string.IsNullOrEmpty(dept))
                    {
                        lstMankichiJoin = GAMankuchiAll.Instance()._listAllStaff.ToList();
                    }
                    else
                    {
                        lstMankichiJoin = GAMankuchiAll.Instance()._listAllStaff.Where(x => x.Dept == dept).ToList();
                    }
                    var lstRegisted = (from r in lstSearch
                                       join k in lstMankichiJoin on r.Code equals k.AltCode
                                       where r.TimeOTDept != 0 || r.TimeRegisted != 0
                                       select new
                                       {
                                           Date = r.DateOverTime,
                                           Code = r.Code,
                                           Name = r.FullName,
                                           Direct = k.Direct_Indirect,
                                           Position = k.Position,
                                           Dept = k.Dept,
                                           Customer = k.Customer,
                                           TimeRegisted = r.TimeRegisted,
                                           TimeOTDept = r.TimeOTDept,
                                           Reason = r.Reason,
                                           UserRegister = r.UserRegister,
                                       }).OrderBy(m => m.Code).ToList();
                    if (!string.IsNullOrEmpty(code))
                    {
                        lstRegisted = lstRegisted.Where(m => m.Code == code).ToList();
                    }
                    if (userDK)
                    {
                        lstRegisted = lstRegisted.Where(m => m.UserRegister == Common.UserLogin.UserName).ToList();
                    }
                    DataTable dt = new DataTable();

                    dt.Columns.Add("Mã NV", typeof(string));
                    dt.Columns.Add("Họ Tên", typeof(string));
                    dt.Columns.Add("Bộ Phận", typeof(string));
                    dt.Columns.Add("Khách Hàng", typeof(string));
                    dt.Columns.Add("Ngày ĐK", typeof(DateTime));
                    dt.Columns.Add("Giờ ĐK", typeof(float));
                    dt.Columns.Add("Thực tế", typeof(float));
                    dt.Columns.Add("Lý do", typeof(string));
                    dt.Columns.Add("User ĐK", typeof(string));
                    dt.Columns.Add("Công việc", typeof(string));
                    foreach (var item in lstRegisted)
                    {
                        dt.Rows.Add(new object[]
                        {
                        item.Code,
                        item.Name,
                        item.Dept,
                        item.Customer,
                        item.Date,
                        item.TimeRegisted,
                        item.TimeOTDept,
                        item.Reason,
                        item.UserRegister,
                        item.Direct
                        });
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        internal static string SaveHummanOT(List<Tbl_FCHumanOT> dt)
        {
            try
            {
                using (var db = new DBContext())
                {
                    foreach (var item in dt)
                    {
                        var exist = db.Tbl_FCHumanOT.Where(m => m.DAY == item.DAY
                        && m.CUSTOMER == item.CUSTOMER
                        && m.DEPT == item.DEPT
                        && m.JOB == item.JOB).FirstOrDefault();
                        if (exist == null)
                        {
                            db.Tbl_FCHumanOT.Add(item);
                        }
                        else
                        {
                            exist.HUMAN_OT = item.HUMAN_OT;
                        }
                    }
                    db.SaveChanges();
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        internal static DataTable GetAllLineInCustomerByWeek(string customer, string dept, DateTime DateSelect)
        {
            using (var db = new DBContext())
            {
                var lstLine = GAMankuchi.Instance()._listCurrentStaff.Where(x => x.Dept == dept
                    && x.Customer == customer).ToList();
                var lstLineGroup = lstLine.GroupBy(x => new { x.GroupProcess }).Select(x => new
                {
                    Group = x.Key.GroupProcess,
                }).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Công việc", typeof(string));
                var firstMonth = new DateTime(DateSelect.Year, DateSelect.Month, 1);
                var firstWeek = firstMonth.StartOfWeek(DayOfWeek.Monday);
                var lastMonth = firstMonth.AddMonths(1).AddDays(-1);
                var i = 1;
                for (var date = firstWeek; date <= lastMonth; date = date.AddDays(7))
                {
                    var first = date;
                    var last = date.AddDays(6);
                    if (i == 1)
                    {
                        first = firstMonth;
                    }
                    if (last.CompareTo(lastMonth) > 0)
                    {
                        last = lastMonth;
                    }
                    dt.Columns.Add($"{first.ToString("ddd dd")}", typeof(string));
                    i++;
                }
                foreach (var item in lstLineGroup)
                {
                    if (!string.IsNullOrEmpty(item.Group))
                    {
                        var arr = new List<object>();
                        arr.Add(item.Group);
                        for (var date = firstWeek; date <= lastMonth; date = date.AddDays(7))
                        {
                            var fc = db.Tbl_FCHumanOT.Where(m => m.DAY == date
                            && m.CUSTOMER == customer
                            && m.DEPT == dept
                            && m.JOB == item.Group
                            ).FirstOrDefault();
                            if (fc != null)
                            {
                                arr.Add(fc.HUMAN_OT);
                            }
                            else
                            {
                                arr.Add("");
                            }
                        }

                        dt.Rows.Add(arr.ToArray());
                    }
                }

                return dt;
            }
        }

        internal static string SaveForecastOT(List<Tbl_ForecastOT> dt)
        {
            try
            {
                using (var db = new DBContext())
                {
                    foreach (var item in dt)
                    {
                        var exist = db.Tbl_ForecastOT.Where(m => m.DAY == item.DAY
                        && m.CUSTOMER == item.CUSTOMER
                        && m.DEPT == item.DEPT
                        && m.JOB == item.JOB).FirstOrDefault();
                        if (exist == null)
                        {
                            db.Tbl_ForecastOT.Add(item);
                        }
                        else
                        {
                            exist.TIME_OT = item.TIME_OT;
                        }
                    }
                    db.SaveChanges();
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        private static List<CALamViec> GetListCaLV(DateTime DateSelect)
        {
            List<CALamViec> lstCaLV = new List<CALamViec>();
            using (var db = new DBContext())
            {
                var lstMasterWorkingShift = PI_Lib.MankichiHelper.GetShiftWorking(DateSelect.Year, DateSelect.Month);
                foreach (var item in lstMasterWorkingShift)
                {
                    CALamViec c = new CALamViec();
                    c = FormInputFingerPrint.getCaLamViec(item, DateSelect.Day);
                    lstCaLV.Add(c);
                }
            }
            return lstCaLV;
        }
        public static DataTable GetAllLineInCustomer(string customer, string dept, DateTime DateSelect)
        {
            using (var db = new DBContext())
            {
                var lstLine = GAMankuchi.Instance()._listCurrentStaff.Where(x => x.Dept == dept
                    && x.Customer == customer).ToList();
                var lstLineGroup = lstLine.GroupBy(x => new { x.Job }).Select(x => new
                {
                    Group = x.Key.Job,
                }).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Công việc", typeof(string));
                dt.Columns.Add("Tổng giờ", typeof(double));
                var firstMonth = new DateTime(DateSelect.Year, DateSelect.Month, 1);
                var lastMonth = firstMonth.AddMonths(1).AddDays(-1);
                for (var date = firstMonth; date <= lastMonth; date = date.AddDays(1))
                {
                    dt.Columns.Add(date.ToString(Constants.DAY), typeof(string));
                }
                foreach (var item in lstLineGroup)
                {
                    double total = 0;
                    if (!string.IsNullOrEmpty(item.Group))
                    {
                        var arr = new List<object>();
                        arr.Add(item.Group);
                        for (var date = firstMonth; date <= lastMonth; date = date.AddDays(1))
                        {
                            var fc = db.Tbl_ForecastOT.Where(m => m.DAY == date
                            && m.CUSTOMER == customer
                            && m.DEPT == dept
                            && m.JOB == item.Group
                            ).FirstOrDefault();
                            if (fc != null)
                            {
                                arr.Add(fc.TIME_OT);
                                total += fc.TIME_OT;
                            }
                            else
                            {
                                arr.Add("");
                            }
                        }
                        arr.Insert(1, total);

                        dt.Rows.Add(arr.ToArray());
                    }
                }

                return dt;
            }

        }
        public static DataTable GetBalanceOTInCustomer(string customer, string dept, DateTime DateSelect)
        {
            using (var db = new DBContext())
            {
                var lstLine = GAMankuchi.Instance()._listCurrentStaff.Where(x => x.Dept == dept
                    && x.Customer == customer).ToList();
                var lstLineGroup = lstLine.GroupBy(x => new { x.Job }).Select(x => new
                {
                    Group = x.Key.Job,
                }).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Công việc", typeof(string));
                dt.Columns.Add(" ", typeof(string));
                var firstMonth = new DateTime(DateSelect.Year, DateSelect.Month, 1);
                var lastMonth = firstMonth.AddMonths(1).AddDays(-1);
                for (var date = firstMonth; date <= lastMonth; date = date.AddDays(1))
                {
                    dt.Columns.Add(date.ToString("dd"), typeof(string));
                }
                var lstOT = db.Tbl_DailyOverTime.Where(m => m.DateOverTime >= firstMonth && m.DateOverTime <= lastMonth).ToList();
                var lstUser = GAMankuchiAll.Instance()._listAllStaff.Where(m => m.Dept == dept
                && m.Customer == customer).ToList();
                foreach (var item in lstLineGroup)
                {
                    if (!string.IsNullOrEmpty(item.Group))
                    {
                        //Plan
                        var arrPlan = new List<object>();
                        arrPlan.Add(item.Group);
                        arrPlan.Add("Plan");
                        double plan = 0;
                        for (var date = firstMonth; date <= lastMonth; date = date.AddDays(1))
                        {
                            var fc = db.Tbl_ForecastOT.Where(m => m.DAY == date
                            && m.CUSTOMER == customer
                            && m.DEPT == dept
                            && m.JOB == item.Group
                            ).FirstOrDefault();
                            if (fc != null)
                            {
                                plan += fc.TIME_OT;

                            }
                            arrPlan.Add(plan);
                        }

                        dt.Rows.Add(arrPlan.ToArray());

                        //Actual
                        double actual = 0;
                        var arrActual = new List<object>();
                        arrActual.Add(item.Group);
                        arrActual.Add("Actual");
                        for (var date = firstMonth; date <= lastMonth; date = date.AddDays(1))
                        {
                            var fc = (from r in lstOT
                                      join k in lstUser on r.Code equals k.AltCode
                                      where
                                      (r.DateOverTime == date)
                                      && (r.TimeOTDept != 0 || r.TimeRegisted != 0)
                                      && k.Job == item.Group
                                      select new
                                      {
                                          TimeOTDept = r.TimeOTDept
                                      }).Sum(m => m.TimeOTDept);
                            actual += fc;
                            arrActual.Add(actual);
                        }
                        dt.Rows.Add(arrActual.ToArray());

                        // balance
                        var arrBalance = new List<object>();
                        arrBalance.Add(item.Group);
                        arrBalance.Add("Balance");
                        int index = 2;
                        for (var date = firstMonth; date <= lastMonth; date = date.AddDays(1))
                        {
                            double planDt = double.Parse(string.IsNullOrEmpty(arrPlan[index].ToString()) ? "0" : arrPlan[index].ToString());
                            double actualDt = double.Parse(string.IsNullOrEmpty(arrActual[index].ToString()) ? "0" : arrActual[index].ToString());
                            var balance = actualDt - planDt;
                            arrBalance.Add(balance);
                            index++;
                        }
                        dt.Rows.Add(arrBalance.ToArray());
                    }
                }

                return dt;
            }

        }

        public static List<HistoryDetailOverTime> GetListUserWillRegister(string CustomerSelect,
            string dept,
            string line,
            DateTime DateSelect,
            string ShiftSelect,
            string Code = ""
            )
        {
            using (var db = new DBContext())
            {
                List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstHumanSearch = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();
                var lstSupporter = new List<Tbl_GroupSupporter>();
                if (!string.IsNullOrEmpty(Code))
                {
                    lstHumanSearch = GAMankuchi.Instance()._listCurrentStaff.Where(m => m.AltCode == Code).ToList();
                    if (lstHumanSearch == null) return null;
                }
                else
                {
                    List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstHumanDept = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();
                    if (dept == "PD")
                    {
                        lstHumanDept = GAMankuchi.Instance()._listCurrentStaff.Where(x => x.Dept == dept && x.Customer != null && x.Customer.Contains(CustomerSelect)).ToList();
                    }
                    else
                    {
                        lstHumanDept = GAMankuchi.Instance()._listCurrentStaff.Where(x => x.Dept == dept).ToList();
                    }
                    List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstHumanSearchLine = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();

                    // Nếu là PD và có chọn Line
                    var lstLine = line.Split(',').ToList();

                    if (!string.IsNullOrEmpty(line))
                    {
                        foreach (var item in lstLine)
                        {
                            var lstHumanLine = lstHumanDept.Where(x => x.GroupProcess == item.TrimStart()).ToList();
                            lstHumanSearchLine.AddRange(lstHumanLine);

                            lstSupporter.AddRange(db.Tbl_GroupSupporters.Where(m => m.GroupLine == item.TrimStart() && m.Customer == CustomerSelect).ToList());
                        }
                    }
                    else
                    {
                        lstHumanSearchLine.AddRange(lstHumanDept);
                    }

                    // Load dữ liệu ca LV trên MAnkichi
                    var lstCaLV = GetListCaLV(DateSelect);

                    if (ShiftSelect == "ALL" || ShiftSelect == "")
                    {
                        lstHumanSearch = lstHumanSearchLine;
                    }
                    else
                    {
                        var lstMasterShift = db.Tbl_MasterShift.Where(x => x.Shift.Contains(ShiftSelect)).ToList();
                        var lstHumanCaLVSelect = (from k in lstCaLV
                                                  join s in lstMasterShift on k.ToDayShiftCode equals s.ShiftCode
                                                  select k).ToList();

                        lstHumanSearch = (from k in lstHumanSearchLine
                                          join s in lstHumanCaLVSelect on k.AltCode equals s.Code
                                          select k).ToList();
                    }

                }
                // add list support
                lstHumanSearch.AddRange((from k in lstSupporter
                                         join s in GAMankuchi.Instance()._listCurrentStaff on k.StaffCode equals s.AltCode
                                         select s).ToList());

                //Lọc duplicate suport
                lstHumanSearch = lstHumanSearch.GroupBy(item => item.AltCode)
                                      .Select(g=>g.First()).ToList();

                var lstCode = lstHumanSearch.Select(m => m.AltCode).ToList();
                // Load lại dữ liệu đã đang ký tăng ca trên hệ thống
                var firstMonth = new DateTime(DateSelect.Year, DateSelect.Month, 1);
                var endMonth = DateSelect.AddMonths(1).AddDays(-1);
                var lstDailyRegisted = db.Tbl_DailyOverTime.Where(x => x.DateOverTime == DateSelect && lstCode.Contains(x.Code)).ToList();
                var lstOTAllMonth = db.Tbl_DailyOverTime.Where(m => m.DateOverTime >= firstMonth && m.DateOverTime <= endMonth
                    && lstCode.Contains(m.Code))
                    .GroupBy(m => m.Code)
                    .Select(m => new
                    {
                        Code = m.Key,
                        TotalOverTime = m.Sum(x => x.TimeOTDept)
                    }).ToList();
                var lstRetrict = db.Tbl_RestrictOT.Where(x => lstCode.Contains(x.Code) &&
                (x.DateLimit == null || x.DateLimit.Value >= DateSelect)).ToList();
                var lst = new List<HistoryDetailOverTime>();
                foreach (var t1 in lstHumanSearch)
                {
                    var timeRegister = lstDailyRegisted.Where(m => m.Code == t1.AltCode).FirstOrDefault();
                    var OT = lstOTAllMonth.Where(m => m.Code == t1.AltCode).FirstOrDefault();
                    var TotalOT = OT == null ? 0 : OT.TotalOverTime;
                    var Block = false;
                    if (!string.IsNullOrEmpty(t1.Direct_Indirect))
                    {
                        if ((TotalOT >= Constants.MaxOverTimeGianTiep && t1.Direct_Indirect.Contains("Gián tiếp"))
                            || (TotalOT >= Constants.MaxOverTime && t1.Direct_Indirect.Contains("Trực tiếp")))
                        {
                            Block = true;
                        }
                    }
                    if (t1.AltCode == "U61587")
                    {
                        Console.Write("");
                    }
                    lst.Add(new HistoryDetailOverTime()
                    {
                        Code = t1.AltCode,
                        Name = t1.Name,
                        Direct = t1.Direct_Indirect.TrimStart(),
                        Dept = t1.Dept,
                        Customer = t1.Customer,
                        Line = t1.GroupProcess,
                        TotalOT = TotalOT,
                        TimeRegisted = timeRegister == null ? null : timeRegister.TimeRegisted,
                        Restrict = lstRetrict.Any(m => m.Code == t1.AltCode),
                        Block = Block,
                        Reason = timeRegister == null ? "" : timeRegister.Reason,
                        Status = lstSupporter.FirstOrDefault(m => m.StaffCode == t1.AltCode) != null ? STATUS.SUPPORT : ""
                    });
                }
                return lst.OrderBy(m => m.Code).ToList();
            }
        }


        public static List<AdjustOverTime> LoadAllListToAdjustOverTime(DateTime dateSelect,
            string Dept,
            string Customer,
            string line)
        {
            using (var db = new DBContext())
            {
                List<AdjustOverTime> lstResult = new List<AdjustOverTime>();
                var lstAdjustSearch = new List<AdjustOverTime>();
                TimeSpan tsNull = new TimeSpan(0, 0, 0);
                var lstAllDailyOT = db.Tbl_DailyOverTime.Where(x => x.DateOverTime == dateSelect).ToList();
                lstAllDailyOT = lstAllDailyOT.OrderBy(x => x.Code).ToList();
                lstResult = (from d in lstAllDailyOT
                             join h in GAMankuchiAll.Instance()._listAllStaff on d.Code equals h.AltCode
                             select new AdjustOverTime
                             {
                                 Code = d.Code,
                                 FullName = h.Name,
                                 Dept = h.Dept,
                                 Position = h.Position,
                                 Customer = h.Customer,
                                 Direct = h.Direct_Indirect,
                                 Process = h.GroupProcess,
                                 Shift = d.CaLV,
                                 TimeIn = d.TimeIn != null ? d.TimeIn.Value : tsNull,
                                 TimeOut = d.TimeOut != null ? d.TimeOut.Value : tsNull,
                                 RegisOT = d.TimeRegisted != null ? (double)d.TimeRegisted : 0,
                                 TimeOTPreShift = d.TimeOTPreshift != null ? (double)d.TimeOTPreshift : 0,
                                 TimeFinger = d.TimeOTFinger != null ? (double)d.TimeOTFinger : 0,
                                 TimeDept = d.TimeOTDept != null ? (double)d.TimeOTDept : 0,
                                 TotalOT = d.TotalOT != null ? (double)d.TotalOT : 0,
                                 Balance = d.Balance != null ? (double)d.Balance : 0,
                                 Comment = d.Comment
                             }).ToList();
                var lstManager = lstResult.Where(x => x.Position.Contains("Manager")).ToList();
                foreach (var item in lstManager)
                {
                    item.TotalOT = 0;
                    item.TimeFinger = 0;
                    item.Balance = 0;
                    item.RegisOT = 0;
                }

                List<AdjustOverTime> lstSearchDept = new List<AdjustOverTime>();
                if (Dept == "PD")
                {
                    lstSearchDept = lstResult.Where(x => x.Dept == Dept && x.Customer != null && x.Customer.Contains(Customer)).ToList();
                }
                else
                {
                    lstSearchDept = lstResult.Where(x => x.Dept == Dept).ToList();
                }

                var lstLine = line.Split(',').ToList();
                if (!string.IsNullOrEmpty(line))
                {
                    foreach (var item in lstLine)
                    {
                        var lstSearchLine = lstSearchDept.Where(x => x.Line == item.TrimStart()).ToList();
                        lstAdjustSearch.AddRange(lstSearchLine);
                    }
                }
                else
                {
                    lstAdjustSearch.AddRange(lstSearchDept);
                }
                var lstCode = lstAdjustSearch.Select(m => m.Code).ToList();
                var firstMonth = new DateTime(dateSelect.Year, dateSelect.Month, 1);
                var endMonth = dateSelect.AddMonths(1).AddDays(-1);
                var lstOTAllMonth = db.Tbl_DailyOverTime.Where(m => m.DateOverTime >= firstMonth && m.DateOverTime <= endMonth
                    && lstCode.Contains(m.Code))
                   .GroupBy(m => m.Code)
                   .Select(m => new
                   {
                       Code = m.Key,
                       TotalOverTime = m.Sum(x => x.TimeOTDept)
                   }).ToList();

                var list = new List<AdjustOverTime>();
                foreach (var item in lstAdjustSearch)
                {
                    var ot = lstOTAllMonth.Where(m => m.Code == item.Code).FirstOrDefault();
                    if (ot != null)
                    {
                        item.Accumulated = ot.TotalOverTime;
                    }
                    list.Add(item);
                }
                return list;
            }
        }

        public static Tbl_HistoryUpdateOT GetAdjustOT(string Code, DateTime DateAdjust)
        {
            using (var db = new DBContext())
            {
                var register = db.Tbl_HistoryUpdateOT.Where(x => x.DateAdjust == DateAdjust && x.Code == Code).FirstOrDefault();
                if (register != null) return register;
                var findRegisOT = db.Tbl_DailyOverTime.FirstOrDefault(x => x.Code == Code
                && x.DateOverTime == DateAdjust);
                if (findRegisOT != null)
                {
                    return new Tbl_HistoryUpdateOT()
                    {
                        TimeIn = findRegisOT.TimeIn.ToString(),
                        TimeOut = findRegisOT.TimeOut.ToString(),
                        TimeOTRegisted = 0,
                        TimeOTUpdate = 0,
                        Reason = ""
                    };
                }

                return null;
            }
        }

        public static string SaveAdjustOT(Tbl_HistoryUpdateOT ot)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var adjust = db.Tbl_HistoryUpdateOT.Where(m => m.Code == ot.Code
                    && m.DateAdjust == ot.DateAdjust).FirstOrDefault();
                    if (adjust != null)
                    {
                        adjust.TimeIn = ot.TimeIn;
                        adjust.TimeOut = ot.TimeOut;
                        adjust.Reason = ot.Reason;
                        adjust.TimeOTUpdate = ot.TimeOTUpdate;
                        adjust.TimeOTRegisted = ot.TimeOTRegisted;
                    }
                    else
                    {
                        db.Tbl_HistoryUpdateOT.Add(ot);
                    }
                    db.SaveChanges();
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public static int CounTotalNeedConfirm(List<AdjustOverTime> lstAdjustSearch)
        {
           return lstAdjustSearch.Where(x => x.TotalOT != x.RegisOT).ToList().Count();   
        }

        public static int CountConfirmed(List<AdjustOverTime> lstAdjustSearch){
            var count = lstAdjustSearch.Where(x => x.TotalOT != x.RegisOT && !string.IsNullOrEmpty(x.Comment)).ToList().Count();
            return count;
        }

        public static int CountWaitConfirm(List<AdjustOverTime> lstAdjustSearch)
        {
            var count = lstAdjustSearch.Where(x => x.Balance != 0 && x.TotalOT != x.RegisOT && string.IsNullOrEmpty(x.Comment)).ToList();
            return count.Count;
        }

        public static List<AdjustOverTime> LoadAllListToAdjustOverTime(DateTime dateSelect, string Dept)
        {
            List<AdjustOverTime> lstResult = new List<AdjustOverTime>();

            using (var db = new DBContext())
            {
                TimeSpan tsNull = new TimeSpan(0, 0, 0);
                var lstAllDailyOT = db.Tbl_DailyOverTime.Where(x => x.DateOverTime == dateSelect).ToList();

                lstResult = (from d in lstAllDailyOT
                             join h in GAMankuchiAll.Instance()._listAllStaff on d.Code equals h.AltCode
                             where h.Dept == Dept
                             select new AdjustOverTime
                             {
                                 Code = d.Code,
                                 FullName = h.Name,
                                 Dept = h.Dept,
                                 Position = h.Position,
                                 Customer = h.Customer,
                                 Direct = h.Direct_Indirect,
                                 //Line = h.Line,
                                 Shift = h.CaLV,
                                 TimeIn = d.TimeIn != null ? d.TimeIn.Value : tsNull,
                                 TimeOut = d.TimeOut != null ? d.TimeOut.Value : tsNull,
                                 RegisOT = d.TimeRegisted != null ? (double)d.TimeRegisted : 0,
                                 TimeOTPreShift = d.TimeOTPreshift != null ? (double)d.TimeOTPreshift : 0,
                                 TimeFinger = d.TimeOTFinger != null ? (double)d.TimeOTFinger : 0,
                                 TimeDept = d.TimeOTDept != null ? (double)d.TimeOTDept : 0,
                                 TotalOT = d.TotalOT != null ? (double)d.TotalOT : 0,
                                 Balance = d.Balance != null ? (double)d.Balance : 0,
                                 Comment = d.Comment,
                             }).ToList();
                var lstCode = lstResult.Select(m => m.Code).ToList();
                var firstMonth = new DateTime(dateSelect.Year, dateSelect.Month, 1);
                var endMonth = dateSelect.AddMonths(1).AddDays(-1);
                var lstOTAllMonth = db.Tbl_DailyOverTime.Where(m => m.DateOverTime >= firstMonth && m.DateOverTime <= endMonth
                    && lstCode.Contains(m.Code))
                   .GroupBy(m => m.Code)
                   .Select(m => new
                   {
                       Code = m.Key,
                       TotalOverTime = m.Sum(x => x.TimeOTDept)
                   }).ToList();

                var list = new List<AdjustOverTime>();
                foreach (var item in lstResult)
                {
                    var ot = lstOTAllMonth.Where(m => m.Code == item.Code).FirstOrDefault();
                    if (ot != null)
                    {
                        item.Accumulated = ot.TotalOverTime;
                    }
                    list.Add(item);
                }
                return list;
            }
        }

        internal static void UpdateShiftCa(DataTable dataTable, int month, int year)
        {
            DataTable convertDataUpdate = ConvertDataUpdateShiftCa(dataTable, month, year);
            using(var context = new DBContext())
            {

                var dataInput = new SqlParameter("@Data", convertDataUpdate)
                {
                    TypeName = "dbo.udt_UpdateShiftCa",
                    SqlDbType = SqlDbType.Structured
                };

                context.Database.ExecuteSqlCommand("exec UpdateShiftCa @Data", dataInput);
            }

        }

        private static DataTable ConvertDataUpdateShiftCa(DataTable data, int month, int year)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("mMonth", typeof(int));
            dataTable.Columns.Add("mYear", typeof (int));
            dataTable.Columns.Add("StaffCode",typeof(string));
            for(int i =1; i < 32; i++)
            {
                dataTable.Columns.Add($"D{i}", typeof(string));
            }
            for(int row = 9; row<data.Rows.Count;row++)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = month;
                dataRow[1] = year;
                dataRow[2] = ConvertStaffCode(data.Rows[row].Field<object>(1).ToString());// staff code
                for(int day = 3; day < data.Columns.Count; day++)
                {
                    dataRow[day] = data.Rows[row].Field<object>(day) ==null ? "" : data.Rows[row].Field<object>(day).ToString();
                }

                dataTable.Rows.Add(dataRow);
            }
            var last = dataTable.Rows[dataTable.Rows.Count-1];
            return dataTable;
        }

        private static string ConvertStaffCode(string staffCode)
        {
            int resutl;
            if(int.TryParse(staffCode, out resutl))
            {
                if(staffCode.Length <5)
                    return staffCode.PadLeft(5, '0');
            }
            return staffCode;
        }

        internal static bool ShiftCaExist(int month, int year)
        {
            SQLHelper.ConnectString(new OvertimeConfig());
            var value = SQLHelper.ExecQueryData<int>($"Select count(*) from [OverTime].[dbo].[StaffShift] where [mMonth] ={month} and [mYear] = {year}").First();
            return value > 0;
        }

        internal static List<Tbl_ShiftWorking_Entity> GetShiftWorking(int year, int month)
        {
            try
            {
                List<ShiftEntity> source = new List<ShiftEntity>();
                List<HolidayEntity> source2 = new List<HolidayEntity>();
                using (var context = new DBContext())
                {
                    string sql = $"SELECT * FROM [OverTime].[dbo].[StaffShift] where mYear = '{year}' AND mMonth = '{month}'";
                    source = context.Database.SqlQuery<ShiftEntity>(sql, new object[1] { "" }).ToList();
                }

                List<Tbl_ShiftWorking_Entity> list = source.Select((ShiftEntity r) => new Tbl_ShiftWorking_Entity
                {
                    Code = r.StaffCode,
                    Year = r.mYear,
                    Month = r.mMonth,
                    Day1 = r.D1,
                    Day2 = r.D2,
                    Day3 = r.D3,
                    Day4 = r.D4,
                    Day5 = r.D5,
                    Day6 = r.D6,
                    Day7 = r.D7,
                    Day8 = r.D8,
                    Day9 = r.D9,
                    Day10 = r.D10,
                    Day11 = r.D11,
                    Day12 = r.D12,
                    Day13 = r.D13,
                    Day14 = r.D14,
                    Day15 = r.D15,
                    Day16 = r.D16,
                    Day17 = r.D17,
                    Day18 = r.D18,
                    Day19 = r.D19,
                    Day20 = r.D20,
                    Day21 = r.D21,
                    Day22 = r.D22,
                    Day23 = r.D23,
                    Day24 = r.D24,
                    Day25 = r.D25,
                    Day26 = r.D26,
                    Day27 = r.D27,
                    Day28 = r.D28,
                    Day29 = r.D29,
                    Day30 = r.D30,
                    Day31 = r.D31
                }).ToList();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
