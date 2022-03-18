using System;
using System.Linq;

namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] input=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int sumOfFirstDiagonal = 0;
            int sumOfSecondDiagonal = 0;
            int[] cordinates = new int[] {0,0 };
            while (cordinates[0]<n && cordinates[1] < n)
            {
                sumOfFirstDiagonal += matrix[cordinates[0], cordinates[1]];
                cordinates[0]++;
                cordinates[1]++;
            }
            int[] cordinatesSecond = new int[] { n, 0 };
            while (cordinates[0] >= 0 && cordinates[1] < n)
            {
                sumOfSecondDiagonal += matrix[cordinates[0], cordinates[1]];
                cordinatesSecond[0]--;
                cordinatesSecond[1]++;
            }
            if (sumOfFirstDiagonal>sumOfSecondDiagonal)
            {
                Console.WriteLine(sumOfFirstDiagonal);
            }
            else
            {
                Console.WriteLine(sumOfSecondDiagonal);
            }
        }
    }
}
