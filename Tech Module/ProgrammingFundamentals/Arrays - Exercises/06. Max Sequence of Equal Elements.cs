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

            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = 0;
            int current = 1;
            int maxStart = 0;
            int maxLength = 1;
            for (int i = 1; i <array.Length; i++)
            {

                if (array[i]==array[i-1])
                {
                    current++;
                    if (current>maxLength)
                    {
                        maxLength = current;
                        maxStart = start;

                    }
                }
                else
                {
                    current = 1;
                    start = i;
                }
                
            }
            for (int i = maxStart; i <maxStart+maxLength ; i++)
            {
                Console.Write(array[i]+" ");

            }
            Console.WriteLine();
        }
        

    }
}