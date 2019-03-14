using System;
using System.Security.Principal;

namespace BillsPaymentSystem.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }
        public decimal Limit { get; set; }
        public decimal MoneyOwed { get; set; }
        public decimal LimitLeft => Limit-MoneyOwed;
        public DateTime ExpirationDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Withdraw can only be positive value!");
            }

            if (this.LimitLeft < amount)
            {
                throw new ArgumentException("No that much funds!");
            }

            this.MoneyOwed += amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit can only be positive value!");
            }

            if (this.MoneyOwed < amount)
            {
                throw new ArgumentException(string.Format("Deposit is too much: {0}", this.MoneyOwed));
            }

            this.MoneyOwed -= amount;
        }
    }
}