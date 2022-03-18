using System;
using System.Linq;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[,] matrix = new int[input[0], input[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i, k] = currentRow[k];
                }
            }
            int bestSum = 0;
            int[] bestCoordinates=new int[] { 0,0};
            int[] coordinates = new int[] { 0, 0 };
            for (int i = 0; i < matrix.GetLength(0)-2; i++)
            {
                for (int k = 0; k < matrix.GetLength(1) - 2; k++)
                {
                    int currentSum = GetSum3x3(new int[] { i, k }, matrix);
                    if (currentSum>bestSum)
                    {
                        bestSum = currentSum;
                        bestCoordinates[0] = i;
                        bestCoordinates[1] = k;
                    }  
                }
            }
            Console.WriteLine("Sum = " +bestSum);

            for (int i = bestCoordinates[0]; i < bestCoordinates[0]+3; i++)
            {
                for (int k = bestCoordinates[1]; k < bestCoordinates[1] + 3; k++)
                {
                    Console.Write(matrix[i,k]+" ");
                }
                Console.WriteLine();
            }
        }
        static public int GetSum3x3(int[] coor, int[,] mat) 
        {
            int sum = 0;
            for (int i = coor[0]; i < coor[0]+ 3; i++)
            {
                for (int k = coor[1]; k < coor[1]+ 3; k++)
                {
                    sum += mat[i, k];
                }
            }
            return sum;
        }
    }
}
