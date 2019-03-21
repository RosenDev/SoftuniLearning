using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;


namespace 10. Predicate Party
{
 
   
    class Program
    {


        
        static void Main(string[] args)
        {

            var guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var cmd = Console.ReadLine();
            while (cmd!="Party!")
            {
                var info = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var main = info[0];
                var type = info[1];
                var arg = info[2];
                if (main=="Remove")
                {
                    switch (type)
                    {

                        case "StartsWith":
                            guests.RemoveAll(x=>x.StartsWith(arg));
                            break;
                        case "EndsWith":
                            guests.RemoveAll(x => x.StartsWith(arg));
                            break;
                        case "Length":
                            guests.RemoveAll(x => x.Length == int.Parse(arg));
                            break;
                               
                    }
                }else if (main=="Double")
                {
                    switch (type)
                    {
                        case "StartsWith":
                            if (guests.Exists(x=>x.StartsWith(arg)))
                            {
                                guests.AddRange(guests.FindAll(x=>x.StartsWith(arg)));
                            }
                            break;
                        case "EndsWith":
                            if (guests.Exists(x => x.EndsWith(arg)))
                            {
                                guests.AddRange(guests.FindAll(x => x.EndsWith(arg)));
                            }
                            break;
                        case "Length":
                            if (guests.Exists(x=>x.Length==Int32.Parse(arg)))
                            {
                                guests.AddRange(guests.FindAll(x=>x.Length==int.Parse(arg)));
                            }
                            break;

                    }   
                }

                cmd = Console.ReadLine();
            }

            if (guests.Count==0)
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ",guests)} are going to the party!");
            }
        }

    }
    
}
