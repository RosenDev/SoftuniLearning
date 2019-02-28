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
                factoral /= 10;

            }
            Console.WriteLine(count);


        }



        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i<=num ; i++)
            {
                if (Symetric(i)&&SumOfDgits(i)&&IsOneEven(i))
                {
                    Console.WriteLine(i);
                }
             
            }
        }    
        static bool Symetric(int num)
        {
            string curent = num.ToString();
            int count = 0;
            for (int i = curent.Length-1; i >=0 ; i--)
            {
                if (curent[i] != curent[count])
                {
                    return false;
                }
                count++;
            }
            return true;
        }
        static bool SumOfDgits(int num)
        {
            var sum = 0;
            while (num>0)
            {
                var current = num % 10;
                sum += current;

                num /= 10;
            }
            if (sum%7==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
   static bool IsOneEven(int num)
        {
            while (num>0)
            {

                var current = num % 10;
                if (current%2==0)
                {
                    return true;
                }
                num /= 10;
            }
            return false;

        }
    }
}

