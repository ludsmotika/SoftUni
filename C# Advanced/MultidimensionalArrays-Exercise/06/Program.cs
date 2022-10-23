using System;
using System.Linq;

namespace _06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[n][];
            for (int i = 0; i < n; i++)
            {
                double[] row = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jaggedArray[i]=row;
            }
            for (int i = 0; i <jaggedArray.Length-1; i++)
            {
                if (jaggedArray[i].Count()== jaggedArray[i+1].Count())
                {
                    for (int k = 0; k < jaggedArray[i].Count(); k++)
                    {
                        jaggedArray[i][k] *= 2;
                        jaggedArray[i+1][k] *= 2;
                    }
                }
                else
                {
                    for (int k = 0; k < jaggedArray[i].Count(); k++)
                    {
                        jaggedArray[i][k] /= 2;
                    }
                    for (int k = 0; k < jaggedArray[i+1].Count(); k++)
                    {
                        jaggedArray[i+1][k] /= 2;
                    }
                }
            }
            string[] cmd = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries );
            while (cmd[0]!="End")
            {
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);
                if (row>=0 && row<n && col>=0 && col<jaggedArray[row].Count())
                {
                    switch (cmd[0])
                    {
                        case "Add":
                            jaggedArray[row][col] += value;
                            break;
                        case "Subtract":
                            jaggedArray[row][col] -= value;
                            break;
                        default:
                            break;
                    }
                }
                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < jaggedArray[i].Count(); j++)
                {
                    Console.Write(jaggedArray[i][j]+" ");
                }
                Console.WriteLine();
            }
            return;
        }
    }
}
