using System;
 
namespace Different_Numbers
{
    class Different_Numbers
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            if (secondNumber - firstNumber < 4) Console.WriteLine("No");
            else
            {
                for (int i = firstNumber; i <= secondNumber; i++)
                {
                    for (int j = firstNumber; j <= secondNumber; j++)
                    {
                        for (int k = firstNumber; k <= secondNumber; k++)
                        {
                            for (int l = firstNumber; l <= secondNumber; l++)
                            {
                                for (int m = firstNumber; m <= secondNumber; m++)
                                {
                                    if (i < j && j < k && k < l && l < m) Console.WriteLine($"{i} {j} {k} {l} {m} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}