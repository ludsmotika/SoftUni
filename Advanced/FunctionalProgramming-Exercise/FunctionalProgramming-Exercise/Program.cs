using System;

namespace FunctionalProgramming_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string[] collection=Console.ReadLine().Split(' ');
            Action<string[]> print = x => Console.WriteLine(string.Join("\n",x)); 
            print(collection);
        }
    }
}
