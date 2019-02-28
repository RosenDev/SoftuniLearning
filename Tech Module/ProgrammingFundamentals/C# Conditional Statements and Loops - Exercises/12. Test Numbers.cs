using System;

namespace IfandLoops
{
    class Program
    {
        static void Main()
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            int sum = 0;
            int count = 0;
            
            for (int i = first; i >= 1; i--)
            {
               
                for (int k = 1; k <= second; k++)
                {
                    count++;
                    int curr = (i * k) * 3;
                    sum+= curr;
                    if (sum >= max)
                    {
                        Console.WriteLine($"{count} combinations");
                        Console.WriteLine($"Sum: {sum} >= {max}");
                        
                        return; 
                    }




                }

            }
            
            
                Console.WriteLine($"{count} combinations");
                Console.WriteLine($"Sum: {sum}");
            
        }
    }
}
