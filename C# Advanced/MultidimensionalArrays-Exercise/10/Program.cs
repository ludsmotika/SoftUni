using System;
using System.Linq;

namespace _10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimesions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            char[,] matrix = new char[dimesions[0], dimesions[1]];
            for (int i = 0; i < dimesions[0]; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int k = 0; k < dimesions[1]; k++)
                {
                    matrix[i, k] = row[k];
                }
            }
            char[] changes = Console.ReadLine().ToCharArray();
            int[] pCoordinations = new int[2];
            for (int i = 0; i < dimesions[0]; i++)
            {

                for (int k = 0; k < dimesions[1]; k++)
                {
                    if (matrix[i, k] == 'P')
                    {
                        pCoordinations[0] = i;
                        pCoordinations[1] = k;
                    }
                }
            }
            for (int i = 0; i < changes.Length; i++)
            {
                char move = changes[i];
                matrix[pCoordinations[0], pCoordinations[1]] = '.';
                switch (move)
                {
                    case 'L':
                        pCoordinations[1]--;
                        if (PEscaped(pCoordinations, dimesions))
                        {
                            //DO the new matrix
                            PrintLastMatrix(matrix);
                            PrintWon(new int[] { pCoordinations[0], pCoordinations[1] + 1 }, matrix);
                            return;
                        }
                        break;
                    case 'R':
                        pCoordinations[1]++;
                        if (PEscaped(pCoordinations, dimesions))
                        {
                            PrintLastMatrix(matrix);
                            PrintWon(new int[] { pCoordinations[0], pCoordinations[1] - 1 }, matrix);
                            return;
                        }
                        break;

                    case 'U':
                        pCoordinations[0]--;
                        if (PEscaped(pCoordinations, dimesions))
                        {
                            PrintLastMatrix(matrix);
                            PrintWon(new int[] { pCoordinations[0] + 1, pCoordinations[1] }, matrix);
                            return;
                        }
                        break;

                    case 'D':
                        pCoordinations[0]++;
                        if (PEscaped(pCoordinations, dimesions))
                        {
                            PrintLastMatrix(matrix);
                            PrintWon(new int[] { pCoordinations[0] - 1, pCoordinations[1] }, matrix);
                            return;
                        }
                        break;
                    default:
                        break;
                }
                if (matrix[pCoordinations[0], pCoordinations[1]] == 'B')
                {
                    PrintLastMatrix(matrix);
                    Console.WriteLine($"dead: {pCoordinations[0]} {pCoordinations[1]}");//Lost and print matrix
                    return;
                }
                matrix[pCoordinations[0], pCoordinations[1]] = 'P';
                char[,] newMatrix = GenerateNewBunnies(matrix);
                for (int p = 0; p < newMatrix.GetLength(0); p++)
                {
                    for (int l = 0; l < newMatrix.GetLength(1); l++)
                    {
                        if (newMatrix[p, l] == 'B')
                        {
                            if (matrix[p, l] == 'P')
                            {
                                for (int c = 0; c < newMatrix .GetLength(0); c++)
                                {
                                    for (int x = 0; x < newMatrix.GetLength(1); x++)
                                    {
                                        if (newMatrix[c,x]=='B')
                                        {
                                            matrix[c, x] = 'B';
                                        }
                                    }
                                }
                                Print(matrix);
                                Console.WriteLine($"dead: {p} {l}");//Lost and print matrix
                                return;
                            }
                            else
                            {
                                matrix[p, l] = 'B';
                            }
                        }
                    }
                }
            }
        }
        private static void Print(char[,] matrix)
        {
            for (int p = 0; p < matrix.GetLength(0); p++)
            {
                for (int l = 0; l < matrix.GetLength(1); l++)
                {
                    Console.Write(matrix[p, l]);
                }
                Console.WriteLine();
            }
        }
        static public void PrintLastMatrix(char[,] matrix)
        {
            char[,] newMatrix = GenerateNewBunnies(matrix);
            for (int p = 0; p < newMatrix.GetLength(0); p++)
            {
                for (int l = 0; l < newMatrix.GetLength(1); l++)
                {
                    if (newMatrix[p, l] == 'B')
                    {
                        matrix[p, l] = 'B';
                    }
                }
            }
            for (int p = 0; p < newMatrix.GetLength(0); p++)
            {
                for (int l = 0; l < newMatrix.GetLength(1); l++)
                {
                    Console.Write(matrix[p, l]);
                }
                Console.WriteLine();
            }
        }
        private static void PrintWon(int[] coo, char[,] matrix)
        {

            Console.WriteLine($"won: {coo[0]} {coo[1]}");
        }

        private static char[,] GenerateNewBunnies(char[,] matrix)
        {
            char[,] newBunnies = new char[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i, k] == 'B')
                    {
                        if (!PEscaped(new int[] { i + 1, k }, new int[] { matrix.GetLength(0), matrix.GetLength(1) }))
                        {
                            newBunnies[i + 1, k] = 'B';
                        }
                        if (!PEscaped(new int[] { i - 1, k }, new int[] { matrix.GetLength(0), matrix.GetLength(1) }))
                        {
                            newBunnies[i - 1, k] = 'B';
                        }
                        if (!PEscaped(new int[] { i, k + 1 }, new int[] { matrix.GetLength(0), matrix.GetLength(1) }))
                        {
                            newBunnies[i, k + 1] = 'B';
                        }
                        if (!PEscaped(new int[] { i, k - 1 }, new int[] { matrix.GetLength(0), matrix.GetLength(1) }))
                        {
                            newBunnies[i, k - 1] = 'B';
                        }
                    }
                }
            }
            return newBunnies;
        }

        private static bool PEscaped(int[] pCoordinations, int[] dimesions)
        {
            if (pCoordinations[0] < 0 || pCoordinations[1] < 0 || pCoordinations[0] >= dimesions[0] || pCoordinations[1] >= dimesions[1])
            {
                return true;
            }
            return false;
        }
    }
}
