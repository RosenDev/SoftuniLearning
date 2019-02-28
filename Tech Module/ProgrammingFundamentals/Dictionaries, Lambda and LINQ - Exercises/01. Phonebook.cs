using System;
using System.Collections.Generic;

namespace LambdaExercise
{
    class Program
    {
        static void Main()
        {
            var cmd = Console.ReadLine().Split();
            var phonebook = new Dictionary<string, string>();
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

            else if (cmd[0] == "S")
                {
                    var keyword = cmd[1];
                    if (phonebook.ContainsKey(keyword))
                    {
                        
                            Console.WriteLine($"{keyword} -> {phonebook[keyword]}");
                        }else
                        {
                            Console.WriteLine($"Contact {keyword} does not exist.");
                        }


                    }
                cmd = Console.ReadLine().Split();
            }







               
                }


            }

        }
    
