using System;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    "Server=DESKTOP-CUCRL15\\SQLEXPRESS;Database=Accounts;" +
                                        "Integrated Security=true");
        }
    }
}
