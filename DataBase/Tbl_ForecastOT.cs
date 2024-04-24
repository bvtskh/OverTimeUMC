namespace OverTime.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ForecastOT
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime DAY { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string DEPT { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string CUSTOMER { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string JOB { get; set; }

        public double TIME_OT { get; set; }
    }
}
