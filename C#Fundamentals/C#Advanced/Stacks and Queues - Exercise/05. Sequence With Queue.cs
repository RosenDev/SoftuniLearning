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
        {

            var n = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            var arr = new List<long>();
            var count = 1;
            queue.Enqueue(n);
           arr.Add(n);
            int i;
            for (int j = 0; j <17; j++)


            {
                long curr = queue.Dequeue();
                       arr.Add(curr+1);

                        
                        queue.Enqueue(curr + 1);   
                  
       queue.Enqueue(2 * curr + 1);
                        arr.Add(2*curr+1);
                        
                  queue.Enqueue(curr+2);
                      arr.Add(curr+2);
                        
                    
                

              
            }

            Console.WriteLine(string.Join(" ",arr.Take(50)));
        }
    }
}
