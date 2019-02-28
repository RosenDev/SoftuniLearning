using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
namespace Arrays
{
    class Program
    {
        static void Main()
        {
            string word = Console.ReadLine();
            char[] alphabet = new char[26];
            var count = 0;
            for (char i = 'a';  i <='z';  i++)
            {
                alphabet[count] = i;
                count++;
            }


            for (int i = 0; i < word.Length; i++)
            {


                char current = word[i];
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (current==alphabet[j])
                    {
                        Console.WriteLine($"{current} -> {j}");
                    }


                }

            }
        }
    }
}