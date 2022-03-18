using System;
using System.Collections.Generic;
using System.Linq;

namespace StackAndQueues_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] asd = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int elementsCount = input[0];
            int elementsToPop = input[1];
            if (elementsToPop >= elementsCount)
            {
                Console.WriteLine(0);
                return;
            }
            int searchFor = input[2];
            Queue<int> collection = new Queue<int>();
            for (int i = 0; i < elementsCount; i++)
            {
                collection.Enqueue(asd[i]);
            }
            for (int i = 0; i < elementsToPop; i++)
            {
                collection.Dequeue();
            }
            if (collection.Contains(searchFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(collection.Min());
            }
        }
    }
}
