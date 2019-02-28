using System;

namespace MethodsExercises
{
    class Program
    {
        static int Max(int n1,int n2,int n3)
        {
            if (n1 >= n2&&n1>=n3)
            {
                return n1;
            }else if (n2 >= n1 && n2 >= n3)
            {
                return n2;
            }
            else if(n3>=n1 && n3>=n2)
            {
                return n3;

            }
            else
            {
                return 0;
            }
            
        }
        static void Main(string[] args)
        {
            var n1 = int.Parse(Console.ReadLine());
            var n2 = int.Parse(Console.ReadLine());
            var n3 = int.Parse(Console.ReadLine());
            Console.WriteLine(Max(n1, n2, n3) ); 

        }
    }
}
