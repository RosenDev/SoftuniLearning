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

            var array1 = Console.ReadLine().Split().Select(char.Parse).ToArray();
            var array2 = Console.ReadLine().Split().Select(char.Parse).ToArray();


            if (array1.Length == array2.Length && IsBiggerOrEqual(array1, array2) == 0)
            {

                Console.WriteLine(string.Join("", array1));
                Console.WriteLine(string.Join("", array2));

            }


            else if (array2.Length < array1.Length && IsBiggerOrEqual(array1, array2) == -1)
            {
                Console.WriteLine(string.Join("", array2));
                Console.WriteLine(string.Join("", array1));
            } else if (array1.Length < array2.Length && IsBiggerOrEqual(array1, array2) == 1)
            {
                Console.WriteLine(string.Join("", array1));
                Console.WriteLine(string.Join("", array2));
            } else if (array2.Length < array1.Length && IsBiggerOrEqual(array1, array2) == 1)
            {
                Console.WriteLine(string.Join("", array2));
                Console.WriteLine(string.Join("", array1));
            }
            else if (array2.Length > array1.Length && IsBiggerOrEqual(array1, array2) == -1)
            {
                Console.WriteLine(string.Join("", array1));
                Console.WriteLine(string.Join("", array2));
            } else if (array2.Length == array1.Length && IsBiggerOrEqual(array1, array2)==1)
            {
                Console.WriteLine(string.Join("",array1));
                Console.WriteLine(string.Join("", array2));
            }
            else if (array2.Length == array1.Length && IsBiggerOrEqual(array1, array2) == -1)
            {
                Console.WriteLine(string.Join("", array2));
                Console.WriteLine(string.Join("", array1));
            }


            // check if array length of the first array is bigger than the second

        }
        static int IsBiggerOrEqual(char[]a,char[]b)
        {
            var length = Math.Min(a.Length, b.Length);
            for (int i = 0; i < length; i++)
            {
                if (a[i]==b[i])
                {



                }
                if (a[i]>b[i])
                {
                    return -1;
                }else
                {
                    return 1;
                }



            }

            return 0;
        }
        /*
         *
         *initialize a new method /private static bool(ean)/
         *    min length array
         *    for
         *       char[i1] == char[i2]
         *          if true -> continue
         *          
         *       char[i1] > char[i2]
         *          if true -> return -1
         *       else
         *          return 1
         * 
         *    return 0
         */

    }
}