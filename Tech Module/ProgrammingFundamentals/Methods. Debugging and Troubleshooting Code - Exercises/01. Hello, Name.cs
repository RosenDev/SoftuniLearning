using System;

namespace MethodsExercises
{
    class Program
    {
        static void Hello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            Hello(name);


        }
    }
}
