using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;


namespace 06._Reverse_And_Exclude
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
            var list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var num = int.Parse(Console.ReadLine());
            list = list.Where(x => x % num != 0).Reverse().ToList();
            Console.WriteLine(String.Join(" ",list));


        }

    }
    
}
