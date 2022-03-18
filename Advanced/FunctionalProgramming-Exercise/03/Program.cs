using System;
using System.Linq;

namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] collection = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Func<int[], int> smallest = x=>x.Min();
            Console.WriteLine(smallest(collection));
        }
    }
}
