using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace Custom_Min_Function
{
 
   
    class Program
    {
       
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
                .Min();
            Console.WriteLine(nums);

        }

    
    }
    
}
