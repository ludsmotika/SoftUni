using System;
using System.Collections.Generic;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<char> branches = new List<char>();
            char[,] pond = new char[n, n];
            int[] bCoor = new int[2];
            int countOfAllBranches = 0;
            for (int i = 0; i < n; i++)
            {
                char[] row= Console.ReadLine().Replace(" ","").ToCharArray();
                for (int k = 0; k < n; k++)
                {
                    pond[i, k] = row[k];
                    if (pond[i, k]=='B')
                    {
                        bCoor[0] = i;
                        bCoor[1] = k;
                    }
                    if (pond[i, k] >= 97 && pond[i, k] <= 122)
                    {
                        countOfAllBranches++;
                    }
                }
            }
            string cmd=Console.ReadLine();
            while (cmd!="end")
            {
                pond[bCoor[0], bCoor[1]] = '-';
                Move(bCoor, cmd);
                if (inMatrix(bCoor, n))
                {
                    if (pond[bCoor[0], bCoor[1]] == '-')
                    {
                        pond[bCoor[0], bCoor[1]] = 'B';
                    }
                    else if (pond[bCoor[0], bCoor[1]] == 'F') 
                    {
                        pond[bCoor[0], bCoor[1]] = '-';
                        Move(bCoor, cmd);
                        if (inMatrix(bCoor,n))
                        {
                            for (int i = 0; i < n; i++)
                            {
                                Move(bCoor, cmd);
                                if (inMatrix(bCoor, n)==false)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < n; i++)
                            {
                                MoveOpposite(bCoor, cmd);
                                if (inMatrix(bCoor, n) == false)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if (pond[bCoor[0], bCoor[1]]>=97 && pond[bCoor[0], bCoor[1]] <= 122)
                    {
                        branches.Add(pond[bCoor[0], bCoor[1]]);
                        countOfAllBranches--;
                        pond[bCoor[0], bCoor[1]] = 'B';
                    }
                }
                else
                {
                    MoveOpposite(bCoor, cmd);
                    if (branches.Count>=1)
                    {
                        branches.RemoveAt(branches.Count-1);
                    }
                    pond[bCoor[0], bCoor[1]] = 'B';
                }
                if (countOfAllBranches==0)
                {
                    break;
                }
                cmd = Console.ReadLine();
            }
            int countOfRemaining = 0;
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (pond[i,k] >= 97 && pond[i,k] <= 122)
                    {
                        countOfRemaining++;
                    }
                }
            }
            if (countOfRemaining > 0) 
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countOfRemaining} branches left.");

            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: " + String.Join(", ", branches)+".");
            }
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    Console.Write(pond[i,k]+" ");
                }
                Console.WriteLine();
            }
        }

        private static void MoveOpposite(int[] bCoor, string cmd)
        {
            switch (cmd)
            {
                case "up":
                    bCoor[0]++;
                    break;
                case "down":
                    bCoor[0]--;
                    break;
                case "left":
                    bCoor[1]++;
                    break;
                case "right":
                    bCoor[1]--;
                    break;
                default:
                    break;
            }
        }

        private static bool inMatrix(int[] bCoor,int n)
        {
           return bCoor[0]>=0 && bCoor[1]>=0 && bCoor[0]<n && bCoor[1]<n;
        }

        private static void Move(int[] bCoor, string cmd)
        {
            switch (cmd)
            {
                case "up":
                    bCoor[0]--;
                    break;
                case "down":
                    bCoor[0]++;
                    break;
                case "left":
                    bCoor[1]--;
                    break;
                case "right":
                    bCoor[1]++;
                    break;
                default:
                    break;
            }
        }
    }
}
