using System;

namespace IfandLoops
{
    class Program
    {
        static void Main()
        {
            var calories = 0.0;
            var ingCount = int.Parse(Console.ReadLine());
            for(int i = 0; i < ingCount; i++)
            {
                var ing = Console.ReadLine().ToLower();
                if (ing.Equals("cheese"))
                {
                    calories += 500;
                }
                else if (ing.Equals("tomato sauce"))
                {
                    calories += 150;
                }
                else if (ing.Equals("salami"))
                {
                    calories += 600;
                }
                else if (ing.Equals("pepper"))
                {
                    calories += 50;
                }

            }
            Console.WriteLine($"Total calories: {calories}");
        }
    }
}