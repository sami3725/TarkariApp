namespace TarkariWala.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Comments = new HashSet<Comment>();
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
            Carts = new HashSet<Cart>();
        }

        public int ClientID { get; set; }

        [StringLength(50)]
        public string ClientName { get; set; }

        public int? AddressID { get; set; }

        public int? PermanentAddressID { get; set; }

        public int? TemporaryAddressID { get; set; }

        [StringLength(15)]
        public string PhoneNo { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Image { get; set; }

        [StringLength(50)]
        public string DateOfBirth { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(8)]
        public string Code { get; set; }

        [StringLength(8)]
        public string RefferClientCode { get; set; }

        public virtual Address Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
