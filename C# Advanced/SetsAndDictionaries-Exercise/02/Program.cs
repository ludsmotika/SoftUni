using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
int[] input=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            for (int i = 0; i < input[0]; i++)
            {
                first.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < input[1]; i++)
            {
                second.Add(int.Parse(Console.ReadLine()));
            }
            List<int> output = new List<int>();
            foreach (int i in first)
            {
                if (second.Contains(i))
                {
                    output.Add(i);
                }
            }
            Console.WriteLine(String.Join(" ",output));
        }
    }
}
