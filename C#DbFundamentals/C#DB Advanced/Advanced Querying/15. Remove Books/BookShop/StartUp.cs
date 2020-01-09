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

        public static int RemoveBooks(BookShopContext context)
        {
            var forDelete = context.Books.Where(x => x.Copies < 4200)
                .Include(x => x.BookCategories)
                .ThenInclude(x => x.Category)
                .ToList();
            var c = forDelete.Count;
            context.Books.RemoveRange(forDelete);
            context.SaveChanges();

            return c;
        }
    }
}
