using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverTime.DataBase
{
    [Table("DAYOFF")]
    public class DAYOFF
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string StaffCode { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string Dept { get; set; }

        public int? Month { get; set; }

        public int? Year { get; set; }

        public double? AnnualLeave { get; set; }

        public double? SpecialLeave { get; set; }

        public double? CompanyHoliday { get; set; }

        public double? NonPaidLeave { get; set; }

        public double? AccruedVacationDays { get; set; }

        public DateTime? UpdateTime {  get; set; }

        [StringLength(50)]
        public string HostName { get; set;}
    }
}
