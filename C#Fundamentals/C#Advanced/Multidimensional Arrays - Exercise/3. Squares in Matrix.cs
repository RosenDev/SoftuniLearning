using System;
using System.Linq;

namespace PaskalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var cout = 0;
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new char[sizes[0]][];
            ReadMatrix(matrix,sizes[0]);
            for (int i = 0; i < matrix.Length-1; i++)
            {
                for (int j = 0; j < matrix[i].Length-1; j++)
                {
                    if ((matrix[i][j]==matrix[i][j+1])&& (matrix[i][j]==matrix[i+1][j]) && matrix[i][j] == matrix[i+1][j+1])
                    {
                        cout++;
                    }
                    
                }
                
            }

            Console.WriteLine(cout);
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
        static void ReadMatrix(int[][] matrix, int rows, int cols)
        {

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
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
