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

            int rotation = int.Parse(Console.ReadLine());
            int[] result = new int[nums.Length];
            for (int i = 0; i < rotation; i++)
            {
                var last = nums[nums.Length-1];
                for (int l = nums.Length-1; l >0; l--)
                {
                    nums[l] = nums[l-1];
                    result[l] += nums[l];
                }
                nums[0] = last;
                result[0] += nums[0];


            }
            Console.WriteLine(string.Join(" ", result));

        }

    }
}