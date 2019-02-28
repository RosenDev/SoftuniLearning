using System;
using System.Globalization;
using System.Linq;

namespace ClassesExercises
{
    class Circle
    {
        public int Center { get; set; }
        public int Radius { get; set; }

        public static int ReadRadius(string text)
        {
            var input = text.Split().Select(int.Parse).ToArray();
            var radius = input[2];
            return radius;
        }



    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

      public  static Point ReadPoint(string text)
      {
          var input = text.Split().Select(int.Parse).ToArray();
          var pX = input[0];
          var pY = input[1];
          return new Point{X = pX,Y=pY};
      }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var input2 = Console.ReadLine();
            var radius = Circle.ReadRadius(input);
            var radius2 = Circle.ReadRadius(input2);
            var point = Point.ReadPoint(input);
            var point2= Point.ReadPoint(input2);
            var center1 = point.X * point.Y;
            var center2 = point2.X * point2.Y;
            var circle = new Circle{Radius = radius,Center =center1};
            var circle2= new Circle{Radius = radius2,Center = center2};
            var differenceBtwCircles = Math.Abs(center1-center2);
            var totalRadius = radius + radius2;
            if (differenceBtwCircles<=totalRadius)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}
