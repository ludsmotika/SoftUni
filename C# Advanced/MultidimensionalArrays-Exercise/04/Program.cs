using System;
using System.Linq;

namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            string[,] matrix = new string[input[0], input[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i, k] = currentRow[k];
                }
            }
            string[] cmd = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            while (cmd[0]!="END")
            {
                if (CheckCommand(cmd,input))
                {
                    string save= matrix[int.Parse(cmd[1]), int.Parse(cmd[2])];
                    matrix[int.Parse(cmd[1]), int.Parse(cmd[2])]=matrix[int.Parse(cmd[3]),int.Parse(cmd[4])];
                    matrix[int.Parse(cmd[3]), int.Parse(cmd[4])] = save;
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.Write(matrix[i,k]+" ");
                }
                Console.WriteLine();
            }
        }

        private static bool CheckCommand(string[] cmd, int[] input)
        {
            bool valid = true;
            if (cmd.Length!=5)
            {
                return false;
            }
            if (cmd[0]!="swap")
            {
                return false;
            }
            int rowA = int.Parse(cmd[1]);
            int colA = int.Parse(cmd[2]);
            int rowB = int.Parse(cmd[3]);
            int colB = int.Parse(cmd[4]);
            if ((rowA<0 || rowA>input[0]) && (rowB<0 || rowB >input[0]))
            {
                valid = false;
            }
            if ((colA < 0 || colA > input[1]) && (colB < 0 || colB > input[1]))
            {
                valid = false;
            }
            return valid;
        }
    }
}
