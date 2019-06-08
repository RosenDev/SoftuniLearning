using System;
using System.Buffers;
using Microsoft.EntityFrameworkCore;
using PANDA.Models;

namespace PANDA.Data
{
    public class PandaDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        protected PandaDbContext()
        {
        }

        public PandaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(x =>
                {
                  
                    x.Property(user => user.Username)
                        .IsRequired();
                    x.Property(user => user.Password)
                        .IsRequired();
                    x.Property(user => user.Email)
                        .IsRequired();
                });

            modelBuilder.Entity<Package>(x =>
            {
                x.Property(package => package.Description).IsRequired();
                x.Property(package => package.ShippingAddress).IsRequired();
                x.HasOne(package => package.Recipient)
                    .WithMany(user => user.Packages)
                    .HasForeignKey(a=>a.RecipientId);
            });

            modelBuilder.Entity<Receipt>(x =>
            {

            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }
    }
}
