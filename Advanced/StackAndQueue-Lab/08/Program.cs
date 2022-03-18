using System;
using System.Collections.Generic;

namespace _08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int canPass = int.Parse(Console.ReadLine());
            Queue<string> carsWaiting=new Queue<string>();
            string cmd=Console.ReadLine();
            int passed = 0;
            while (cmd!="end")
            {
                if (cmd=="green")
                {
                    for (int i = 0; i <canPass; i++)
                    {
                        if (carsWaiting.Count >= 1)
                        {
                            Console.WriteLine(carsWaiting.Dequeue() + " passed!");
                            passed++;
                        }
                    }
                }
                else
                {
                    carsWaiting.Enqueue(cmd);
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine($"{passed} cars passed the crossroads.");
        }
    }
}
