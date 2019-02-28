using System;

namespace IfandLoops
{
    class Program
    {
        static void Main()
        {
            var ingr = Console.ReadLine();
            int count = 0;
            while (!ingr.Equals("Bake!"))
            {
                Console.WriteLine($"Adding ingredient {ingr}.");
                count++;
                ingr=Console.ReadLine();

            }
            Console.WriteLine($"Preparing cake with {count} ingredients.");
        }
    }
}
