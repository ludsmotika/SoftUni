using System;
using System.Linq;

namespace MultidimensionalArrays_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[dimension[0], dimension[1]];
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            for (int i = 0; i < dimension[0]; i++)
            {
                int[] row = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int k = 0; k < dimension[1]; k++)
                {
                    matrix[i, k] = row[k];
                }
            }
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    sum += matrix[i, k];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
