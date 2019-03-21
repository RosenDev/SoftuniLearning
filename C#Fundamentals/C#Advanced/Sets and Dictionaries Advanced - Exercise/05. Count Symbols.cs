using System;
using System.Collections.Generic;
using System.Linq;


namespace Dictonaries_and_Sets
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var result = new  Dictionary<char,int>();
            foreach (var VARIABLE in text)
            {
                if (!result.ContainsKey(VARIABLE))
                {
                    result.Add(VARIABLE,1);
                }
                else
                {
                    result[VARIABLE]++;
                }
            }

            foreach (var i in result.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{i.Key}: {i.Value} time/s");
            }

        }
    }
}
