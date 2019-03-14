using System.Security.Cryptography.X509Certificates;
using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.EntityConfigurations
{
    public class CreditCardConfig:IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(x => x.CreditCardId);

            builder.Property(x => x.ExpirationDate).IsRequired();
            builder.Property(x => x.Limit).IsRequired();
            builder.Ignore(x => x.LimitLeft);
            builder.Property(x => x.MoneyOwed).IsRequired();
            builder.HasOne(x => x.PaymentMethod)
                .WithOne(x => x.CreditCard)
                .HasForeignKey<PaymentMethod>(x => x.CreditCardId);

        }
    }
}