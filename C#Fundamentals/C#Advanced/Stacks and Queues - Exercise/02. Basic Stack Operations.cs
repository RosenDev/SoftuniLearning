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
            var input = Console.ReadLine();
            var push = int.Parse(input.Split(" ")[0]);
            var pop = int.Parse(input.Split(" ")[1]);
            var peek= int.Parse(input.Split(" ")[2]);
            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            elements = elements;
            var stack = new Stack<int>();
            if (elements.Length>=push)
            {
                for (int i = 0; i < push; i++)
                {
                    stack.Push(elements[i]);
                }
            }

            if (stack.Count>=pop)
            {
                for (int i = 0; i < pop; i++)
                {
                    stack.Pop();
                }
            }

            if (stack.Count > 0)
            {
                if (stack.Contains(peek))
                {
                    Console.WriteLine("true");
                }

                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
            
        }
    }
}
