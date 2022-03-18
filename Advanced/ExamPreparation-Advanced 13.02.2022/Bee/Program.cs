using System;

namespace Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int[] beeCordinations = ReadMatrix(matrix, n);
            int flowers = 0;
            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                matrix[beeCordinations[0], beeCordinations[1]] = '.';
                Move(beeCordinations, cmd);
                if (IsInRange(beeCordinations, n))
                {
                    if (matrix[beeCordinations[0], beeCordinations[1]] == 'f')
                    {
                        flowers++;
                    }
                    else if (matrix[beeCordinations[0], beeCordinations[1]] == 'O')
                    {
                        matrix[beeCordinations[0], beeCordinations[1]] = '.';
                        Move(beeCordinations, cmd);
                        if (matrix[beeCordinations[0], beeCordinations[1]] == 'f')
                        {
                            flowers++;
                        }
                    }
                    matrix[beeCordinations[0], beeCordinations[1]] = 'B';
                }
                else
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                cmd = Console.ReadLine();
            }
            if (flowers>=5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-flowers} flowers more");
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    Console.Write(matrix[i,k]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInRange(int[] beeCordinations, int n)
        {
            return beeCordinations[0] >= 0 && beeCordinations[1] >= 0 && beeCordinations[0] < n && beeCordinations[1] < n;
        }

        private static int[] ReadMatrix(char[,] matrix, int n)
        {
            int[] beeCoordinations = new int[2];
            for (int i = 0; i < n; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int k = 0; k < n; k++)
                {
                    matrix[i, k] = row[k];
                    if (matrix[i, k] == 'B')
                    {
                        beeCoordinations[0] = i;
                        beeCoordinations[1] = k;
                    }
                }
            }
            return beeCoordinations;
        }

        private static void Move(int[] beeCordinations, string cmd)
        {
            if (cmd == "right")
            {
                beeCordinations[1]++;
            }
            else if (cmd == "left")
            {
                beeCordinations[1]--;
            }
            else if (cmd == "up")
            {
                beeCordinations[0]--;
            }
            else if (cmd == "down")
            {
                beeCordinations[0]++;
            }
        }
    }
}
