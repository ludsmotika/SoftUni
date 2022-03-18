using System;
using System.Linq;

namespace _06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] collection = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            Func<int,bool> check = x => x % n != 0;
            
            Func<int[], int[]> filter = x => x.Where(check).ToArray();
           collection= filter(collection);

            Console.WriteLine(String.Join(" ",collection.Reverse()));
        }
    }
}
