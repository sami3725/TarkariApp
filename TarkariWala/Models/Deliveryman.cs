namespace TarkariWala.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Deliveryman")]
    public partial class Deliveryman
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Deliveryman()
        {
            DeliveryInformations = new HashSet<DeliveryInformation>();
        }

        [Key]
        public int DeliverymansID { get; set; }

        [StringLength(50)]
        public string DeliverymanName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string PhoneNo { get; set; }

        [StringLength(50)]
        public string CitizenshipNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryInformation> DeliveryInformations { get; set; }
    }
}
