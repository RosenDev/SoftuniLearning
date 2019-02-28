using System;

namespace IfandLoops
{
    class Program
    {
        static void Main()
        {
            var drink = "";
            var job = Console.ReadLine();
            if (job.Equals("Athlete"))
            {
                drink = "Water";
            }else if (job.Equals("Businessman")||job.Equals("Businesswoman"))
            {
                drink= "Coffee";
            }else if (job.Equals("SoftUni Student"))
            {
                drink = "Beer";
            }else
            {
                drink = "Tea";
            }

            Console.WriteLine(drink);

        }
    }
}
}