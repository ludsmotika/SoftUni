using System;
using System.Linq;

namespace FunctionalProgramming_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> appender = x => $"Sir {x}";
            string[] collection = Console.ReadLine().Split(' ').Select(appender).ToArray();
            Action<string[]> print = x => Console.WriteLine(string.Join("\n", x));
            print(collection);
        }
    }
}
