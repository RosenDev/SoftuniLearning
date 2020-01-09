using System;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()?.ToLower();
            using (var db = new BookShopContext())
            {

                Console.WriteLine(GetBooksByAgeRestriction(db, input));
                

            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();
            context.Books
                .Where(x => x.AgeRestriction == Enum.Parse<AgeRestriction>(command, true))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList().ForEach(x =>
                {
                   sb.AppendLine(x);
                });
            return sb.ToString();
        }
    }
}
