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
        {var stack= new Stack<string>();
            var cmdCount = int.Parse(Console.ReadLine());
            var result = string.Empty;
            stack.Push(result);
            for (int i = 0; i < cmdCount; i++)
            {
             
                var input = Console.ReadLine();
                var cmd = input.Split(" ")[0];
                switch (cmd)
                {
                    case "1":
                        result = stack.Peek()+input.Split(" ")[1];
                        stack.Push(result);
                        break;

                    case "2":
                        result = stack.Peek().Substring(0,stack.Peek().Length- int.Parse(input.Split(" ")[1]));
                        stack.Push(result);
                        break;
                    case "3":
                        Console.WriteLine(stack.Peek()[int.Parse(input.Split()[1])-1]);
                        break;
                    case "4":
                        stack.Pop();
                        break;
                        default:

                            break;
                }
            }
        }
    }
}
