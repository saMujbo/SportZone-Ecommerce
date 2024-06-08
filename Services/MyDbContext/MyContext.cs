using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Services.MyDbContext
{
    public class MyContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("MyDatabase");
        }

        public DbSet<Entidades.Shoe> Shoes { get; set; }
        public DbSet<Entidades.Invoice> Invoices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Entidades.Customer> Customers { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidades.Shoe>()
                .HasOne(shoe => shoe.Category)
                .WithMany(category => category.Shoes)
                .HasForeignKey(shoe => shoe.CategoryId);

            modelBuilder.Entity<Entidades.Invoice>()
              .HasOne(invoice => invoice.Customer)
              .WithMany(customer => customer.Invoices)
              .HasForeignKey(invoice => invoice.CostumerId);
            
            modelBuilder.Entity<PurchaseDetail>()
              .HasOne(purchaseDetail => purchaseDetail.Customer)
              .WithMany(customer => customer.PurchaseDetails)
              .HasForeignKey(purchaseDetail => purchaseDetail.CustomerId);

        }
    }
}
