using System;
using System.Linq;

namespace _08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int k = 0; k < n; k++)
                {
                    matrix[i, k] = row[k];
                }
            }
            string[] bombsCoordinates= Console.ReadLine().Split(' ');
            foreach (var bomb in bombsCoordinates)
            {
                int row = bomb.Split(",").Select(int.Parse).ToArray()[0];
                int col = bomb.Split(",").Select(int.Parse).ToArray()[1];
                int valueOfBomb = matrix[row, col];
                if (valueOfBomb<=0)
                {
                    continue;
                }
                for (int i = row-1; i <= row+1; i++)
                {
                    for (int k = col-1; k <= col+1; k++)
                    {
                        if (i==row && k==col)
                        {
                            matrix[i, k] = 0;
                        }
                        else
                        {
                            if (i>=0 && i<n && k >= 0 && k < n)
                            {
                                if (matrix[i, k]>0)
                                {
                                    matrix[i, k] -= valueOfBomb;
                                }
                            }
                        }
                    }
                }
            }
            int count = 0;
            int sum = 0;
            foreach (var item in matrix)
            {
                if (item>0)
                {
                    count++;
                    sum += item;
                }
            }
            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    Console.Write(matrix[i, k]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
