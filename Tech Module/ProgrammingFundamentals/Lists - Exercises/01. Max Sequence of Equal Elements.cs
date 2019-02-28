using System;
using System.Linq;
using System.Collections.Generic;
using System.Dynamic;

namespace listsExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            var bestStart = 0;
            var bestLength = 1;
            var start = 0;
            var length = 1;

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    
                    length++;

                    if (length > bestLength)
                    {
                        bestLength = length;
                        bestStart = start;
                    }

                }
                else
                {
                    length = 1;
                    start= i;
                }

            


            }


            for (int i = bestStart; i < bestStart+bestLength; i++)
            {

                Console.Write(nums[i]+" ");
            }

            Console.WriteLine();

        }
    }
}
