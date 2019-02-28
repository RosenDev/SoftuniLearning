using System;
using System.Threading;

namespace Softuni
{
    class Program
    {
        static void Main(string[] args)
        {
            var miles =double.Parse(Console.ReadLine());
            var converted = miles * 1.60934;


            Console.WriteLine($"{converted:f2}");
           
            
        }
    }
}