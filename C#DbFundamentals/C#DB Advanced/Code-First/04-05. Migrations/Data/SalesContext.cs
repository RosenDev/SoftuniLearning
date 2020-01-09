using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=DESKTOP-CUCRL15\\SQLEXPRESS;Database=Sales;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigProduct(builder);
            ConfigCustomer(builder);
            ConfigStore(builder);
            ConfigSale(builder);
        }

        private static void ConfigSale(ModelBuilder builder)
        {
            builder.Entity<Sale>()
                            .HasKey(x => x.SaleId);
            builder.Entity<Sale>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.CustomerId);
            builder.Entity<Sale>()
                .HasOne(x => x.Product)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.ProductId);
            builder.Entity<Sale>()
                .HasOne(x => x.Store)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.StoreId);
            builder.Entity<Sale>()
                .Property(x => x.Date)
                .HasDefaultValueSql("getdate()");
        }

        private static void ConfigStore(ModelBuilder builder)
        {
            builder.Entity<Store>()
                .HasKey(x => x.StoreId);

            builder.Entity<Store>()
                .Property(x => x.Name)
                .HasMaxLength(80)
                .IsUnicode();
            builder.Entity<Store>()
                .HasMany(x => x.Sales)
                .WithOne(y => y.Store)
                .HasForeignKey(x => x.SaleId);
        }

        private static void ConfigCustomer(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasKey(x => x.CustomerId);

            builder.Entity<Customer>()
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsUnicode();
                

            builder.Entity<Customer>()
                .Property(x => x.Email)
                .HasMaxLength(80);
            builder.Entity<Customer>()
                .HasMany(x => x.Sales)
                .WithOne(y => y.Customer)
                .HasForeignKey(x => x.SaleId);
        }

        private static void ConfigProduct(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasKey(x => x.ProductId);
            builder.Entity<Product>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                
                .IsUnicode();
            builder.Entity<Product>()
                .HasMany(x => x.Sales)
                .WithOne(y => y.Product)
                .HasForeignKey(x => x.SaleId);
            builder.Entity<Product>()
                .Property(x => x.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");
        }
    }
}