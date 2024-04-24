using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverTime.DataBase
{
    public class Tbl_FCHumanOT
    {
        [Key, Column(Order = 0)]
        public DateTime DAY { get; set; }
        [Key, Column(Order = 1)]
        public string  DEPT { get; set; }
        [Key, Column(Order = 2)]
        public string  CUSTOMER { get; set; }
        [Key, Column(Order = 3)]
        public string  JOB { get; set; }
        public double  HUMAN_OT { get; set; }
    }
}
