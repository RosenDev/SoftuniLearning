using System;
using Microsoft.EntityFrameworkCore;
using PANDA.Models;

namespace PANDA.Data
{
    public class PandaDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

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
                    x.HasKey(y => y.Id);
                    x.Property(user => user.Username)
                        .IsRequired();
                    x.Property(user => user.Password)
                        .IsRequired();
                    x.Property(user => user.Email)
                        .IsRequired();

                });
            

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }
    }
}
