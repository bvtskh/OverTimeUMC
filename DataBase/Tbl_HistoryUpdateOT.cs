namespace OverTime.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_HistoryUpdateOT
    {
        
        public int Id { get; set; }

        public long? RequestNo { get; set; }

        public DateTime? TimeUpdate { get; set; }

        
        public DateTime DateAdjust { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(10)]
        public string Dept { get; set; }

        [StringLength(20)]
        public string TimeIn { get; set; }

        [StringLength(20)]
        public string TimeOut { get; set; }

        public double? TimeOTRegisted { get; set; }

        
        public double TimeOTUpdate { get; set; }

        [StringLength(200)]
        public string Reason { get; set; }

        [StringLength(10)]
        public string UserUpdate { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(100)]
        public string Approve { get; set; }
    }
}
