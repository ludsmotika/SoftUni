using System;
using System.Linq;

namespace MultidimensionalArrays_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rowsAndCols, rowsAndCols];
            for (int i = 0; i < rowsAndCols; i++)
            {
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int k = 0; k < rowsAndCols; k++)
                {
                    matrix[i,k] =row[k];
                }
            }
            int[] coordinates = new int[] { 0, 0 };
            int firstSum = 0;
            while (coordinates[0]<rowsAndCols)
            {
                firstSum += matrix[coordinates[0], coordinates[1]];
                coordinates[0] +=1;
                coordinates[1] +=1;
            }
            int[] secondCoordinates = new int[] { 0, rowsAndCols - 1 };
            int secondSum = 0;
            while (secondCoordinates[0] <= rowsAndCols && secondCoordinates[1]>=0 )
            {
                secondSum += matrix[secondCoordinates[0], secondCoordinates[1]];
                secondCoordinates[0] += 1;
                secondCoordinates[1] -= 1;
            }
            Console.WriteLine(Math.Abs(firstSum-secondSum)) ;
        }
    }
}
