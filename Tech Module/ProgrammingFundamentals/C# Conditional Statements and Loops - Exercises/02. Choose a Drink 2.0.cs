using System;

namespace IfandLoops
{
    class Program
    {
        static void Main()
        {
            var drink = Console.ReadLine();
            var quantity = int.Parse(Console.ReadLine());
            double price = 0;
            double total = 0;
            if (drink.Equals("Athlete"))
            {
                price = 0.7;

            } else if (drink.Equals("Businessman")||drink.Equals("Businesswoman"))
            {
                price = 1;
            } else if (drink.Equals("SoftUni Student"))
            {
                price = 1.70;
            } else
            {

                price = 1.20;

            }
            total = price * quantity;
            Console.WriteLine($"The {drink} has to pay {total:f2}.");


        }
    }
}