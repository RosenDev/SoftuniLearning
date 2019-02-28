using System;
using System.Numerics;
namespace exersice
{
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = decimal.Parse(Console.ReadLine());
            var num2 = decimal.Parse(Console.ReadLine());
            var requiredDifference = 0.000001m;
            var isOk = false;
            if (Math.Abs(num2 - num1) >= requiredDifference)
            {
                Console.WriteLine(isOk);
                
            }
            else
            {
                isOk = true;
                Console.WriteLine(isOk);
               
            }

        }

    }
}
