using System;
using System.Linq;

namespace _05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] collection = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Func<int, int> adding = y => ++y;
            Func<int[], int[]> add = x => x.Select(adding).ToArray();
            Func<int, int> subtrackting = y => --y;
            Func<int[], int[]> sub = x => x.Select(subtrackting).ToArray();
            Func<int, int> multipling = y => y*=2;
            Func<int[], int[]> mul= x => x.Select(multipling).ToArray();
            string cmd = Console.ReadLine();
            while (cmd!="end")
            {
                switch (cmd)
                {
                    case "add":
                        collection=add(collection);
                        break;
                    case "subtract":
                        collection = sub(collection);
                        break;
                    case "multiply":
                        collection = mul(collection);
                        break;
                    case "print":
                        Console.WriteLine(String.Join(" ",collection));
                        break;
                    default:
                        break;
                }
                cmd = Console.ReadLine();
            }
        }
    }
}
