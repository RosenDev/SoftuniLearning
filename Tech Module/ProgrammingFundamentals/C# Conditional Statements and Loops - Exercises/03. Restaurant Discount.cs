using System;

namespace IfandLoops
{
    class Program
    {
        static void Main()
        {
            var clients = int.Parse(Console.ReadLine());
            var package = Console.ReadLine().ToLower();
            var price = 0.0;
            var total = 0.0;

            var packPrice = 0.0;
            var hall = "";
            var discount = 0.0;
            if (package.Equals("normal"))
            {
                packPrice = 500;
                discount = 0.05;
            }else if (package.Equals("gold"))
            {
                packPrice = 750;
                discount = 0.1;
                  }else if (package.Equals("platinum")) {
                packPrice = 1000;
                discount = 0.15;

            }

                if (clients<=50)
            {
                hall = "Small Hall";
                price = 2500;
                total = (packPrice + price);
                total -= total * discount;
                total = total / clients;
                
            }else if (clients <= 100)
            {
                hall = "Terrace";
                price = 5000;
                total = (packPrice + price);
                total -= total * discount;
                total /= clients;
            }
            else if (clients <= 120)
            {
                hall = "Great Hall";
                price = 7500;
                total = (packPrice + price);
                total -= total * discount;
                total /= clients;
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            Console.WriteLine($"We can offer you the {hall}");
            Console.WriteLine($"The price per person is {total:f2}$");
        }
    }
}
