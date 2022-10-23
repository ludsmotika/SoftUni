using System;
using System.Linq;

namespace CustomComparator
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] collection = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Func<int, int, int> sorting = (x, y) => {
                if ((x % 2 == 0 && y % 2 == 0) || (x % 2 != 0 && y % 2 != 0))
                {
                    if (x - y >= 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                return 0;
            };
            Array.Sort(collection, (x,y)=>sorting(x,y));
            Console.WriteLine(String.Join(" ",collection));
        }
    }
}
