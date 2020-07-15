namespace TarkariWala.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Coupen")]
    public partial class Coupen
    {
        public int CoupenID { get; set; }

        [StringLength(50)]
        public string CoupenName { get; set; }

        [StringLength(50)]
        public string Amount { get; set; }

        [StringLength(8)]
        public string CoupenCode { get; set; }
    }
}
