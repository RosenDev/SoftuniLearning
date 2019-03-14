using System;
using BillsPaymentSystem.Models;
using BillsPaymentSystem.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Type = BillsPaymentSystem.Models.Enums.Type;

namespace BillsPaymentSystem.Data.EntityConfigurations
{
    public class PaymentMethodConfig:IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (Type) Enum.Parse(typeof(Type), v))//todo remove it
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.PaymentMethods)
                .HasForeignKey(x => x.UserId);

        }
    }
}