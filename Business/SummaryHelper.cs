using OverTime.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverTime.Business
{
    public static class SummaryHelper
    {
        public static List<HistoryDetailOverTime> GetListSummaryDetailOverTime(DateTime dateSelect, string Dept)
        {
            var firstDayMonth = new DateTime(dateSelect.Year, dateSelect.Month, 1);
            var lastDayMonth = dateSelect.AddMonths(1).AddDays(-1);
            List<HistoryDetailOverTime> lstHistoryOT = new List<HistoryDetailOverTime>();
            var lstHumanInfoUsing = GAMankuchiAll.Instance()._listAllStaff;
            List<Tbl_DailyOverTime> lstSummary = new List<Tbl_DailyOverTime>();
            List<Tbl_HistoryUpdateOT> lstSpecialOT = new List<Tbl_HistoryUpdateOT>();
            using (var db = new DBContext())
            {
                lstSummary = db.Tbl_DailyOverTime.Where(m => m.DateOverTime >= firstDayMonth
                && m.DateOverTime <= lastDayMonth).ToList();
                lstSpecialOT = db.Tbl_HistoryUpdateOT.Where(m => m.DateAdjust >= firstDayMonth 
                && m.DateAdjust <= lastDayMonth 
                && m.Approve != null).ToList();
                foreach(var user in lstSpecialOT)
                {
                    var exist = lstSummary.Where(m => m.Code == user.Code && m.DateOverTime == user.DateAdjust).FirstOrDefault();
                    if(exist != null)
                    {
                        exist.TimeOTDept = user.TimeOTUpdate;
                    }
                    else
                    {
                        lstSummary.Add(new Tbl_DailyOverTime()
                        {
                            Code = user.Code,
                            DateOverTime = user.DateAdjust,
                            TimeOTDept = user.TimeOTUpdate
                        });
                    }
                }
                lstHistoryOT = (from s in lstSummary
                                join h in lstHumanInfoUsing on s.Code equals h.AltCode
                                select new HistoryDetailOverTime
                                {
                                    Code = h.AltCode,
                                    Name = h.Name,
                                    Dept = h.Dept,
                                    Position = h.Position,
                                    Customer = h.Customer,
                                    Direct = h.Direct_Indirect,
                                    Day = s.DateOverTime.Day,
                                    ActualOT = s.TimeOTDept
                                }).OrderBy(r => r.Code).ToList();
            }
            return lstHistoryOT;

        }

    }
}
