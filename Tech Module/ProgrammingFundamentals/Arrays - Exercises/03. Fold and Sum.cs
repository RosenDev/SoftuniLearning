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

            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int k = arr.Length / 4;
            int[] left = arr.Take(k).ToArray();
            int[] middle = arr.Skip(k).Take(2 * k).ToArray();
            int[] right = arr.Skip(3 * k).Take(k).ToArray();
            Array.Reverse(right);
            Array.Reverse(left);
            int[] result = new int[2 * k];
            for (int i = 0; i < k; i++)
            {

                result[i] = left[i] + middle[i];
                result[i + k] = right[i] + middle[i + k];



            }
            Console.WriteLine(string.Join(" ",result));






        }

    }
}