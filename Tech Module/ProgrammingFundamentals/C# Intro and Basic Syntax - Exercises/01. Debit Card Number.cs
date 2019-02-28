using System;
using System.Threading;

namespace Softuni
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 =int.Parse(Console.ReadLine());
            var n2= int.Parse(Console.ReadLine());
            var n3 =int.Parse(Console.ReadLine());
            var n4 =int.Parse(Console.ReadLine());

            Console.Write($"{n1:d4} ");
            Console.Write($"{n2:d4} ");
            Console.Write($"{n3:d4} ");
            Console.Write($"{n4:d4} ");
            
        }
    }
}