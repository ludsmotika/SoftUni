using System;
using System.Linq;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] beach = MadeJaggedArray(n);
            string[] cmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int myTokens = 0;
            int opponentTokens = 0;
            while (cmd[0] != "Gong")
            {
                int[] coordinates = new int[] { int.Parse(cmd[1]), int.Parse(cmd[2]) };
                if (cmd[0] == "Find")
                {
                    if (CheckPosition(coordinates, beach, n))
                    {
                        if (beach[coordinates[0]][coordinates[1]] == 'T')
                        {
                            myTokens++;
                            beach[coordinates[0]][coordinates[1]] = '-';
                        }
                    }
                }
                else if (cmd[0] == "Opponent")
                {
                    if (CheckPosition(coordinates, beach, n))
                    {
                        if (beach[coordinates[0]][coordinates[1]] == 'T')
                        {
                            opponentTokens++;
                            beach[coordinates[0]][coordinates[1]] = '-';
                        }
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        coordinates = Moving(cmd[3], coordinates);
                        if (CheckPosition(coordinates, beach, n))
                        {
                            if (beach[coordinates[0]][coordinates[1]] == 'T')
                            {
                                opponentTokens++;
                                beach[coordinates[0]][coordinates[1]] = '-';
                            }
                        }
                        else { break; }
                    }
                }
                cmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            PrintJaggedArray(beach);
            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static void PrintJaggedArray(char[][] beach)
        {
            for (int i = 0; i < beach.GetLength(0); i++)
            {
                Console.WriteLine(String.Join(" ", beach[i]));
            }
        }

        private static int[] Moving(string v, int[] coordinates)
        {
            switch (v)
            {
                case "up":
                    coordinates[0]--;
                    break;
                case "down":
                    coordinates[0]++;
                    break;
                case "left":
                    coordinates[1]--;
                    break;
                case "right":
                    coordinates[1]++;
                    break;
                default:
                    break;
            }
            return coordinates;
        }

        private static bool CheckPosition(int[] coordinates, char[][] beach, int n)
        {
            if (n > coordinates[0] && coordinates[0] >= 0)
            {
                if (beach[coordinates[0]].Length > coordinates[1] && coordinates[1] >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static char[][] MadeJaggedArray(int n)
        {
            char[][] beach = new char[n][];
            for (int i = 0; i < n; i++)
            {
                beach[i] = Console.ReadLine().Replace(" ", "").ToCharArray();
            }
            return beach;
        }
    }
}
