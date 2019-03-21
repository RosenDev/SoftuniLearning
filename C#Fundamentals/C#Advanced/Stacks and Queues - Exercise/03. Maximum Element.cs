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
        {var stack = new Stack<int>();
            var lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine();
                if (input.Contains(" "))
                {
                    var element = int.Parse(input.Split(" ")[1]);
                    stack.Push(element);

                }
                else if(input.Equals("2"))
                {
                    stack.Pop();
                }else if (input.Equals("3"))
                {
                    Console.WriteLine(stack.Max());
                }

            }
        }
    }
}
