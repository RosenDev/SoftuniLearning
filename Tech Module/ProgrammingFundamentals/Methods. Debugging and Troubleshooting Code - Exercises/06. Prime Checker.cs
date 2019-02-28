using System;
class Program
{
    static void Main()
    {
        long Num = long.Parse(Console.ReadLine());
        IsPrime(Num);
        Console.WriteLine(IsPrime(Num));
    }
    public static bool IsPrime(long number)
    {
        if (number <= 1)
            return false;
        else if (number % 2 == 0)
            return number == 2;
 
        long N = (long)(Math.Sqrt(number) + 0.5);
 
        for (int i = 3; i <= N; i += 2)
            if (number % i == 0)
                return false;
 
        return true;
    }

    }
