using System;
using System.Collections.Generic;
using System.Linq;


namespace Dictonaries_and_Sets
{
    class Program
    {
        static void Main(string[] args)
        {
            var set1= new HashSet<int>();
            var set2= new HashSet<int>();
            var lengths = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < lengths[0]; i++)
            {
                set1.Add(int.Parse(Console.ReadLine().Trim()));
            }
            for (int j = 0; j < lengths[1]; j++)
            {
                set2.Add(int.Parse(Console.ReadLine().Trim()));
            }

            var results = new List<int>();
            foreach (var i in set1)
            {
                if (set2.Contains(i))
                {
                    results.Add(i);
                }
            }

            Console.WriteLine(String.Join(" ",results));
        }     
    }
}
