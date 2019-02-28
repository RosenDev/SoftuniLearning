using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringsExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = 0;
            var text = Console.ReadLine().Split();
            var txt1 = text[0];
            var txt2 = text[1];
            var forCount = Math.Max(txt1.Length, txt2.Length);
            for (int i = 0; i < forCount; i++)
            {
                if (i < txt1.Length && i < txt2.Length)
                {

                    var one = txt1[i];
                    var two = txt2[i];

                    var result = (int)one * (int)two;
                    sum += result;
                }
else


                if (i>=txt1.Length)
                {
                    sum += (int)txt2[i];


                } else if (i >= txt2.Length)
                {
                    sum += (int)txt1[i];


                }
               




            }
            Console.WriteLine(sum);
        }
    }
}