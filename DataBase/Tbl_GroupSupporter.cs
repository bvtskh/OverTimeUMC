namespace OverTime.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_GroupSupporter
    {
        [Key]
        [StringLength(50)]
        public string StaffCode { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupLine { get; set; }

        [Required]
        [StringLength(50)]
        public string Customer { get; set; }

        public DateTime UpdTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Updator { get; set; }
    }
}
