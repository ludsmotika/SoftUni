using System;
using System.Linq;

namespace _06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            string[] cmd=Console.ReadLine().Split(' ');
            while (cmd[0]!="END")
            {
                int x=int.Parse(cmd[1]);
                int y=int.Parse(cmd[2]);
                int value=int.Parse(cmd[3]);
                if (x>=n || x<0 || y>=n || y<0)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                if(cmd[0] == "Add")
                {
                        matrix[x, y] += value;
                }
                else
                {
                        matrix[x, y] -= value;
                    }
                }
                
                cmd = Console.ReadLine().Split(' ');
            }
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]+" ");

                }
                Console.WriteLine();
            }
        }
    }
}
