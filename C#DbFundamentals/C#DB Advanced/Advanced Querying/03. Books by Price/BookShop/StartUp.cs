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

              //  Console.WriteLine(GetGoldenBooks(db));
                

            }
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();
            context.Books.Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => $"{x.Title} - ${x.Price:f2}")
                .ToList().ForEach(x => sb.AppendLine(x));

            return sb.ToString().Trim();
        }
    }
}
