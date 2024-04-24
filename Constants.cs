using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverTime
{
    public static class Constants
    {
        public static int MaxOverTime = 999; // 30
        public static int MaxOverTimeGianTiep = 999; //25
        public static int TimeEnableModify = 9; // 9
        public static int MaxOverTimeInDay = 999;
        public static string DAY = "ddd dd";
    }
    public static class STATUS
    {
        public static string BLOCK = "BLOCK";
        public static string RESTRICT = "RESTRICT";
        public static string SUPPORT = "SUPPORT";
    }
    public enum AlarmYellow
    {
        GianTiep = 25,
        TrucTiep =30
    }
}
