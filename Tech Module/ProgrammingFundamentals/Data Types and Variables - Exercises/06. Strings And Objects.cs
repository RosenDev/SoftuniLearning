using System;

namespace exersice
{
    class Program
    {
        static void Main(string[] args)
        {
            var string1 = Console.ReadLine();
            var string2 = Console.ReadLine();
            object all = string1 + " "+string2;
            var str3 = all.ToString();
            Console.WriteLine(str3);
        }
    }
}