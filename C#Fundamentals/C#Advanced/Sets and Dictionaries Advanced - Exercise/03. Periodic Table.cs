using System;
using System.Collections.Generic;
using System.Linq;


namespace Dictonaries_and_Sets
{
    class Program
    {
        static void Main(string[] args)
        {
           var elements = new HashSet<string>();
            var n = int.Parse(Console.ReadLine().Trim());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                foreach (var s in input)
                {
                    elements.Add(s);
                }
            }

            Console.WriteLine(String.Join(" ",elements.OrderBy(x=>x)));
        }     
    }
}
