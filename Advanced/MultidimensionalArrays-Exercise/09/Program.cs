using System;
using System.Linq;

namespace _09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ");
            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] row = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int k = 0; k < n; k++)
                {
                    matrix[i, k] = row[k];
                }
            }
            int[] coordinatesOfMiner = new int[] { -1,-1 };
            int coleOnBoard = 0;
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (matrix[i, k] == 's')
                    {
                        coordinatesOfMiner[0] = i;
                        coordinatesOfMiner[1] = k;
                    }
                    else if (matrix[i, k] == 'c') 
                    {
                        coleOnBoard++;
                    }
                }
            }
            int coleCollected = 0;
            foreach (var command in commands)
            {
                switch (command)
                {
                    case "up":
                        if (CheckCoordinates(coordinatesOfMiner[0]-1,coordinatesOfMiner[1],n))
                        {
                            if (matrix[coordinatesOfMiner[0] - 1, coordinatesOfMiner[1]]=='e')
                            {
                                coordinatesOfMiner[0]--;
                                Console.WriteLine($"Game over! ({coordinatesOfMiner[0]}, {coordinatesOfMiner[1]})");
                                return;
                            }
                            else if (matrix[coordinatesOfMiner[0] - 1, coordinatesOfMiner[1]] == '*')
                            {
                                matrix[coordinatesOfMiner[0], coordinatesOfMiner[1]] = '*';
                                matrix[coordinatesOfMiner[0] - 1, coordinatesOfMiner[1]] = 's';
                                coordinatesOfMiner[0]--;
                            }
                            else if(matrix[coordinatesOfMiner[0] - 1, coordinatesOfMiner[1]] == 'c')
                            {
                                matrix[coordinatesOfMiner[0], coordinatesOfMiner[1]] = '*';
                                matrix[coordinatesOfMiner[0] - 1, coordinatesOfMiner[1]] = 's';
                                coordinatesOfMiner[0]--;
                                coleCollected++;
                                if (coleCollected==coleOnBoard)
                                {
                                    Console.WriteLine($"You collected all coals! ({coordinatesOfMiner[0]}, {coordinatesOfMiner[1]})");
                                    return;
                                }
                            }
                        }
                        break;
                    case "down":
                        if (CheckCoordinates(coordinatesOfMiner[0] + 1, coordinatesOfMiner[1], n))
                        {
                            if (matrix[coordinatesOfMiner[0] + 1, coordinatesOfMiner[1]] == 'e')
                            {
                                coordinatesOfMiner[0]++;
                                Console.WriteLine($"Game over! ({coordinatesOfMiner[0]}, {coordinatesOfMiner[1]})");
                                return;
                            }
                            else if (matrix[coordinatesOfMiner[0] + 1, coordinatesOfMiner[1]] == '*')
                            {
                                matrix[coordinatesOfMiner[0], coordinatesOfMiner[1]] = '*';
                                matrix[coordinatesOfMiner[0] +1, coordinatesOfMiner[1]] = 's';
                                coordinatesOfMiner[0]++;
                            }
                            else if (matrix[coordinatesOfMiner[0] + 1, coordinatesOfMiner[1]] == 'c')
                            {
                                matrix[coordinatesOfMiner[0], coordinatesOfMiner[1]] = '*';
                                matrix[coordinatesOfMiner[0] +1, coordinatesOfMiner[1]] = 's';
                                coordinatesOfMiner[0]++;
                                coleCollected++;
                                if (coleCollected == coleOnBoard)
                                {
                                    Console.WriteLine($"You collected all coals! ({coordinatesOfMiner[0]}, {coordinatesOfMiner[1]})");
                                    return;
                                }
                            }
                        }
                        break;
                    case "left":
                        if (CheckCoordinates(coordinatesOfMiner[0], coordinatesOfMiner[1]-1, n))
                        {
                            if (matrix[coordinatesOfMiner[0] , coordinatesOfMiner[1]-1] == 'e')
                            {
                                coordinatesOfMiner[1]--;
                                Console.WriteLine($"Game over! ({coordinatesOfMiner[0]}, {coordinatesOfMiner[1]})");
                                return;
                            }
                            else if (matrix[coordinatesOfMiner[0], coordinatesOfMiner[1]-1] == '*')
                            {
                                matrix[coordinatesOfMiner[0], coordinatesOfMiner[1]] = '*';
                                matrix[coordinatesOfMiner[0] , coordinatesOfMiner[1]-1] = 's';
                                coordinatesOfMiner[1]--;
                            }
                            else if (matrix[coordinatesOfMiner[0] , coordinatesOfMiner[1]-1] == 'c')
                            {
                                matrix[coordinatesOfMiner[0], coordinatesOfMiner[1]] = '*';
                                matrix[coordinatesOfMiner[0] , coordinatesOfMiner[1]-1] = 's';
                                coordinatesOfMiner[1]--;
                                coleCollected++;
                                if (coleCollected == coleOnBoard)
                                {
                                    Console.WriteLine($"You collected all coals! ({coordinatesOfMiner[0]}, {coordinatesOfMiner[1]})");
                                    return;
                                }
                            }
                        }
                        break;
                    case "right":
                        if (CheckCoordinates(coordinatesOfMiner[0], coordinatesOfMiner[1] + 1, n))
                        {
                            if (matrix[coordinatesOfMiner[0], coordinatesOfMiner[1] +1] == 'e')
                            {
                                coordinatesOfMiner[1]++;
                                Console.WriteLine($"Game over! ({coordinatesOfMiner[0]}, {coordinatesOfMiner[1]})");
                                return;
                            }
                            else if (matrix[coordinatesOfMiner[0], coordinatesOfMiner[1] + 1] == '*')
                            {
                                matrix[coordinatesOfMiner[0], coordinatesOfMiner[1]] = '*';
                                matrix[coordinatesOfMiner[0], coordinatesOfMiner[1] + 1] = 's';
                                coordinatesOfMiner[1]++;
                            }
                            else if (matrix[coordinatesOfMiner[0], coordinatesOfMiner[1] + 1] == 'c')
                            {
                                matrix[coordinatesOfMiner[0], coordinatesOfMiner[1]] = '*';
                                matrix[coordinatesOfMiner[0], coordinatesOfMiner[1] + 1] = 's';
                                coordinatesOfMiner[1]++;
                                coleCollected++;
                                if (coleCollected == coleOnBoard)
                                {
                                    Console.WriteLine($"You collected all coals! ({coordinatesOfMiner[0]}, {coordinatesOfMiner[1]})");
                                    return;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
                
            }
            Console.WriteLine($"{coleOnBoard - coleCollected} coals left. ({coordinatesOfMiner[0]}, {coordinatesOfMiner[1]})");
        }
        static public bool CheckCoordinates(int row,int col ,int n) 
        {
            if (row<0 || col>=n || row>=n || col <0)
            {
                return false;
            }
            return true;
        }
    }
}
