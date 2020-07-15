namespace TarkariWala.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int ProductID { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public int? ProductSubCategoryID { get; set; }

        public int? SuppliersID { get; set; }

        [StringLength(50)]
        public string Quantity { get; set; }

        [StringLength(50)]
        public string Discount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ProductSubCategory ProductSubCategory { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
