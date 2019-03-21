using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;


namespace Dictonaries_and_Sets
{
    class Program
    {
        static void Main(string[] args)
        {var dict= new Dictionary<string,Dictionary<string,int>>();
            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(" -> ");
                var color = input[0];
                var dict2= new Dictionary<string,int>();
                var clotches = input[1].Split(",").ToList();
                foreach (var clotch in clotches)
                {
                    if (!dict2.ContainsKey(clotch))
                    {
                        dict2.Add(clotch,1);
                    }
                    else
                    {
                        dict2[clotch]++;
                    }
                }
                if (!dict.ContainsKey(color))
                {
                    dict.Add(color,dict2);
                }
                else
                {
                    foreach (var VARIABLE in dict2)
                    {
                        if (dict[color].ContainsKey(VARIABLE.Key))
                        {
                            dict[color][VARIABLE.Key]+=VARIABLE.Value;
                        }
                        else
                        {
                            dict[color].Add(VARIABLE.Key,VARIABLE.Value);
                        }
                    }
                }

            }

            var cmd = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            var theColor = cmd[0];
            var thedress = cmd[1];
            foreach (var VARIABLE in dict)
            {
                Console.WriteLine($"{VARIABLE.Key} clothes:");
                foreach (var i in VARIABLE.Value)
                {
                    if (theColor==VARIABLE.Key&&thedress==i.Key)
                    {
                        Console.WriteLine($"* {i.Key} - {i.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {i.Key} - {i.Value}");
                    }
                }
            }


        }
    }
}
