using System;
using System.Numerics;
namespace exersice
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            sbyte sb = 0;
            byte b = 0;
            short s =0;
            ushort us = 0;
            int i = 0;
            uint ui = 0;
            long l = 0;
            var isInSbyte = "* sbyte";
            var isInByte = "* byte";
            var isShort = "* short";
            var isUShort = "* ushort";
            var isInt = "* int";
            var isUint = "* uint";
            var isLong = "* long";
            sbyte.TryParse(input, out sb);
            byte.TryParse(input, out b);
            short.TryParse(input, out s);
            ushort.TryParse(input, out us);
            int.TryParse(input, out i);
            uint.TryParse(input, out ui);
            long.TryParse(input, out l);
            if (l == 0)
            {
                Console.WriteLine($"{input} can't fit in any type");
            }
            else
            {
                Console.WriteLine($"{input} can fit in:");
                if (sb != 0)
                {
                    Console.WriteLine(isInSbyte);
                }
                if (b != 0)
                {
                    Console.WriteLine(isInByte);
                }
                if (s != 0)
                {
                    Console.WriteLine(isShort);
                }
                if (us!= 0)
                {
                    Console.WriteLine(isUShort);
                }
                if (i != 0)
                {
                    Console.WriteLine(isInt);
                }
                if (ui != 0)
                {
                    Console.WriteLine(isUint);
                }
                if (l != 0)
                {
                    Console.WriteLine(isLong);
                }
            }
        }

    }
}
