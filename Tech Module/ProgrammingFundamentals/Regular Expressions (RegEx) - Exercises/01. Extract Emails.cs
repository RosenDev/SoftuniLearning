using System;
using System.Text.RegularExpressions;

namespace RegexExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var regex = new Regex(@"(?<=\s)(?<user>[a-z0-9]+[\-\.\\_]+[a-z]+|[a-z0-9]+)@(?<domain>[a-z]+|[a-z]+[\-\.]+[a-z]+)(\.[a-z]+)+");
            var matched = regex.Matches(input);
            foreach (Match VARIABLE in matched)
            {
                Console.WriteLine(VARIABLE.Value);
            }


        }
    }
}
