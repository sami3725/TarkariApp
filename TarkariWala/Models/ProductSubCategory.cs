namespace TarkariWala.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductSubCategory")]
    public partial class ProductSubCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductSubCategory()
        {
            Products = new HashSet<Product>();
        }

        public int ProductSubCategoryID { get; set; }

        [StringLength(50)]
        public string ProductSubCategoryName { get; set; }

        [StringLength(50)]
        public string Rate { get; set; }

        public bool? Available { get; set; }

        [StringLength(50)]
        public string DisplayOrder { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
