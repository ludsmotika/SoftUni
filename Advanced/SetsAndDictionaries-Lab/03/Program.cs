using System;
using System.Linq;

namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
         int[] input=Console.ReadLine().Split(' ').Select(int.Parse).OrderByDescending(x => x).ToArray();
            Console.WriteLine(string.Join(" ",input.Take(3)));
        }
    }
}
