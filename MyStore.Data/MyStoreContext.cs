using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyStore.Configuration.Entities;
using MyStore.Data;
using MyStore.Data.Entities.Entities;

namespace MyStore.Entities
{
    public class MyStoreContext : IdentityDbContext<ApiUser>
    {
        public MyStoreContext(DbContextOptions<MyStoreContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }        
        public DbSet<FidelityCard> FidelityCards { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne<Category>(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoryId_Product");

            modelBuilder.Entity<Customer>()
                .HasOne<FidelityCard>(fc => fc.FidelityCard)
                .WithOne(c => c.Customer)
                .HasForeignKey<FidelityCard>(fc => fc.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerId_FidelityCard");

            modelBuilder.Entity<CustomerOrder>().HasKey(co => new { co.CustomerId, co.OrderId });

            modelBuilder.Entity<CustomerOrder>()
                .HasOne<Customer>(c => c.Customer)
                .WithMany(ep => ep.CustomerOrders)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerId_CustomerOrder");

            modelBuilder.Entity<CustomerOrder>()
                .HasOne<Order>(s => s.Order)
                .WithMany(ep => ep.CustomerOrders)
                .HasForeignKey(s => s.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderId_CustomerOrder");

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
           
        }
    }
}