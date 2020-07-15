namespace TarkariWala.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GifCard")]
    public partial class GifCard
    {
        public int GifCardID { get; set; }

        [StringLength(50)]
        public string GifCardName { get; set; }

        [StringLength(50)]
        public string Amount { get; set; }

        [StringLength(8)]
        public string Code { get; set; }
    }
}
