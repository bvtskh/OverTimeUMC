namespace OverTime
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkOrder
    {
        [StringLength(64)]
        public string ID { get; set; }

        [Required]
        [StringLength(10)]
        public string OrderNo { get; set; }

        [Required]
        [StringLength(64)]
        public string ProductID { get; set; }

        public int Qty { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EstimatedTime { get; set; }

        public DateTime UpdTime { get; set; }
    }
}
