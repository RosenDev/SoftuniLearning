using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;

namespace PaskalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var cout = 0;
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new int[sizes[0]][];
            ReadMatrix(matrix,sizes[0]);
            var result = new int[3][];
            var biggestSum = int.MinValue;
            for (int i = 0; i < matrix.Length-2; i++)
            {
                for (int j = 0; j < matrix[i].Length-2; j++)
                {
                     var sum = matrix[i][j] + matrix[i][j + 1] +
                           matrix[i][j + 2] + matrix[i + 1][j] +
                           matrix[i + 1][j + 1] + matrix[i + 1][j + 2] + 
                           matrix[i + 2][j] + matrix[i + 2][j + 1] +
                           matrix[i + 2][j + 2];
                    if (biggestSum<sum)
                    {
                        biggestSum = sum;
                        result[0]= new int[]{matrix[i][j], matrix[i][j + 1],matrix[i][j + 2]};
                        result[1] = new int[] { matrix[i + 1][j], matrix[i + 1][j + 1], matrix[i + 1][j + 2]};
                        result[2] = new int[]{matrix[i + 2][j], matrix[i + 2][j + 1], matrix[i + 2][j + 2]};
                    }
                }
            }

            Console.WriteLine($"Sum = {biggestSum}");
            foreach (var i in result)
            {
                Console.WriteLine(String.Join(" ",i));
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
