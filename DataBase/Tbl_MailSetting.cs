namespace OverTime.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_MailSetting
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Dept { get; set; }

        [StringLength(100)]
        public string EmailCC { get; set; }
    }
}
