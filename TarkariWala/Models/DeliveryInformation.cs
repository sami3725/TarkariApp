namespace TarkariWala.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeliveryInformation")]
    public partial class DeliveryInformation
    {
        public int DeliveryInformationID { get; set; }

        public int? OrderID { get; set; }

        public int? DeliverymansID { get; set; }

        [StringLength(50)]
        public string Signature { get; set; }

        public virtual Deliveryman Deliveryman { get; set; }

        public virtual Order Order { get; set; }
    }
}
