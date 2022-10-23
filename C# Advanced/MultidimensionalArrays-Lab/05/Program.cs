using System;
using System.Collections.Generic;
using System.Linq;

namespace _05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[dimension[0], dimension[1]];
            
            
            for (int i = 0; i < dimension[0]; i++)
            {
                int[] row = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int k = 0; k < dimension[1]; k++)
                {
                    matrix[i, k] = row[k];
                }
            }
            int[] bestCordinates = new int[] { 0,0};
            int bestSum = 0;
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    if (GetSum(row, col, matrix)>bestSum)
                    {
                        bestSum = GetSum(row, col, matrix);
                        bestCordinates[0] = row;
                        bestCordinates[1] = col;
                    }
                }
            }
            Console.WriteLine(matrix[bestCordinates[0], bestCordinates[1]] +" "+ matrix[bestCordinates[0], bestCordinates[1]+1]);
            Console.WriteLine(matrix[bestCordinates[0]+1, bestCordinates[1]] +" "+ matrix[bestCordinates[0]+1, bestCordinates[1]+1]);
            Console.WriteLine(bestSum);
        }
        static public int GetSum(int x, int y, int[,] mat)
        {
            int sum = 0;
            sum+=mat[x,y];
            sum+=mat[x+1,y];
            sum+=mat[x,y+1];
            sum+=mat[x+1,y+1];

            return sum;
        }
    }
}
