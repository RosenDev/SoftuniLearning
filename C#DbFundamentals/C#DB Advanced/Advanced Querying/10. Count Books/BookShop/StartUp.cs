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

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var bookCount = context.Books.Where(x => x.Title.Length > lengthCheck)
                .Select(x => x.Title)
                .ToList().Count;
            return bookCount;
        }
    }
}
