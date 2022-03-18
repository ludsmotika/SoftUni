using System;

namespace _10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int k = 0; k < n; k++)
                {
                    matrix[i, k] = row[k];
                }
            }
            int count = 0;
            while (noOneCanCatch(matrix))
            {
                int[] worstCordinates = new int[] { -1, -1 };
                int worstKnight = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (matrix[i, k] == 'K')
                        {
                            int worstCase = CheckKnight(i, k, matrix, n);
                            if (worstCase > worstKnight)
                            {
                                worstKnight = worstCase;
                                worstCordinates[0] = i;
                                worstCordinates[1] = k;
                            }

                        }
                    }
                }
                matrix[worstCordinates[0], worstCordinates[1]] = '0';
                count++;
            }
            Console.WriteLine(count);
        }

        private static bool noOneCanCatch(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    if (matrix[i, k] == 'K')
                    {
                        if (CheckKnight(i, k, matrix, matrix.GetLength(0)) > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private static int CheckKnight(int i, int k, char[,] mat, int n)
        {
            int canCatch = 0;
            if ((i + 1 < n && k + 2 < n) && mat[i + 1, k + 2] == 'K')
            {
                canCatch++;
            }
            if ((i + 2 < n && k + 1 < n) && mat[i + 2, k + 1] == 'K')
            {
                canCatch++;
            }
            if ((i - 2 >= 0 && k - 1 >= 0) && mat[i - 2, k - 1] == 'K')
            {
                canCatch++;
            }
            if ((i - 1 >= 0 && k - 2 >= 0) && mat[i - 1, k - 2] == 'K')
            {
                canCatch++;
            }
            if ((i - 1 >= 0 && k + 2 < n) && mat[i - 1, k + 2] == 'K')
            {
                canCatch++;
            }
            if ((i + 1 < n && k - 2 >= 0) && mat[i + 1, k - 2] == 'K')
            {
                canCatch++;
            }
            if ((i + 2 < n && k - 1 >= 0) && mat[i + 2, k - 1] == 'K')
            {
                canCatch++;
            }
            if ((i - 2 >= 0 && k + 1 < n) && mat[i - 2, k + 1] == 'K')
            {
                canCatch++;
            }
            return canCatch;
        }
    }
}
