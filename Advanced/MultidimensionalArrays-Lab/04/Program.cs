using System;

namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            char searchFor = char.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (matrix[i,k]==searchFor)
                    {
                        Console.WriteLine($"({i}, {k})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{searchFor} does not occur in the matrix");
        }
    }
}
