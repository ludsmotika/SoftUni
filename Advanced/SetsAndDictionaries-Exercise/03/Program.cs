using System;
using System.Collections.Generic;

namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> chemicals=new SortedSet<string>();
            for (int i = 0; i <n; i++)
            {
                string[] row = Console.ReadLine().Split(" ");
                foreach (var item in row)
                {
                    chemicals.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ", chemicals));
        }
    }
}
