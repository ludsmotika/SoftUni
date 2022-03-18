using System;
using System.Linq;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input=Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            char[,] matrix = new char[input[0], input[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] currentRow= Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i,k]=currentRow[k];
                }
            }
            int countOfSquares = 0;
            int[] coordinates = new int[] { 0,0};
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int k = 0; k < matrix.GetLength(1) - 1; k++)
                {
                    char currentChar = matrix[i, k];
                    if (currentChar==matrix[i,k+1] && currentChar == matrix[i+1, k ]&& currentChar == matrix[i+1, k + 1])
                    {
                        countOfSquares++;
                    }
                }
            }
            Console.WriteLine(countOfSquares);
        }
    }
}
