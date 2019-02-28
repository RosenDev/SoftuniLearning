using System;
using System.Linq;
using System.Text;

namespace StringsExercises
{

  
    class Program
    {
        static void Main()
        {
            var text = Console.ReadLine().Split(new []{" ","\t"},StringSplitOptions.RemoveEmptyEntries);
            var sum = 0M;
            foreach (var VARIABLE in text)
            {
                var before = VARIABLE[0];
               var after = VARIABLE[VARIABLE.Length - 1];
                var num = decimal.Parse(string.Concat(VARIABLE.Skip(1).Take(VARIABLE.Length - 2)));
                if (char.IsUpper(before))
                {
                    num /= before - 64;
                   
                }
                else
                {
                    num *= before - 96;



                }

                if (char.IsUpper(after))
                {
                    num -= after - 64;

                }
                else
                {
                    num += after - 96;
                }

                sum += num;
            }


            Console.WriteLine($"{sum:f2}");






        }
    }
}