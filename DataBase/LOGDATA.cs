namespace OverTime.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOGDATA")]
    public partial class LOGDATA
    {
        [Key]
        public int LogId { get; set; }

        [StringLength(100)]
        public string CategoryId { get; set; }

        [StringLength(50)]
        public string OperateAccount { get; set; }

        public int? ModuleId { get; set; }

        [StringLength(1000)]
        public string ModuleName { get; set; }

        [StringLength(50)]
        public string HostName { get; set; }

        [StringLength(50)]
        public string IPAddress { get; set; }

        public int? ExecuteId { get; set; }

        [StringLength(200)]
        public string ExecuteName { get; set; }

        public DateTime LogTime { get; set; }
    }
}
