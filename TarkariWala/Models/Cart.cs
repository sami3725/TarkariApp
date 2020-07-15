namespace TarkariWala.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public int CartID { get; set; }

        public int? ProductID { get; set; }

        public int? ClientID { get; set; }

        public virtual Product Product { get; set; }

        public virtual Client Client { get; set; }
    }
}
