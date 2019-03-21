using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;


namespace 04._Find_Evens_or_Odds
{
 
   
    class Program
    {
       
        static void Main(string[] args)
        {var full = new List<int>();
            var nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            for (int i = nums[0]; i <= nums[1]; i++)
            {full.Add(i);
                
            }
            var arra=new List<int>();

            var cmd = Console.ReadLine();
            if (cmd=="odd")
            {
                foreach (var i in full)
                {
                    if (odd(i))
                    {
                        arra.Add(i);

                    }
                }

            }
            else
            {
                foreach (var i in full)
                {
                    if (even(i))
                    {
                  arra.Add(i);

                    }
                }
            }

            Console.WriteLine(String.Join(' ', arra));
        }

        private static Predicate<int> odd = x => x % 2 != 0;
        private static Predicate<int> even = x => x % 2 == 0;
    }
    
}
