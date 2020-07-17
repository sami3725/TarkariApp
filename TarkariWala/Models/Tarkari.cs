namespace TarkariWala.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Tarkari : DbContext
    {
        public Tarkari()
            : base("name=Tarkari")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AdminUser> AdminUsers { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Coupen> Coupens { get; set; }
        public virtual DbSet<DeliveryInformation> DeliveryInformations { get; set; }
        public virtual DbSet<Deliveryman> Deliverymen { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<GifCard> GifCards { get; set; }
        public virtual DbSet<Municipality> Municipalities { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSubCategory> ProductSubCategories { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
