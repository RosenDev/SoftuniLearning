using System;
using System.Globalization;

namespace ClassesExercises
{
    class Program
    {
        static void Main(string[] args)
        {

            var phrases = new string[]{ "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product."};
            var authors = new string[]{"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
            var cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
            var events = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            var random= new Random();
            var thePhrase = random.Next(0,phrases.Length);
            var theAuthor = random.Next(0, authors.Length);
            var theCity = random.Next(0, cities.Length);
            var theEvent = random.Next(0, events.Length);
            Console.WriteLine($"{phrases[thePhrase]} {events[theEvent]} {authors[theAuthor]} – {cities[theCity]}.");


        }
    }
}
