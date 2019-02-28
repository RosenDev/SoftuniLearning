using System;
using System.Threading;

namespace Softuni
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var currHealth = int.Parse(Console.ReadLine());
            var maxhealth = int.Parse(Console.ReadLine());
            var currenegy = int.Parse(Console.ReadLine());
            var maxenergy = int.Parse(Console.ReadLine());
            var heltext = new string('|',currHealth);
            var helmissing = new string('.', maxhealth - currHealth);
            var energytext = new string('|', currenegy);
            var heenergymissing = new string('.', maxenergy - currenegy);
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: |{heltext}{helmissing}|");
            Console.WriteLine($"Energy: |{energytext}{heenergymissing}|");
        }
    }
}
