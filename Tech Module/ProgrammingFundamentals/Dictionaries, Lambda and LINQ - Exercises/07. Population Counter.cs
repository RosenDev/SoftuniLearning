using System;
using System.Collections.Generic;
using System.Linq;


namespace LambdaExercise
{
    class Program
    {
        static void Main()
        {
            var country = new Dictionary<string, Dictionary<string, long>>();
            string line;
            while ((line=Console.ReadLine())!="report")
            {
                var tokens = line.Split('|');
                var town = tokens[0];
                var countr = tokens[1];
                long poulation = long.Parse(tokens[2]);
                if (!country.ContainsKey(countr))
                {
                    country.Add(countr,new Dictionary<string, long>());
                }

                if (!country[countr].ContainsKey(town))
                {
                    country[countr].Add(town,poulation);
                }
                else
                {
                      country[countr][town] += poulation;

                }
            }

            
            foreach (var item in country.OrderByDescending(c=>c.Value.Sum(t=>t.Value)))
            {

                var name = item.Key;
                long countryPop = item.Value.Sum(t => t.Value);
                Console.WriteLine($"{name} (total population: {countryPop})");
                Dictionary<string, long> sorted =
                    item.Value.OrderByDescending(t => t.Value).ToDictionary(x => x.Key, x => x.Value);
                foreach (var VARIABLE in sorted)
                {
                    Console.WriteLine($"=>{VARIABLE.Key}: {VARIABLE.Value}");
                }


            }

        }
    }
}
