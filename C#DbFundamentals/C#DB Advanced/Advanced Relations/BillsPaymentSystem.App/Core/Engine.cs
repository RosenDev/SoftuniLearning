using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BillsPaymentSystem.App.Interfaces;
using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Type=BillsPaymentSystem.Models.Enums.Type;
namespace BillsPaymentSystem.App.Core
{
    public class Engine:IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                using (var context= new BillsPaymentSystemContext())
                {
                    var input = Console.ReadLine()?.Split();
                    if (input?[0].ToLower()=="exit")
                    {
                        Stop();
                    }

                    if (input[0]=="PayBills")
                    {
                        PayBills(int.Parse(input[1]),decimal.Parse(input[2]),context);
                    }
                    else {
                        var result = commandInterpreter.Read(input, context);
                        Console.WriteLine(result);
                    }
                    
                }
               

            }

        }

        private void Stop()
        {
            Environment.Exit(0);
        }
        private static void PayBills(int userId, decimal amount, BillsPaymentSystemContext context)
        {
            var user = context.Users
                .Select(u => new
                {
                    u.UserId,
                    BankAccounts = u.PaymentMethods
                        .Where(pm => pm.Type == Type.BankAccount)
                        .Select(pm => pm.BankAccount)
                        .ToArray(),
                    CreditCards = u.PaymentMethods
                        .Where(pm => pm.Type == Type.CreditCard)
                        .Select(pm => pm.CreditCard)
                        .ToArray()
                })
                .FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} does not exists");
                return;
            }

            if (!CanPay(user.BankAccounts, user.CreditCards, amount))
            {
                Console.WriteLine("User cannot afford this payment");
                return;
            }

            amount = PayWithBankAsMuchAsPossuble(user.BankAccounts, amount, context);
            if (amount > 0)
            {
                PayWithCreditCards(amount, user.CreditCards, context);
            }

            context.SaveChanges();
            Console.WriteLine("Bills are successfully payed. Have a nice day. :)");
        }
        private static void PayWithCreditCards(decimal amount, CreditCard[] creditCards, BillsPaymentSystemContext context)
        {
            if (creditCards.Select(cc => cc.LimitLeft).Sum() < amount)
            {
                throw new ArgumentException("Amount is greater than the cards possibilities");
            }

            foreach (var card in creditCards)
            {
                /* 
                 * Due to the Anonymous Object produced by the select in PayBills(...), all instances are
                 * in a Detached state from the change tracker. 
                 */

                // context.Entry(card).State = EntityState.Modified; // Will send aquery updating all the Entity's fields
                context.Entry(card).State = EntityState.Unchanged;

                if (card.LimitLeft >= amount)
                {
                    card.Withdraw(amount);
                    return;
                }

                amount -= card.LimitLeft;
                card.Withdraw(card.LimitLeft);
            }
        }

        private static decimal PayWithBankAsMuchAsPossuble(BankAccount[] bankAccounts, decimal amount, BillsPaymentSystemContext context)
        {
            foreach (var account in bankAccounts)
            {
                /* 
                * Due to the Anonymous Object produced by the select in PayBills(...), all instances are
                * in a Detached state from the change tracker. 
                */

                // context.Entry(account).State = EntityState.Modified; // Will send aquery updating all the Entity's fields
                context.Entry(account).State = EntityState.Unchanged;

                if (account.Balance >= amount)
                {
                    account.Withdraw(amount);
                    amount = 0;
                    break;
                }

                amount -= account.Balance;
                account.Withdraw(account.Balance);
            }

            return amount;
        }

        private static bool CanPay(BankAccount[] bankAccounts, CreditCard[] creditCards, decimal amount)
            => amount <= (bankAccounts.Select(ba => ba.Balance).Sum() + creditCards.Select(cc => cc.LimitLeft).Sum());

        private static void PrintUserDetails(BillsPaymentSystemContext context, int userId)
        {
            var user = context.Users
                .Where(u => u.UserId == userId)
                .Select(u => new
                {
                    Name = $"{u.FirstName} {u.LastName}",
                    BankAccounts = u.PaymentMethods
                        .Where(pm => pm.Type == Type.BankAccount)
                        .Select(pm => pm.BankAccount)
                        .ToArray(),
                    CreditCards = u.PaymentMethods
                        .Where(pm => pm.Type == Type.CreditCard)
                        .Select(pm => pm.CreditCard)
                        .ToArray()
                })
                .FirstOrDefault();

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine(user.Name)
                .AppendLine("Bank Accounts:");
            AppentBankAccountsDetails(sb, user.BankAccounts);
            sb.AppendLine("Credit Cards:");
            AppendCreditCardsDetails(sb, user.CreditCards);

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static void AppendCreditCardsDetails(StringBuilder sb, IEnumerable<CreditCard> creditCards)
        {
            foreach (var card in creditCards)
            {
                sb.AppendLine($"-- ID: {card.CreditCardId}")
                    .AppendLine($"--- Limit: {card.Limit:F2}")
                    .AppendLine($"--- Money Owed: {card.MoneyOwed:F2}")
                    .AppendLine($"--- Limit Left:: {card.LimitLeft}")
                    .AppendLine($"--- Expiration Date: {card.ExpirationDate.ToString("yyyy/MM")}");
            }
        }

        private static void AppentBankAccountsDetails(StringBuilder sb, IEnumerable<BankAccount> bankAccounts)
        {
            foreach (var account in bankAccounts)
            {
                sb.AppendLine($"-- ID: {account.BankAccountId}")
                    .AppendLine($"--- Balance: {account.Balance:F2}")
                    .AppendLine($"--- Bank: {account.BankName}")
                    .AppendLine($"--- SWIFT: {account.SWIFTCode}");
            }
        }

        private static int GetRandomId(BillsPaymentSystemContext context)
        {
            var randomGenerator = new Random();
            var ids = context.Users.Select(u => u.UserId).ToArray();

            return ids[randomGenerator.Next(ids.Length)];
        }
    }
}
    
