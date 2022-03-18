using System;
using System.Linq;

namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = x => x[0] == char.ToUpper(x[0]); 
            string[] words = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries ).Where(checker).ToArray();
            Console.WriteLine(string.Join("\n",words));
        }
    }
}
