using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;


namespace 08. Custom Comparator
{
 
   
    class Program
    {


        static int Add(int i,Sum s)
        {

            return s(i);
        }

        static int Sub(int i, Sum s)
        {
            return s(i);
        }
        static int Multiply(int i, Sum s)
        {
            return s(i);
        }
        static void Print(List<int> i)
        {
            Console.WriteLine(String.Join(" ",i));
        }
        delegate int Sum(int x);

        
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var all = arr.Where(x => x % 2 == 0).OrderBy(x=>x).Concat(arr.Where(x => x % 2 != 0).OrderBy(x=>x)).ToArray();

            Console.WriteLine(String.Join(" ",all));
        }

    }
    
}
