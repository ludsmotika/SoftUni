using System;
using System.Collections.Generic;
using System.Linq;

namespace _05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimesions=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            char[,] matrix = new char[dimesions[0], dimesions[1]];
            char[] snake = Console.ReadLine().ToCharArray();
            Queue<char> snakeInQueue = new Queue<char>(snake);
            for (int i = 0; i < dimesions[0]; i++)
            {
                    if (i%2==0)
                    {
                    for (int k = 0; k < dimesions[1]; k++)
                    {
                        char save = snakeInQueue.Dequeue();
                        matrix[i, k] = save;
                        snakeInQueue.Enqueue(save);
                    }
                    }
                    else
                    {
                    for (int k = dimesions[1]-1; k >=0; k--)
                    {
                        char save = snakeInQueue.Dequeue();
                        matrix[i, k] = save;
                        snakeInQueue.Enqueue(save);
                    }
                    }
                
            }
            for (int i = 0; i < dimesions[0]; i++)
            {
                for (int k = 0; k < dimesions[1]; k++)
                {
                    Console.Write(matrix[i,k]);
                }
                Console.WriteLine();
            }
        }
    }
}
