using System;using System.Threading;namespace Softuni{    class Program    {static string Repeat(string str, int count)        {            string reult = "";            for(int i = 0; i < count; i++)            {                reult += str;            }            return reult;        }             static void Main(string[] args)        {            var n = int.Parse(Console.ReadLine());            for(var i = 1; i <= n; i++)            {                Console.WriteLine(Repeat($"{i} ",i));            }        }    }}