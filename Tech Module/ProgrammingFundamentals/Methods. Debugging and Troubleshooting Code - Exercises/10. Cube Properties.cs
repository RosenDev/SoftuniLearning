using System;
using System.Numerics;
namespace MethodsExercises
{
    class Program {
        static double CubeParams(string type,double side)
        {
            switch (type)
            {
                case "face":
                    return Math.Sqrt(2*side*side);

                case "space":
                    return Math.Sqrt(3*side*side);
                case "volume":
                    return Math.Pow(side, 3);
                case "area":
                    return 6*side*side;
                default:
                    return 0;

                  
              
            }


        }
       
        static void Main()
        {

            double side = double.Parse(Console.ReadLine());
            var type = Console.ReadLine();
            Console.WriteLine($"{CubeParams(type, side):f2}");  
        }
        
    }
}

