using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            Stack<int> collection = new Stack<int>();
           
            for (int i = 0; i < n; i++)
            {
                int[] cmd = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (cmd[0]==1)
                {
                    collection.Push(cmd[1]);
                }
                else if (cmd[0]==2)
                {
                    if (collection.Count>=1)
                    {
                        collection.Pop();
                    }
                    
                }
                else if(cmd[0]==3)
                {
                    if (collection.Count>=1)
                    {
                        Console.WriteLine(collection.Max());
                    }
                   
                }
                else
                {
                    if (collection.Count >= 1)
                    {
                        Console.WriteLine(collection.Min());
                    }
                }

            }
            Console.WriteLine(String.Join(", ",collection));
        }
    }
}
