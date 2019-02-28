using System;

namespace IfandLoops
{
    class Program
    {
        static void Main()
        {
            var n1 = int.Parse(Console.ReadLine());
            var n2 = int.Parse(Console.ReadLine());
            var first = n1 < n2 ? n1 : n2;
            var last = n1 > n2 ? n1 : n2;
            for(int  i = first; i <= last; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}