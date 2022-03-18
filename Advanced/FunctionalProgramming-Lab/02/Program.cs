using System;
using System.Linq;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
         Func<string ,int> parser = x => int.Parse(x);
            int[] collection = Console.ReadLine().Split(", ").Select(parser).ToArray();
            Console.WriteLine(collection.Count());
            Console.WriteLine(collection.Sum());
        }
    }
}
