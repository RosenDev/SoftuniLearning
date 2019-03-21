using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http.Headers;

namespace PaskalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var firstArr = new int[rows][];
            var secondarr = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                var row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                firstArr[i] = row;
            }
            for (int i = 0; i < rows; i++)
            {
                var row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                secondarr[i] = row;
            }

            var counter = 0;
            for (int i = 0; i < rows-1; i++)
            {
                if (firstArr[i].Length+secondarr[i].Length==firstArr[i+1].Length + secondarr[i+1].Length)
                {
                    counter = i+2;
                }
                
            }
            var matrix = new int[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = firstArr[i].Concat(secondarr[i].Reverse()).ToArray();
            }
            if (counter==rows)
            {
                

               
                PrintMatrix(matrix);
            }
            else
            {
                var c = 0;
                foreach (var i in matrix)
                {
                    c += i.Length;
                }
                Console.WriteLine($"The total number of cells is: {c}");
            }
            
        }

        static void PrintMatrix(int[][]matrix)
        {
            foreach (var VARIABLE in matrix)
            {

                Console.WriteLine("["+String.Join(", ",VARIABLE)+"]");
            }

        }
        static void ReadMatrix(int[,]matrix,int rowsCols)
        {
           
            for (int i = 0; i < rowsCols; i++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < rowsCols; j++)
                {
                    matrix[i, j] = input[j];

                }
                
            }

        }
        static void ReadMatrix(int[][] matrix, int rows)
        {

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[i] = input;

            }

        }
        static void ReadMatrix(char[][] matrix, int rows)
        {

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                matrix[i] = input;

            }

        }
    }

    
}
