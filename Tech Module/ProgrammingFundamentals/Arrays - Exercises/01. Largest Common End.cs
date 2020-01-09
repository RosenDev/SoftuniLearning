using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
namespace Arrays
{
    class Program
    {
        static void Main()
        {
            
            var text = Console.ReadLine().Split();
            var text2 = Console.ReadLine().Split();
            int count = 0;
            var length = Math.Min(text.Length, text2.Length);
          
            for (int i = 0; i < length; i++)
            {

                if (text[i] == text2[i])
                {
                    count++;
                }
            }

            var reversed = 0;
            Array.Reverse(text);
            Array.Reverse(text2);

            for (int i = 0; i < length; i++)
            {
                if (text[i] == text2[i])
                {

                    reversed++;
                }

            }
            if (reversed > count)
            {
                Console.WriteLine(reversed);
            }
            else
            {
                Console.WriteLine(count);
            }

        }
    }
}