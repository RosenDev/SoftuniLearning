using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
namespace Arrays
{
    class Program
    {
        static void Main()
        {

            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool found = false;
            for (int i = 0; i < nums.Length; i++)
            {
                int[] first = nums.Take(i).ToArray();
                int[] second = nums.Skip(i + 1).ToArray();
                if (first.Sum()==second.Sum())
                {
                    found = true;
                    Console.WriteLine(i);
                    break;
                }

            }


            if (!found)
            {
                Console.WriteLine("no");
            }
        }
    }
}