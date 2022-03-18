using System;
using System.Collections.Generic;
using System.Linq;

namespace _12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int lostWater = 0;
            while (bottles.Count > 0 && cups.Count > 0)
            {
                int bottle = bottles.Pop();
                int cup = cups.Peek();
                while (cup>0 && bottles.Count>=0)
                {
                    cup -= bottle;
                    if (cup <= 0)
                    {
                        cups.Dequeue();
                        lostWater += -cup;
                    }
                    else if (cup > 0)
                    {
                        bottle=bottles.Pop();
                    }
                }
                
                
            }
            if (bottles.Count==0)
            {
                Console.WriteLine("Cups: "+string.Join(" ", cups));
            }
            else
            {
                Console.WriteLine("Bottles: "+string.Join(" ", bottles));
            }
            Console.WriteLine($"Wasted litters of water: {lostWater}");
        }
    }
}
