using System;
using System.Threading;

namespace Softuni
{
    class Program
    {
        static void Main(string[] args)
        {
            var drink = Console.ReadLine();
            var volume = int.Parse(Console.ReadLine());
            var energy = int.Parse(Console.ReadLine());
            var sugar = int.Parse(Console.ReadLine());
            var calories = volume * energy / 100.0;
            var sugareal = volume * sugar / 100.0;
            Console.WriteLine($" {volume}ml {drink}:");
             Console.WriteLine(   $"{calories}kcal, {sugareal}g sugars");
           
            
        }
    }
}