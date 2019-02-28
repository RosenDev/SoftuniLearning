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
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var diffrence = int.Parse(Console.ReadLine());
            var count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {

                var current = numbers[i];
                for (int j = 0; j < numbers.Length; j++)
                {

                    if (current-numbers[j]==diffrence)
                    {
                        count++;
                    }

                }
              
            }

            Console.WriteLine(count);
        }
    }
}