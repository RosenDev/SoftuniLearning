using System;

namespace MethodsExercises
{
    class Program {
        //Fib METHOD
        static int Fib(int num)
        {
            int result = 0;
            if (num==0||num==1)
            {
                return result = 1;
            }
            int old = 1;
            int newN = 1;
            for (int i = 2; i <=num; i++)
            {
               
                result = old + newN;
                
                newN= old;
                old= result;


            }
            return result;
        }
        //END OF Fib
  
//MAIN METHOD
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(Fib(n));
           
        }}}