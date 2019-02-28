using System;
using System.Collections.Generic;
using System.Text;

namespace exersice
{
    class Class1
    {
        static void Main(string[] args)
        {
            var width = double.Parse(Console.ReadLine());
            var heght = double.Parse(Console.ReadLine());

            var p = width * 2 + heght * 2;
            var area = width * heght;
            var diagonal = Math.Sqrt(width * width + heght * heght);
            Console.WriteLine(p);
            Console.WriteLine(area);
            Console.WriteLine(diagonal);
            
            

        }
     


    }
}
