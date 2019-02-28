using System;
using System.Numerics;
namespace MethodsExercises
{
    class Program {

        static void FactorialZeroes(int num)
        {
            int count = 0;
            BigInteger factoral = 1;
            for (int i = 1; i <=num; i++)
            {
                factoral *= i;
            }
            while (factoral > 0)
            {
                var current = factoral % 10;
                if (current==0){
                    count++;
                }
                else
                {
                    break;
                }
                factoral /= 10;

            }
            Console.WriteLine(count);


        }

        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            FactorialZeroes(num);


        }    
    }
}

