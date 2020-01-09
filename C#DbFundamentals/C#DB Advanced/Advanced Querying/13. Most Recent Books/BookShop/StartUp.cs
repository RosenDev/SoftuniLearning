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

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var bookCat = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks.Select(y => new
                    {
                        y.Book
                    })
                        .OrderByDescending(y => y.Book.ReleaseDate)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(x => x.Name)
               
                .ToList();


            foreach (var VARIABLE in bookCat)
            {
                sb.AppendLine($"--" + VARIABLE.Name);
                foreach (var book in VARIABLE.Books)
                {
                    sb.AppendLine(book.Book.Title + $" ({book.Book.ReleaseDate?.Year})");
                }
            }
            return sb.ToString();
        }
    }
}
