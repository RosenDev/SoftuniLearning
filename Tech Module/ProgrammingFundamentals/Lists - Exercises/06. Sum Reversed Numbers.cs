using System;
using System.Linq;
using System.Collections.Generic;
using System.Dynamic;

namespace listsExercises
{
    class Program
    {
        static void Main()
        {

            var list = Console.ReadLine().Split().ToList();
            int result = 0;
            for (int i = 0; i <list.Count; i++)
            {
                var current = list[i];
                var reversed = "";
                for (int j =current.Length-1; j >=0; j--)
                {
                    reversed += current[j];

                }

                result += int.Parse(reversed);
            }

            Console.WriteLine(result);
        }
    }
}
