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

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();
            var result = context.Categories
                .Select(x => new
                {
                    x.Name,
                    sum = x.CategoryBooks.Sum(y => y.Book.Copies * y.Book.Price)
                })
                .OrderByDescending(x => x.sum)
                .ThenBy(x => x.Name)
                .ToList();
            result.ForEach(x => sb.AppendLine(x.Name + $" ${x.sum:f2}"));

            return sb.ToString();
        }

    }
}
