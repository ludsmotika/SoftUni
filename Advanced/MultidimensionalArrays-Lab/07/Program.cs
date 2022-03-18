using System;

namespace _07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] matrix = new long[n][];
            matrix[0] = new long[] { 1 };
            for (long i = 1; i <n; i++)
            {
                matrix[i] = new long[i+1];
                for (long k = 0; k < matrix[i].Length; k++)
                {
                    if (k==0)
                    {
                        matrix[i][k] = 1;
                    }
                    else if(k == matrix[i].Length-1)
                    {
                        matrix[i][k] = 1;
                    }
                    else
                    {
                        matrix[i][k] = matrix[i-1][k] + matrix[i-1][k-1];
                    }
                }
            }
            foreach (long[] item in matrix)
            {
                Console.WriteLine(String.Join(" ", item));
            }
        }
    }
}
