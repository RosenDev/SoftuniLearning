using System.Collections.Generic;
using BillsPaymentSystem.Models.Attributes;
using BillsPaymentSystem.Models.Enums;

namespace BillsPaymentSystem.Models
{
    public class PaymentMethod
    {
        
        public int Id { get; set; }
        public Type Type { get; set; }
        public int UserId { get; set; }
        [Xor("CreditCardId")]
        public int? BankAccountId { get; set; }
        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
        public BankAccount BankAccount { get; set; }
        public User User { get; set; }
    }
}