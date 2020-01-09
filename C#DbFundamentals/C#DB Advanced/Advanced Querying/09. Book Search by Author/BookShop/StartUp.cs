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

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();
            context.Books
                .Include(x => x.Author)
                .Where(x => EF.Functions.Like(x.Author.LastName, $"{input}%"))
                .OrderBy(x => x.BookId)
                .Select(x => x.Title + $" ({x.Author.FirstName + " " + x.Author.LastName})")
                .ToList()
                .ForEach(x => sb.AppendLine(x));

            return sb.ToString().Trim();
        }
    }
}
