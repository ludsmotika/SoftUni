using System;
using System.Linq;

namespace FunctionalProgramming_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] collection = Console.ReadLine().Split(", ").Select(int.Parse).Where(x => x % 2 == 0).ToArray();
            Console.WriteLine(String.Join(", ", collection.OrderBy(x=>x)));
        }
    }
}
