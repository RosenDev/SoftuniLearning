using System;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using BookShop.Models.Enums;
using System.Globalization;

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

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();
            var dateDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            context.Books.Where(x => x.ReleaseDate < dateDate)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .ToList()
                .ForEach(x => sb.AppendLine($"{x.Title} - {x.EditionType} - ${x.Price:f2}"));

            return sb.ToString().Trim();
        }
    }
}
