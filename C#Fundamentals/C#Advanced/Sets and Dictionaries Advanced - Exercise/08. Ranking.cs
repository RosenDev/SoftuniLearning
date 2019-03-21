using System;
using System.Collections.Generic;
using System.Linq;



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
            var contests = new Dictionary<string, string>();
            var usersResults = new Dictionary<string, Dictionary<string, int>>();
            var input = Console.ReadLine().Trim();
            while (input != "end of contests")
            {
                var info = input.Split(":");
                var contest = info[0];
                var pass = info[1];
                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, pass);
                }

                input = Console.ReadLine().Trim();
            }

            input = Console.ReadLine().Trim();
            while (input != "end of submissions")
            {
                var info = input.Split("=>");
                var contest = info[0];
                var password = info[1];
                var userame = info[2];
                var points = int.Parse(info[3]);
                if (contests.ContainsKey(contest) && contests[contest] == password)

                {
                    if (!usersResults.ContainsKey(userame))
                    {
                        usersResults.Add(userame, new Dictionary<string, int>() { { contest, points } });
                    }
                    else
                    {
                        if (usersResults[userame].ContainsKey(contest))
                        {
                            if (usersResults[userame][contest] <= points)
                            {
                                usersResults[userame][contest]=points;
                            }
                        }
                        else
                        {
                            usersResults[userame].Add(contest, points);
                        }
                    }
                }

                input = Console.ReadLine().Trim();
            }

            var bestCandidate = usersResults.OrderByDescending(x => x.Value.Sum(y => y.Value))
                .ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine($"Best candidate is {bestCandidate.First().Key} with total {bestCandidate.First().Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (var usersResult in usersResults.OrderBy(x => x.Key))
            {
                Console.WriteLine(usersResult.Key);
                foreach (var i in usersResult.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {i.Key} -> {i.Value}");
                }
            }
        }
    }
}
