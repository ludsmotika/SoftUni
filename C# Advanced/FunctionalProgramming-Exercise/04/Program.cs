using System;
using System.Collections.Generic;
using System.Linq;

namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Predicate<int> onlyEven = GetInfo(Console.ReadLine());
            List<int> collection= new List<int>();
            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                collection.Add(i);
            }
            collection = collection.FindAll(onlyEven).ToList();
            Console.WriteLine(String.Join(" ",collection));
        }

        private static Predicate<int> GetInfo(string v)
        {
            if (v == "even")
            {
                return x => x % 2 == 0;
             }
            else
            {
                return x => x % 2 != 0;
            }
        }
    }
}
