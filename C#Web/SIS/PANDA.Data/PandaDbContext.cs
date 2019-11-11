using Microsoft.EntityFrameworkCore;
using PANDA.Data.Models;

namespace PANDA.Data
{
    public class PandaDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Models.Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public PandaDbContext()
        {
        }

        public PandaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(x =>
            {
                x.HasKey(user => user.Id);
                    x.Property(user => user.Username)
                        .IsRequired();
                    x.Property(user => user.Password)
                        .IsRequired();
                    x.Property(user => user.Email)
                        .IsRequired();
                });

            modelBuilder.Entity<Package>(x =>
            {
                x.HasKey(package => package.Id);
                x.Property(package => package.Description).IsRequired();
               
                x.HasOne(package => package.Recipient)
                    .WithMany(user => user.Packages)
                    .HasForeignKey(a=>a.RecipientId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Receipt>(x =>
            {
                x.HasKey(receipt => receipt.Id);
                x.HasOne(a => a.Recipient)
                    .WithMany(a => a.Receipts)
                    .HasForeignKey(a => a.RecipientId)
                    .OnDelete(DeleteBehavior.Restrict);
                x.HasOne(a => a.Package)
                    .WithMany(a => a.Receipts)
                    .HasForeignKey(a => a.PackageId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
