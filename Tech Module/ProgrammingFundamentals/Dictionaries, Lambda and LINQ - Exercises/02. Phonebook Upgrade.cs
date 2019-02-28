using System;
using System.Collections.Generic;

namespace LambdaExercise
{
    class Program
    {
        static void Main()
        {
            var cmd = Console.ReadLine().Split();
            var phonebook = new SortedDictionary<string, string>();
            while (cmd[0] != "END")
            {

                if (cmd[0]=="A"){ 
                var name = cmd[1];
                var phone = cmd[2];
                    if (phonebook.ContainsKey(name))
                    {
                        phonebook[name] = phone;

                    }
                    else
                    {
                        phonebook.Add(name,phone);
                    }

            }
                else if (cmd[0]=="S")
                {
                    var key = cmd[1];
                    if (phonebook.ContainsKey(key))
                    {
                        Console.WriteLine($"{key} -> {phonebook[key]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {key} does not exist.");
                    }
                }
            else if (cmd[0] == "ListAll")
                {
                    foreach (var VARIABLE in phonebook)
                    {
                        Console.WriteLine($"{VARIABLE.Key} -> {VARIABLE.Value}");
                    }


                }
                cmd = Console.ReadLine().Split();
            }
        }

    }

}
    
