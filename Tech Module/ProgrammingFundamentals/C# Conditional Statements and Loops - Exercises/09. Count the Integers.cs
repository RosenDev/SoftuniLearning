using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int counter = 0;
           
 
            while (true)
            {
                int number;
                bool result = Int32.TryParse(input, out number);
                if (result)
                {
                    counter++;
                }
                if (!result)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(counter);
        }  
    }
}