using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;


namespace Dictonaries_and_Sets
{
  public class Vlogger
    {
        public int Followers { get; set; } 
        public int Following { get; set; }
        public List<string> FollowingNames { get; set; }
        public List<string> FollowersNames { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dict= new Dictionary<string,Vlogger>();
            var input = Console.ReadLine();
            while (input!="Statistics")
            {
                if (input.Contains("joined"))
                {
                    var info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var user = info[0];
                    if (!dict.ContainsKey(user))
                    {
                        dict.Add(user,new Vlogger(){FollowersNames = new List<string>(),FollowingNames = new List<string>()});
                    }
                }
                else
                {
                    var info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var follower = info[0];
                    var followed = info[2];
                    if (followed!=follower&&dict.ContainsKey(followed)&&dict.ContainsKey(follower))
                    {
                        if (!dict[followed].FollowersNames.Contains(follower))
                        {
                            dict[follower].Following++;
                            dict[followed].Followers++;
                            dict[followed].FollowersNames.Add(follower);
                            dict[follower].FollowingNames.Add(followed);
                        }
                       
                        
                    }
                }

                input = Console.ReadLine();

            }

            var counter = 1;
            Console.WriteLine($"The V-Logger has a total of {dict.Count} vloggers in its logs.");
            var sorted = dict.OrderByDescending(x => x.Value.Followers).ThenBy(x=>x.Value.Following).ToDictionary(x => x.Key, y => y.Value);
            foreach (var vlogger in sorted)
            {
                if (counter==1)
                {

                    Console.WriteLine($"1. {vlogger.Key} : {vlogger.Value.Followers} followers, {vlogger.Value.Following} following");
                    foreach (var valueFollowersName in vlogger.Value.FollowersNames.OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {valueFollowersName}");

                        
                    }
                    counter++;
                }
                else
                {
                    Console.WriteLine($"{counter++}. {vlogger.Key} : {vlogger.Value.Followers} followers, {vlogger.Value.Following} following");
                }

            }
        }
    }
}
