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
        {var checker = new Stack<char>();
            var allowedvalues = new char[]{'(','[','{'};
            var str = Console.ReadLine();
            var isvalid = true;
            for (int i = 0; i < str.Length; i++)
            {

                var current = str[i];
                if (allowedvalues.Contains(current))
                {
                    checker.Push(current);
                    continue;
                }

                if (checker.Count==0)
                {
                    isvalid = false;
                    break;
                }
                if (checker.Peek()=='('&&current==')')
                {
                 checker.Pop();   
                }else
                if (checker.Peek() == '[' && current == ']')
                {
                    checker.Pop();

                }else
                if (checker.Peek() == '{' && current == '}')
                {
                    checker.Pop();
                }
                
            }

            if (isvalid&&checker.Count==0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
