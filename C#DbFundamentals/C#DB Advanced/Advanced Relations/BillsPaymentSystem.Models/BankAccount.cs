using System;

namespace BillsPaymentSystem.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public decimal Balance { get; set; }
        public string BankName { get; set; }
        public string SWIFTCode { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Withdraw can only be positive value!");
            }

            if (this.Balance < amount)
            {
                throw new ArgumentException("No that much funds!");
            }

            this.Balance += amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit can only be positive value!");
            }

            if (this.Balance < amount)
            {
                throw new ArgumentException(string.Format("Deposit is too much: {0}", this.Balance));
            }

            this.Balance -= amount;
        }
    }
}
