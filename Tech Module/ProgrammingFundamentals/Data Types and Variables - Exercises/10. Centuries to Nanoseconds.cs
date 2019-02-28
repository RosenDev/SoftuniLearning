using System;
using System.Numerics;
namespace exersice
{
    class Program
    {
        static void Main(string[] args)
        {
            var centuries = int.Parse(Console.ReadLine());
            var years = centuries * 100;
            var days = (uint)Math.Floor(years* 365.2422);
            long hours = days * 24;
            long minutes = hours * 60;
            ulong seconds = (ulong)minutes * 60;
            ulong miliseconds = seconds * 1000;
            ulong microseconds = miliseconds * 1000;
            BigInteger nano = (BigInteger)microseconds * 1000;
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {miliseconds} milliseconds = {microseconds} microseconds = {nano} nanoseconds");
        }

    }
}
