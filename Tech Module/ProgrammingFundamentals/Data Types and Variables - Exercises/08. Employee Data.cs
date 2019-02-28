using System;

namespace exersice
{
    class Program
    {
        static void Main(string[] args)
        {

            var name = Console.ReadLine();
            var lname = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var gender = Console.ReadLine();
            var id = long.Parse(Console.ReadLine());
            var proffid = long.Parse(Console.ReadLine());
            Console.WriteLine($"First name: {name}");
            Console.WriteLine($"Last name: {lname}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Personal ID: {id}");
            Console.WriteLine($"Unique Employee number: {proffid}");
      


        }

    }
}
