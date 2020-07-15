namespace TarkariWala.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment
    {
        public int PaymentID { get; set; }

        public int? OrderID { get; set; }

        public int? ClientID { get; set; }

        [StringLength(8)]
        public string CoupenCode { get; set; }

        [StringLength(50)]
        public string PayedAmount { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(8)]
        public string Code { get; set; }

        public virtual Client Client { get; set; }

        public virtual Order Order { get; set; }
    }
}
