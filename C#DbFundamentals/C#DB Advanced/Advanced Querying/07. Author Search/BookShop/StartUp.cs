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

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();
            context.Authors
                .Where(x => EF.Functions
                    .Like(x.FirstName, $"%{input}"))
                .Select(x => new { FullName = x.FirstName + " " + x.LastName })
                .OrderBy(x => x.FullName)
                .ToList().ForEach(x => sb.AppendLine(x.FullName));

            return sb.ToString().Trim();
        }
    }
}
