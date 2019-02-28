using System;
using System.Linq;
using System.Collections.Generic;

namespace listsExercises
{
    class Program
    {
        static void Main()
        {


            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var cmd = Console.ReadLine().Split(' ');

            while (cmd[0] != "print")
            {

                if (cmd[0] == "add")
                {
                    var index = cmd[1];
                    var element = cmd[2];
                    list.Insert(int.Parse(index),int.Parse(element));
                }
                else if (cmd[0] == "contains")
                {
                    var item = int.Parse(cmd[1]);
                    Console.WriteLine(list.IndexOf(item));
                    
                }
                else if (cmd[0] == "remove")
                {
                list.RemoveAt(int.Parse(cmd[1]));
                }
                else if (cmd[0] == "shift")
                {
                    int rotations = int.Parse(cmd[1]);
                    for (int i = 0; i < rotations; i++)
                    {
                        int current = list[0];
                        for (int j =1; j<list.Count ; j++)
                        {
                            list[j-1] = list[j];

                        }

                        list[list.Count - 1] = current;
                    }
                }
                else if (cmd[0] == "sumPairs")
                {
                    for (int i = 0; i < list.Count-1; i++)
                    {

                        list[i] = list[i] + list[i + 1];
                        list.RemoveAt(i+1);


                    }
                }
                else if (cmd[0] == "addMany")
                {
                    var args = int.Parse(cmd[1]);
                    var nums = new List<int>();
                    for (int i = 2; i < cmd.Length; i++)
                    {
                        nums.Add(int.Parse(cmd[i]));
                      
                    }

                    

                    list.InsertRange(args, nums);


                }

                cmd = Console.ReadLine().Split(' ');



            }

            Console.WriteLine($"[{string.Join(", ", list)}]");


        }
    }
}
