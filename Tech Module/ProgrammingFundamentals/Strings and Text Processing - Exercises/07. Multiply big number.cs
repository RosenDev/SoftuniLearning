using System;
using System.Linq;
using System.Text;

namespace StringsExercises
{

  
    class Program
    {
        static void Main()
        {
            var num = Console.ReadLine().TrimStart('0');
            var multiply = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            var reminder = 0;

            for (int i = num.Length-1 ; i >= 0; i--)
            {
                if (multiply==0)
                {
                    Console.WriteLine(0);
                    return;
                    
                }
                var curr = int.Parse(num[i].ToString());
                var currResult = curr * multiply+reminder;
                sb.Append(currResult % 10);
                reminder = currResult / 10;
            }

            if (reminder!=0)
            {
                Console.Write(reminder);
            }
            Console.WriteLine(string.Concat(sb.ToString().Reverse()));

        }
    }
}