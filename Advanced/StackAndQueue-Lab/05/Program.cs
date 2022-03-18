using System;
using System.Collections.Generic;
using System.Linq;

namespace _05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Queue<int> que = new Queue<int>(input);
            int n = que.Count;
            while (n>0)
            {
                if (que.Peek()%2==0)
                {
                   que.Enqueue(que.Dequeue());
                }
                else
                {
                    que.Dequeue();
                }
                n--;
            }
            Console.WriteLine(String.Join(", ",que));
        }
    }
}
