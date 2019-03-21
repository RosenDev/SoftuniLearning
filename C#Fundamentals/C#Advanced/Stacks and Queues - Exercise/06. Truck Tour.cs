using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Stacks_and_Queues
{
    class Program
    {
        static void Main(string[] args)
        {var petrolPumps = new Queue<int[]>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                petrolPumps.Enqueue(input);
            }

            int index = 0;
         
            while (true)
            {
                var total = 0;
                foreach (var petrolPump in petrolPumps)
                {
                    int fuel = petrolPump[0];
                    int distance = petrolPump[1];
                    total += fuel - distance;
                    if (total < 0)
                    {
                        index++;
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        break;
                    }

                    

                }
                if (total >= 0)
                {
                    break;

                }
            }

            Console.WriteLine(index);
        }
    }
}
