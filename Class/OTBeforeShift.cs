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

namespace OverTime
{
    public class OTBeforeShift
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public string Day_1 { get; set; }
        public string Day_2 { get; set; }
        public string Day_3 { get; set; }
        public string Day_4 { get; set; }
        public string Day_5 { get; set; }
        public string Day_6 { get; set; }
        public string Day_7 { get; set; }
        public string Day_8 { get; set; }
        public string Day_9 { get; set; }
        public string Day_10 { get; set; }

        public string Day_11 { get; set; }
        public string Day_12 { get; set; }
        public string Day_13 { get; set; }
        public string Day_14 { get; set; }
        public string Day_15 { get; set; }
        public string Day_16 { get; set; }
        public string Day_17 { get; set; }
        public string Day_18 { get; set; }
        public string Day_19 { get; set; }
        public string Day_20 { get; set; }

        public string Day_21 { get; set; }
        public string Day_22 { get; set; }
        public string Day_23 { get; set; }
        public string Day_24 { get; set; }
        public string Day_25 { get; set; }
        public string Day_26 { get; set; }
        public string Day_27 { get; set; }
        public string Day_28 { get; set; }
        public string Day_29 { get; set; }
        public string Day_30 { get; set; }

        public string Day_31 { get; set; }

        public string Today { get; set; }


        public static List<OTBeforeShift> GetListOTBeforeShift(string path)
        {
            List<OTBeforeShift> lstResult = new List<OTBeforeShift>();
            Workbook wbFromMaster = new Workbook();
            wbFromMaster.LoadFromFile(path);
            Worksheet sheet = wbFromMaster.Worksheets[0];

            for (int i = 3; i <= sheet.Rows.Count(); i++)
            {
                var res = new OTBeforeShift();
                string Code = sheet.Range[i, 2].DisplayedText != null ? sheet.Range[i, 2].DisplayedText : "";
                res.Code = Code.PadLeft(5, '0');
                if(!string.IsNullOrEmpty(res.Code))
                {
                    res.Name = sheet.Range[i, 3].DisplayedText != null ? sheet.Range[i, 3].DisplayedText : "";

                    res.Day_1 = sheet.Range[i, 4].DisplayedText != null ? sheet.Range[i, 4].DisplayedText : "";
                    res.Day_2 = sheet.Range[i, 5].DisplayedText != null ? sheet.Range[i, 5].DisplayedText : "";
                    res.Day_3 = sheet.Range[i, 6].DisplayedText != null ? sheet.Range[i, 6].DisplayedText : "";
                    res.Day_4 = sheet.Range[i, 7].DisplayedText != null ? sheet.Range[i, 7].DisplayedText : "";
                    res.Day_5 = sheet.Range[i, 8].DisplayedText != null ? sheet.Range[i, 8].DisplayedText : "";
                    res.Day_6 = sheet.Range[i, 9].DisplayedText != null ? sheet.Range[i, 9].DisplayedText : "";
                    res.Day_7 = sheet.Range[i, 10].DisplayedText != null ? sheet.Range[i, 10].DisplayedText : "";
                    res.Day_8 = sheet.Range[i, 11].DisplayedText != null ? sheet.Range[i, 11].DisplayedText : "";
                    res.Day_9 = sheet.Range[i, 12].DisplayedText != null ? sheet.Range[i, 12].DisplayedText : "";
                    res.Day_10 = sheet.Range[i, 13].DisplayedText != null ? sheet.Range[i, 13].DisplayedText : "";


                    res.Day_11 = sheet.Range[i, 14].DisplayedText != null ? sheet.Range[i, 14].DisplayedText : "";
                    res.Day_12 = sheet.Range[i, 15].DisplayedText != null ? sheet.Range[i, 15].DisplayedText : "";
                    res.Day_13 = sheet.Range[i, 16].DisplayedText != null ? sheet.Range[i, 16].DisplayedText : "";
                    res.Day_14 = sheet.Range[i, 17].DisplayedText != null ? sheet.Range[i, 17].DisplayedText : "";
                    res.Day_15 = sheet.Range[i, 18].DisplayedText != null ? sheet.Range[i, 18].DisplayedText : "";
                    res.Day_16 = sheet.Range[i, 19].DisplayedText != null ? sheet.Range[i, 19].DisplayedText : "";
                    res.Day_17 = sheet.Range[i, 20].DisplayedText != null ? sheet.Range[i, 20].DisplayedText : "";
                    res.Day_18 = sheet.Range[i, 21].DisplayedText != null ? sheet.Range[i, 21].DisplayedText : "";
                    res.Day_19 = sheet.Range[i, 22].DisplayedText != null ? sheet.Range[i, 22].DisplayedText : "";
                    res.Day_20 = sheet.Range[i, 23].DisplayedText != null ? sheet.Range[i, 23].DisplayedText : "";

                    res.Day_21 = sheet.Range[i, 24].DisplayedText != null ? sheet.Range[i, 24].DisplayedText : "";
                    res.Day_22 = sheet.Range[i, 25].DisplayedText != null ? sheet.Range[i, 25].DisplayedText : "";
                    res.Day_23 = sheet.Range[i, 26].DisplayedText != null ? sheet.Range[i, 26].DisplayedText : "";
                    res.Day_24 = sheet.Range[i, 27].DisplayedText != null ? sheet.Range[i, 27].DisplayedText : "";
                    res.Day_25 = sheet.Range[i, 28].DisplayedText != null ? sheet.Range[i, 28].DisplayedText : "";
                    res.Day_26 = sheet.Range[i, 29].DisplayedText != null ? sheet.Range[i, 29].DisplayedText : "";
                    res.Day_27 = sheet.Range[i, 30].DisplayedText != null ? sheet.Range[i, 30].DisplayedText : "";
                    res.Day_28 = sheet.Range[i, 31].DisplayedText != null ? sheet.Range[i, 31].DisplayedText : "";
                    res.Day_29 = sheet.Range[i, 32].DisplayedText != null ? sheet.Range[i, 32].DisplayedText : "";
                    res.Day_30 = sheet.Range[i, 33].DisplayedText != null ? sheet.Range[i, 33].DisplayedText : "";

                    res.Day_31 = sheet.Range[i, 34].DisplayedText != null ? sheet.Range[i, 34].DisplayedText : "";

                    lstResult.Add(res);
                }
            }
            return lstResult;
        }
    }


    public class HistoryDetailOverTime
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Position { get; set; }
        public string Customer { get; set; }
        public string Direct { get; set; }
        public int Day { get; set; }
        public double ActualOT { get; set; }
        public double TotalOT { get; set; }
        public string Line { get; set; }
        public bool Restrict { get; set; }
        public double? TimeRegisted { get; set; }
        public bool Block { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
    }

    public class SummaryOTFullInfo
    {
        public string Code { get; set; }
        public string FullName { get; set; }
        public string Dept { get; set; }
        public string Position { get; set; }
        public string Customer { get; set; }
        public string Direct { get; set; }
        public double TotalOverTime { get; set; }
        public string Actual { get; set; }
    }
}
