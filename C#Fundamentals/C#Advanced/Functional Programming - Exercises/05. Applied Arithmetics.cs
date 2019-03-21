using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;


namespace 05._Applied_Arithmetics
{
 
   
    class Program
    {


        static int Add(int i,Sum s)
        {

            return s(i);
        }

        static int Sub(int i, Sum s)
        {
            return s(i);
        }
        static int Multiply(int i, Sum s)
        {
            return s(i);
        }
        static void Print(List<int> i)
        {
            Console.WriteLine(String.Join(" ",i));
        }
        delegate int Sum(int x);

        
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var cmd = Console.ReadLine();
            while (cmd!="end")
            {
                switch (cmd)
                {
                    case "add":
                        for (int i = 0; i < list.Count; i++)
                        {
                            list[i] = Add(list[i], x => x + 1);
                        }

                        break;

                    case "subtract":
                        for (int i = 0; i < list.Count; i++)
                        {
                            list[i] = Add(list[i], x => x - 1);
                        }
                        break;

                    case "multiply":

                        for (int i = 0; i < list.Count; i++)
                        {
                            list[i] = Add(list[i], x => x *2);
                        }
                        break;

                    case "print":
                        Print(list);

                        break;
                }

                cmd = Console.ReadLine();
            }



        }

    }
    
}
