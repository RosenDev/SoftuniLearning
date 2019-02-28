using System;
using System.Linq;
using System.Collections.Generic;
using System.Dynamic;

namespace listsExercises
{
    class Program
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            var changingNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
          
            
            nums.RemoveRange(0,changingNums[1]);
          
        for (int i = 0; i < nums.Count; i++)
            {
                if (changingNums[2]==nums[i])
                {
                    Console.WriteLine("YES!");

                    return;
                }
         


            }


            Console.WriteLine("NO!");
        }
    }
}
