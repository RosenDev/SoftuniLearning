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
          
            using (var db = new BookShopContext())
            {

                Console.WriteLine(GetGoldenBooks(db));
                

            }
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb= new StringBuilder();
            context.Books
                .Where(x => x.Copies < 5000 && x.EditionType == EditionType.Gold)
                .Select(x =>new
                {
                    x.Title,
                    x.BookId
                })
                .OrderBy(x => x.BookId)
                .ToList().ForEach(x=>sb.AppendLine(x.Title));
            return sb.ToString().Trim();
        }
    }
}
