using System;
using System.Linq;

namespace _11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] collection=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Func<char, int> parser = x => (int)x;
            Func<string, bool> func = x => x.ToCharArray().Select(parser).Sum() >= n;
            Console.WriteLine(collection.Where(func).FirstOrDefault());
        }
    }
}
