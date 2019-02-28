using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
 
class UserLogs
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        StringBuilder iPLogs = new StringBuilder();
        SortedDictionary<string, SortedDictionary<string, int>> output = new SortedDictionary<string, SortedDictionary<string, int>>();
 
        for (int i = 0; i < lines; i++)
        {
            string inputLine = Console.ReadLine();
            iPLogs.Append(inputLine);
            iPLogs.Append("\n");
        }
 
        Regex regex = new Regex(@"(.+) (.+) (\d+)");
        MatchCollection matches = regex.Matches(iPLogs.ToString());
 
        foreach (Match match in matches)
        {
            SortedDictionary<string, int> subDictionary = new SortedDictionary<string, int>();
 
            string iP = match.Groups[1].ToString();
            string user = match.Groups[2].ToString();
            int duration = int.Parse(match.Groups[3].ToString());
 
            if (output.ContainsKey(user))
            {
                subDictionary = output[user];
                if (subDictionary.ContainsKey(iP))
                {
                    int repetitions = subDictionary[iP] + duration;
                    subDictionary[iP] = repetitions;
                }
                else
                {
                    subDictionary.Add(iP, duration);
                }
 
                output[user] = subDictionary;
            }
            else
            {
                subDictionary.Add(iP, duration);
                output.Add(user, subDictionary);
            }
        }
 
        foreach (var subDictionary in output)
        {
            Console.Write("{0}: ", subDictionary.Key);
 
            int totalDuration = 0;
            foreach (var time in subDictionary.Value)
            {
                totalDuration += time.Value;
            }
 
            Console.Write("{0} [", totalDuration);
            int counter = 1;
            foreach (var ip in subDictionary.Value)
            {
                Console.Write("{0}", ip.Key);
                if (counter == subDictionary.Value.Count)
                {
                    Console.WriteLine("]");
                }
                else
                {
                    Console.Write(", ");
                }
                counter++;
            }
        }
    }
}