using System;
using System.Numerics;
 
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            char n = char.Parse(Console.ReadLine());
 
            //check i numbers
 
            try
            {
                int b;
                b = int.Parse(n.ToString());
                Console.WriteLine("digit");
            }
            catch
            {
                //not an integer
                string h = n.ToString().ToLower();
                if (h == "a" || h == "i" || h == "o" || h == "u" || h == "e") Console.WriteLine("vowel");
                else Console.WriteLine("other");
            }
        }
    }
}