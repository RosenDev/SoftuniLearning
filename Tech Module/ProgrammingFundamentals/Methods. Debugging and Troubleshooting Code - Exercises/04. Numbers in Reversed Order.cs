using System;
class Program
{
    static void Main()
    {
        string Num = Console.ReadLine();
        DigitInReversedOrder(Num);
    }
    static void DigitInReversedOrder(string a)
    {
        string reversed = "";
        char adding = ' ';
        for (int i = a.Length - 1; i >= 0; i--)
        {
            adding = a[i];
            reversed = reversed + adding;
           
        }
        Console.WriteLine(reversed);
    }

    }
