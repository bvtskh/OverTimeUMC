namespace OverTime
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(64)]
        public string FullName { get; set; }

        [Required]
        [StringLength(64)]
        public string Dept { get; set; }

        [StringLength(64)]
        public string Email { get; set; }

        [StringLength(64)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        [StringLength(64)]
        public string Permission { get; set; }
    }
}
