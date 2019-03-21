using System;
using System.Linq;

namespace PaskalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = long.Parse(Console.ReadLine());
            var matrix = new long[size,size];
            ReadMatrix(matrix,size);
            var leftSum = 0l;
            var rightSum = 0l;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                leftSum += matrix[i, i];

            }

            int count = 0;
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
               
                rightSum += matrix[i, count++];
            }

            var result = Math.Abs(leftSum - rightSum);
            Console.WriteLine(result);
            

        }

        static void ReadMatrix(long[,]matrix,long rowsCols)
        {
           
            for (int i = 0; i < rowsCols; i++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                for (int j = 0; j < rowsCols; j++)
                {
                    matrix[i, j] = input[j];

                }
                
            }

        }
        static void ReadMatrix(int[][] matrix, int rowsCols)
        {

            for (int i = 0; i < rowsCols; i++)
            {
                var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                matrix[i] = input;

            }

        }
    }
}
