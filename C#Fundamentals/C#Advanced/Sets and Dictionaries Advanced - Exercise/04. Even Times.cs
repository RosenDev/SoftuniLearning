using System;
using System.Collections.Generic;
using System.Linq;


namespace Dictonaries_and_Sets
{
    class Program
    {
        static void Main(string[] args)
        {
            var list= new List<int>();
            var length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                var input = int.Parse(Console.ReadLine());
                list.Add(input);
            }

            var count = 1;
            var num = 0;


            foreach (var i in list)
            {
                var reult = list.FindAll(x => x == i);
                if (reult.Count%2==0)
                {
                    Console.WriteLine(reult[0]);
                    return;
                }
            }

        }     
    }
}
