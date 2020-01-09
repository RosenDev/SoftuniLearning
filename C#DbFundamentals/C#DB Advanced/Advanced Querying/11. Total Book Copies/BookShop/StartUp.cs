using System;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using BookShop.Models.Enums;
using System.Globalization;
using Microsoft.EntityFrameworkCore;


namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
          
            using (var db = new BookShopContext())
            {

              //  Console.WriteLine(GetGoldenBooks(db));
                

            }
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            context.Authors
                .OrderByDescending(x => x.Books.Sum(y => y.Copies))
                .Select(x => x.FirstName + " " + x.LastName + " - " + x.Books.Sum(book => book.Copies))
                .ToList().ForEach(x => sb.AppendLine(x));
            return sb.ToString();
        }
    }
}
