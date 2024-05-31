using NPOI.SS.Formula.Functions;
using OverTime.DataBase;
using PI_Lib.Entities;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverTime.Business
{
    public class BenefitOTHelper
    {
        internal static DataTable GetDetailBenefit(DataTable table, DateTime date, string dept, string staffCode, string typeUser, string[] arrayDept)
        {
            using(var context = new DBContext())
            {
                int numberDayInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                DateTime maxDayofMonth = new DateTime(date.Year, date.Month,numberDayInMonth);
                var benefitOTdata = context.Tbl_DailyOverTime.Where(w=>w.DateOverTime>=date && w.DateOverTime<= maxDayofMonth && w.TimeOTDept >=2).ToList();
  

                List<Tbl_Mankichi_Entity> humanInfo = GAMankuchiAll.Instance()._listAllStaff.Where(w => w.QuitJob == null).ToList();
                if (typeUser == "Salary" && dept == "ALL")
                {
                    var deptList = humanInfo.Select(s => s.Dept).Distinct().ToList();
                    GetBenefitOTDataRow(humanInfo, table, numberDayInMonth, deptList, staffCode, benefitOTdata);
                }
                else if (dept == "ALL" && typeUser != "Salary")
                {
                    List<Tbl_Mankichi_Entity> mankichiList = new List<Tbl_Mankichi_Entity>();
                    foreach (var subDept in arrayDept)
                    {
                        mankichiList.AddRange(humanInfo.Where(s => s.Dept == subDept).ToList());
                    }
                    GetBenefitOTDataRow(mankichiList, table, numberDayInMonth, arrayDept.ToList(),staffCode,benefitOTdata);
                }
                else
                {
                    var listUserOfDept = humanInfo.Where(w => w.Dept == dept).ToList();
                    GetBenefitOTDataRow(listUserOfDept, table, numberDayInMonth, new List<string> { dept }, staffCode, benefitOTdata);
                }

                return table;
            }           
        }

        private static void GetBenefitOTDataRow(List<Tbl_Mankichi_Entity> humanInfo, DataTable table, int numberDayInMonth, List<string> deptList, string staffCode, List<Tbl_DailyOverTime> benefitOTdata)
        {
            int index = 1;
            var sttIndex = 0;
            var codeIndex = 1;
            var nameIndex = 2;
            if (!string.IsNullOrEmpty(staffCode))
            {
                if (!IsNotHaveAccess(staffCode, humanInfo, deptList))
                {
                    UIMessageTip.ShowOk($"Nhân viên: {staffCode} không thuộc bộ phận: {deptList[0]}",3000);
                    return;
                }
                var data = benefitOTdata.Where(w=>w.Code == staffCode).ToList();
                if (data.Count > 0)
                {
                    var newRow = table.Rows.Add();
                    AddNewRow(newRow, data, index, sttIndex, codeIndex, nameIndex, numberDayInMonth);
                }
                else
                {
                    UIMessageTip.ShowOk($"Nhân viên:{staffCode} Không có dữ liệu bồ dưỡng tăng ca!", 3000);
                }
            }
            else
            {
                var humanOfDeptList = GetHumanOfDeptList(humanInfo, deptList).OrderBy(o=>o).ToList();
                foreach(var item in humanOfDeptList)
                {
                    var data = benefitOTdata.Where(w =>w.Code == item).ToList();
                    if(data.Count > 0)
                    {
                        var newRow = table.Rows.Add();
                        AddNewRow(newRow, data, index, sttIndex, codeIndex, nameIndex, numberDayInMonth);
                        index++;
                    }
                }
            }
        }

        private static bool IsNotHaveAccess(string staffCode, List<Tbl_Mankichi_Entity> humanInfo, List<string> deptList)
        {
            var data = humanInfo.Where(w => w.AltCode == staffCode).Select(s => s.Dept).FirstOrDefault();
            return deptList.Contains(data);
        }

        private static void AddNewRow(DataRow newRow, List<Tbl_DailyOverTime> data, int index, int sttIndex, int codeIndex, int nameIndex, int numberDayInMonth)
        {
            foreach (var item in data)
            {
                newRow[sttIndex] = index;
                newRow[codeIndex] = item.Code;
                newRow[nameIndex] = item.FullName;

                int dayOT = item.DateOverTime.Day;
                var dayIndex = dayOT * 2 + 1;
                var nightIndex = dayOT * 2 + 2;

                var dayOTshift = item.AdjustOTDayShift;
                var nightOTshift = item.AdjustOTNightShift;
                if (dayOTshift > 0)
                {
                    newRow[dayIndex] = "0.5";
                }
                if (nightOTshift > 0)
                {
                    newRow[nightIndex] = "0.5";
                }
            }
            newRow[numberDayInMonth * 2 + 3] = data.Where(w => w.AdjustOTDayShift > 0).Count() * 30;
            newRow[numberDayInMonth * 2 + 4] = data.Where(w => w.AdjustOTNightShift > 0).Count() * 30;

            newRow[numberDayInMonth * 2 + 5] = data.Where(w => w.AdjustOTDayShift > 0).Count() * 0.5;
            newRow[numberDayInMonth * 2 + 6] = data.Where(w => w.AdjustOTNightShift > 0).Count() * 0.5;

            newRow[numberDayInMonth * 2 + 7] = data.Where(w => w.AdjustOTDayShift > 0).Count() * 30 + data.Where(w => w.AdjustOTNightShift > 0).Count() * 30;
            newRow[numberDayInMonth * 2 + 8] = data.Where(w => w.AdjustOTNightShift > 0).Count() * 0.5 + data.Where(w => w.AdjustOTDayShift > 0).Count() * 0.5;
        }

        private static List<string> GetHumanOfDeptList(List<Tbl_Mankichi_Entity> humanInfo, List<string> deptList)
        {
            return humanInfo.Where(w=> deptList.Contains(w.Dept)).Select(s => s.AltCode).Distinct().ToList();
        }
    }
}
