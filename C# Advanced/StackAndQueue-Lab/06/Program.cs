using System;
using System.Collections.Generic;

namespace _06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> waiting=new Queue<string>();
            string cmd=Console.ReadLine();
            while (cmd!="End")
            {
                if (cmd=="Paid")
                {
                    while (waiting.Count>0)
                    {
                        Console.WriteLine(waiting.Dequeue());
                    }
                }
                else
                {
                    waiting.Enqueue(cmd);
                }
                cmd = Console.ReadLine();

            }
            Console.WriteLine($"{waiting.Count} people remaining.");
        }
    }
}
