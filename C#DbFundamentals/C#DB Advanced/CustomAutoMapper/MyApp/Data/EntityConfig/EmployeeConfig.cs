using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Models;

namespace MyApp.Data.EntityConfig
{
    public class EmployeeConfig:IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.EmployeeId);
            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Address)
                .HasMaxLength(250);
            builder.HasOne(x => x.Manager)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.ManagerId);
        }
    }
}