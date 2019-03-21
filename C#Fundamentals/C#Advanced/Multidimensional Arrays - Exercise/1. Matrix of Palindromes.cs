using System;
using System.Linq;

namespace PaskalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];
            var matrix = new string[rows][];
        	char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            for (int i = 0; i < matrix.Length; i++)
            {
                var col = new string[cols];
                matrix[i] = col;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                   matrix[i][j]= (alphabet[i].ToString() + alphabet[i + j].ToString() + alphabet[i].ToString()).ToString();
                  

                }

                

            }

            foreach (var i in matrix)
            {
                Console.WriteLine(string.Join(" ",i));
            }


        }
    }
}
