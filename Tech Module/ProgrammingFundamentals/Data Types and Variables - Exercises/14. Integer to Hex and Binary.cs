using System;
using System.Numerics;
namespace exersice
{
    class Program
    {
        static void Main(string[] args)
        {

            var num = int.Parse(Console.ReadLine());
            var hex = Convert.ToString(num, 16);

            var binary = Convert.ToString(num, toBase: 2);
            hex = hex.ToUpper();
            Console.WriteLine(hex);
            Console.WriteLine(binary);

        }

    }
}
