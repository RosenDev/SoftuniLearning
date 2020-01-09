using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace Action_Print
{
 
   
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList().ForEach((c => Console.WriteLine(c)));

        }

    }
}
