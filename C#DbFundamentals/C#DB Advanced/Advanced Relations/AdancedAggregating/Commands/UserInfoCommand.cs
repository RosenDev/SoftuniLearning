using System;
using System.Globalization;
using System.Linq;
using System.Text;
using BillsPaymentSystem.App.Interfaces;
using BillsPaymentSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BillsPaymentSystem.App.Commands
{
    public class UserInfoCommand:ICommand
    {
        private readonly BillsPaymentSystemContext ctx;

        public UserInfoCommand(BillsPaymentSystemContext context)
        {
            ctx = context;
        }
        public string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);
            var user = ctx.Users
                .Include(x=>x.PaymentMethods)
                .ThenInclude(x=>x.CreditCard)
                .Include(x=>x.PaymentMethods)
                .ThenInclude(x=>x.BankAccount)
                .FirstOrDefault(x => x.UserId == userId);
            if (user==null)
            {
                throw new ArgumentNullException("User not found!");
            }

            var sb = new StringBuilder();
           sb.AppendLine($"User: {user.FirstName+" "+user.LastName}");
            sb.AppendLine($"Bank Accounts:");
            foreach (var paymentMethod in user.PaymentMethods.Where(x=>x.BankAccountId!=null))
            {
                sb.AppendLine($"-- ID: {paymentMethod.BankAccountId}");
                sb.AppendLine($"--- Balance: {paymentMethod.BankAccount.Balance}");
                sb.AppendLine($"--- Bank: {paymentMethod.BankAccount.BankName}");
                sb.AppendLine($"--- SWIFT: {paymentMethod.BankAccount.SWIFTCode}");
            }
            sb.AppendLine($"Credit Cards:");
            foreach (var paymentMethod in user.PaymentMethods.Where(x=>x.CreditCardId!=null))
            {
                sb.AppendLine($"-- ID: {paymentMethod.CreditCardId}");
                sb.AppendLine($"--- Limit: {paymentMethod.CreditCard.Limit:f2}");
                sb.AppendLine($"--- Money Owed: {paymentMethod.CreditCard.MoneyOwed:f2}");
                sb.AppendLine($"--- Limit Left:: {paymentMethod.CreditCard.LimitLeft:f2}");
                sb.AppendLine($"--- Expiration Date: {paymentMethod.CreditCard.ExpirationDate.Date.ToString("yyyy/MM",CultureInfo.InvariantCulture)}");
            }
            return sb.ToString();
        }
    }
}