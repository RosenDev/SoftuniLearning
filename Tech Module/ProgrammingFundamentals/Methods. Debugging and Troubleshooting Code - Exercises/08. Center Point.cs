using System;
using System.Numerics;
namespace MethodsExercises
{
    class Program {
        
       
        static void Main()
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1=double.Parse(Console.ReadLine());
            var x2= double.Parse(Console.ReadLine());
            var y2= double.Parse(Console.ReadLine());
            CenterPoint(x1, x2, y1, y2);
        }
        static void CenterPoint(double x1,double x2,double y1, double y2)
        {
            double first = Math.Sqrt(x1*x1+y1*y1);
            double second = Math.Sqrt(x2*x2+y2*y2);
            if (first<second)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }

        }
    }
}

