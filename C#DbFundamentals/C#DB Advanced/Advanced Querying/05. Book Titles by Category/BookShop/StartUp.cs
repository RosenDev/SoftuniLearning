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

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input?.ToLower().Split();
            var sb = new StringBuilder();

            context.Books.Where(x => x.BookCategories.Any(y => categories.Contains(y.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList()
                .ForEach(x => sb.AppendLine(x));
            



            return sb.ToString().Trim();
        }
    }
}
