using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MyApp.Data.EntityConfig;
using MyApp.Models;

namespace MyApp.Data
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public SampleDbContext(DbContextOptions options) : base(options)
        {
           
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        "Server=DESKTOP-CUCRL15\\SQLEXPRESS;Database=SampleDb;Integrated Security=true");
        //}
    }
}