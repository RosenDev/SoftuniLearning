using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BillsPaymentSystem.App.Core;
using BillsPaymentSystem.App.Interfaces;
using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Type = BillsPaymentSystem.Models.Enums.Type;

namespace BillsPaymentSystem.App
{
   public class StartUp
    {
       public static void Main(string[] args)
       {
           ICommandInterpreter interpreter= new CommandInterpreter();
           IEngine engine = new Engine(interpreter);
           engine.Run();
       }

        private static List<User> CreateUsers()
        {
            return new List<User>(){new User()
            {
                FirstName = "User1",
                LastName = "Userow",
                Email="bots1000@gmail.com",
                Password = "bot222",
              
            }};
        }
        private static List<CreditCard> CreateCreditCards()
        {
            return new List<CreditCard>(){new CreditCard()
            {
                Limit = 200m,
                MoneyOwed = 50m,
                ExpirationDate = DateTime.Now.AddYears(1)
                
            }};
        }
        private static List<PaymentMethod> CreatePaymentMethods()
        {
            return new List<PaymentMethod>(){new PaymentMethod()
            {
                Type = Type.BankAccount,
                UserId = 1,
                BankAccountId = 1
            },
                new PaymentMethod()
                {
                    Type=Type.CreditCard,
                    CreditCardId = 1,
                    UserId = 1
                }
            };
        }
        private static List<BankAccount> CreateBankAccounts()
        {
            return new List<BankAccount>(){new BankAccount()
            {
                Balance = 600,
                BankName = "UnicreditBullbank",
                SWIFTCode = "BG59508448590000"

            }};
        }
        private static void Seed<T>(BillsPaymentSystemContext context,List<T> data)
        {
            if (typeof(T)==typeof(User))
            {
                context.Users.AddRange(data.Cast<User>());
                context.SaveChanges();
            }
            else if (typeof(T) == typeof(BankAccount))
            {
                context.BankAccounts.AddRange(data.Cast<BankAccount>());
                context.SaveChanges();
            }
            else if (typeof(T) == typeof(CreditCard))
            {
                context.CreditCards.AddRange(data.Cast<CreditCard>());
                context.SaveChanges();
            }
            else if (typeof(T) == typeof(PaymentMethod))
            {
                context.PaymentMethods.AddRange(data.Cast<PaymentMethod>());
                context.SaveChanges();
            }




        }
    }
}
