using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace _11.Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
         
            double result = 0;
 
            if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                result = a * b / 2;
                Console.WriteLine($"{result:f2}");
            }
            else if (figure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                result = a*a;
                Console.WriteLine($"{result:f2}");
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                result = a * b;
                Console.WriteLine($"{result:f2}");
            }
            else if (figure == "circle")
            {
                double a = double.Parse(Console.ReadLine());
                result = Math.PI * a * a;
                Console.WriteLine($"{result:f2}");
            }
        }
    }
}