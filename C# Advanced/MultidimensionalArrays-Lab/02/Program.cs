using System;
using System.Linq;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[dimension[0], dimension[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            int[] colSums = new int[matrix.GetLength(1)];
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int currentSum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    currentSum += matrix[row,col];
                }
                colSums[col] = currentSum;
            }
            Console.WriteLine(String.Join("\n",colSums));
        }
    }
}
