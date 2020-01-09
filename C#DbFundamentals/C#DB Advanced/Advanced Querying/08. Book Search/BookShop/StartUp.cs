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

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();
            context.Books
                .Where(x => EF.Functions.Like(x.Title, $"%{input}%"))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList()
                .ForEach(x => sb.AppendLine(x));

            return sb.ToString().Trim();
        }
    }
}
