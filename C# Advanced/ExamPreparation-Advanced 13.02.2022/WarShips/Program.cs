using System;
using System.Collections.Generic;
using System.Linq;

namespace WarShips
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[fieldSize, fieldSize];
            int playerOneShips = 0;
            int playerTwoShips = 0;
            for (int i = 0; i < fieldSize; i++)
            {
                char[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int k = 0; k < fieldSize; k++)
                {
                    matrix[i, k] = row[k];
                    if (matrix[i, k] == '<')
                    {
                        playerOneShips++;
                    }
                    else if (matrix[i, k] == '>')
                    {
                        playerTwoShips++;
                    }
                }
            }
            int totalShips = playerTwoShips + playerOneShips;
            int counter = 0;
            while (counter < commands.Length)
            {
                int[] coordinates = commands[counter].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (IsInRange(coordinates, fieldSize))
                {
                    if (matrix[coordinates[0], coordinates[1]] == '>')
                    {
                        playerTwoShips--;
                        matrix[coordinates[0], coordinates[1]] = 'X';
                    }
                    else if (matrix[coordinates[0], coordinates[1]] == '<')
                    {
                        playerOneShips--;
                        matrix[coordinates[0], coordinates[1]] = 'X';
                    }
                    else if (matrix[coordinates[0], coordinates[1]] == '#')
                    {
                        int[] after = Boom(matrix, coordinates, playerOneShips, playerTwoShips, fieldSize);
                        playerOneShips = after[0];
                        playerTwoShips = after[1];
                    }
                }

                counter++;
                if (playerOneShips <= 0 || playerTwoShips <= 0)
                {
                    break;
                }
            }
            if (playerOneShips == 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalShips - (playerOneShips + playerTwoShips)} ships have been sunk in the battle.");
                return;
            }
            if (playerTwoShips == 0)
            {
                Console.WriteLine($"Player One has won the game! {totalShips - (playerOneShips + playerTwoShips)} ships have been sunk in the battle.");
                return;
            }
            Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips } ships left.");


        }

        public static int[] Boom(char[,] matrix, int[] coordinates, int st, int nd, int max)
        {
            for (int i = coordinates[0] - 1; i <= coordinates[0] + 1; i++)
            {
                for (int k = coordinates[1] - 1; k <= coordinates[1] + 1; k++)
                {
                    if (IsInRange(new int[] { i, k }, max))
                    {
                        if (matrix[i, k] == '<')
                        {
                            st--;
                            matrix[i, k] = 'X';
                        }
                        else if (matrix[i, k] == '>')
                        {
                            nd--;
                            matrix[i, k] = 'X';
                        }
                    }
                }
            }
            return new int[] { st, nd };
        }

        public static bool IsInRange(int[] coo, int max)
        {
            return coo[0] >= 0 && coo[1] >= 0 && coo[0] < max && coo[1] < max;
        }
    }
}