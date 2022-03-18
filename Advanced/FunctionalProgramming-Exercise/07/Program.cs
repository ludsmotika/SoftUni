using System;
using System.Linq;

namespace _07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string[] collection=Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> sortLength = x => x.Length <= lenght;
            Func<string[], string[]> filter = x => x.Where(sortLength).ToArray();
            collection=filter(collection);
            Console.WriteLine(string.Join("\n",collection));
        }
    }
}
