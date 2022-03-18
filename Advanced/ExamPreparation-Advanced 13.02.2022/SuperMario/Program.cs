using System;
using System.Linq;

namespace SuperMario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int row = int.Parse(Console.ReadLine());
            char[][] matrix = new char[row][];
            int[] marioCoordinates = new int[2];


            for (int i = 0; i < row; i++)
            {
                string currentRow = Console.ReadLine();
                matrix[i] = new char[currentRow.Length];
                for (int k = 0; k < currentRow.Length; k++)
                {
                    matrix[i][k] = currentRow[k];
                    if (matrix[i][k] == 'M')
                    {
                        marioCoordinates[0] = i;
                        marioCoordinates[1] = k;
                    }
                }
            }

            while (lives > 0)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = command[0];
                int xOfBow = int.Parse(command[1]);
                int yOfBow = int.Parse(command[2]);
                if (CheckPosition(xOfBow, yOfBow, row))
                {
                    if (matrix[xOfBow][yOfBow] != 'P' && matrix[xOfBow][yOfBow] != 'M')
                    {
                        matrix[xOfBow][yOfBow] = 'B';
                    }
                }
                matrix[marioCoordinates[0]][marioCoordinates[1]] = '-';
                MoveMario(direction, marioCoordinates, row);
                lives--;
                if (matrix[marioCoordinates[0]][marioCoordinates[1]] == 'B')
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        matrix[marioCoordinates[0]][marioCoordinates[1]] = 'X';
                        Console.WriteLine($"Mario died at {marioCoordinates[0]};{marioCoordinates[1]}.");
                        PrintMartix(matrix);
                        return;
                    }
                    else
                    {
                        matrix[marioCoordinates[0]][marioCoordinates[1]] = 'M';
                    }
                }
                else if (matrix[marioCoordinates[0]][marioCoordinates[1]] == '-')
                {
                    matrix[marioCoordinates[0]][marioCoordinates[1]] = 'M';
                }
                else if (matrix[marioCoordinates[0]][marioCoordinates[1]] == 'P')
                {
                    matrix[marioCoordinates[0]][marioCoordinates[1]] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    PrintMartix(matrix);
                    return;
                }
            }
            matrix[marioCoordinates[0]][marioCoordinates[1]] = 'X';
            Console.WriteLine($"Mario died at {marioCoordinates[0]};{marioCoordinates[1]}.");
            PrintMartix(matrix);
        }

        private static void PrintMartix(char[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix[i].Length; k++)
                {
                    Console.Write($"{matrix[i][k]}");
                }
                Console.WriteLine();
            }
        }

        private static void MoveMario(string direction, int[] marioCoordinates, int max)
        {
            switch (direction)
            {
                case "W":
                    if (CheckPosition(marioCoordinates[0] - 1, marioCoordinates[1], max))
                    {
                        marioCoordinates[0]--;
                    }
                    break;
                case "A":
                    if (CheckPosition(marioCoordinates[0], marioCoordinates[1] - 1, max))
                    {
                        marioCoordinates[1]--;
                    }
                    break;
                case "S":
                    if (CheckPosition(marioCoordinates[0] + 1, marioCoordinates[1], max))
                    {
                        marioCoordinates[0]++;
                    }
                    break;
                case "D":
                    if (CheckPosition(marioCoordinates[0], marioCoordinates[1] + 1, max))
                    {
                        marioCoordinates[1]++;
                    }
                    break;
                default:
                    break;
            }
        }

        public static bool CheckPosition(int x, int y, int max)
            {
            if(x<0 || x >= max || y < 0 || y >= max)
            {
                return false;
            }
            return true;
        }
    }
}
