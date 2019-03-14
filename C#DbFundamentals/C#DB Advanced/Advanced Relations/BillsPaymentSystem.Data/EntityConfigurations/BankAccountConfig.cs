using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.EntityConfigurations
{
    public class BankAccountConfig:IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(x=>x.BankAccountId);
            builder.Property(x => x.Balance)
                .IsRequired();
            builder.Property(x => x.BankName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();
            builder.Property(x => x.SWIFTCode)
                .IsRequired()
                .HasMaxLength(20).IsUnicode(false);
            builder.HasOne(x => x.PaymentMethod)
                .WithOne(x => x.BankAccount)
                .HasForeignKey<PaymentMethod>(x => x.BankAccountId);

        }
    }
}