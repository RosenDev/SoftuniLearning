using System;
using System.Text.RegularExpressions;

namespace RegexExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var input = Console.ReadLine();
            var regex = new Regex($@"\b[^?.!]*\b{word}\b[^?.!]*");
            var matched = regex.Matches(input);
            foreach (Match VARIABLE in matched)
            {
                Console.WriteLine(VARIABLE.Value);
            }


        }
    }
}
