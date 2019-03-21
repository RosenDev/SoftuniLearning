using System;
using System.Collections.Generic;

namespace Dictonaries_and_Sets
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<string>();
            var length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                set.Add(Console.ReadLine());
            }
            foreach (var i in set)
            {
                Console.WriteLine(i);
            }
        }
    }
}
