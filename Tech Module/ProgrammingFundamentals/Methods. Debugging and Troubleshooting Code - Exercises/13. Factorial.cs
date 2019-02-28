using System;
using System.Numerics;
namespace MethodsExercises
{
    class Program {
        static void Factorial(int number)
        {
            BigInteger result = 1;
            for (int i = 1; i <= number; i++)
            {

                result *= i;


            }
            Console.WriteLine(result);
        }
       
        static void Main()
        {

            int num = int.Parse(Console.ReadLine());
            Factorial(num);









         
        }
    }
}

