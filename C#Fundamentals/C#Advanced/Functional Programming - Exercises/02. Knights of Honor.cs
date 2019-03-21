using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;


namespace 02._Knights_of_Honor
{
 
   
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList().ForEach((c => Console.WriteLine($"Sir {c}")));

        }

    }
}
