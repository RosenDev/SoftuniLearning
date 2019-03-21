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
        {var stack = new Stack<long>();
            var num = long.Parse(Console.ReadLine());
            stack.Push(0);
            stack.Push(1);
                
            for (long i = 0; i < num-1; i++)
            {
                var n1 = stack.Pop();
                var n2 = stack.Pop();
                stack.Push(n1);
                stack.Push(n1+n2);

            }

            Console.WriteLine(stack.Peek());
        }
    }
}
