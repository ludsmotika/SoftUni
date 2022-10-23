using System;
using System.Collections.Generic;

namespace _07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> people= new Queue<string>(Console.ReadLine().Split(" "));
            int steps= int.Parse(Console.ReadLine());
            int counter = 1;
            while (people.Count >1)
            {
                if (counter ==steps)
                {
                    Console.WriteLine($"Removed {people.Dequeue()}");
                    counter = 0;
                }
                else
                {
                    people.Enqueue(people.Dequeue());
                }
                counter++;
            }
            Console.WriteLine($"Last is {people.Dequeue()}");
        }
    }
}
