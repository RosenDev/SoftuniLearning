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
            var array = Console.ReadLine().TrimEnd().Split(" ").Select(int.Parse).ToArray();
            var eversed = new Stack<int>(array);
          StringBuilder sb = new StringBuilder();
            foreach (var i in eversed)
            {
                sb.Append(i+" ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
