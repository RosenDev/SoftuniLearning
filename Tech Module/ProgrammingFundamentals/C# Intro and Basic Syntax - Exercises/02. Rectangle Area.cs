using System;
using System.Threading;

namespace Softuni
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 =double.Parse(Console.ReadLine());
            var n2= double.Parse(Console.ReadLine());
            var result = n1 *n2;
           
            Console.WriteLine($"{result:f2}");
           
            
        }
    }
}