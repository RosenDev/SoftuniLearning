using System;
using System.Numerics;
namespace exersice
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbol = int.Parse(Console.ReadLine());
            var symbol2 = int.Parse(Console.ReadLine());
            for (int i = symbol; i <= symbol2; i++)
            {
                Console.Write((char)i+" ");
            }

        }

    }
}
