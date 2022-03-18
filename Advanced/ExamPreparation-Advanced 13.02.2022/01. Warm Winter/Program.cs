using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats=new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            List<int> sets = new List<int>();
            while (hats.Count>0 && scarfs.Count>0)
            {
                int currentHat = hats.Peek();
                int currentScarf=scarfs.Peek();
                if (currentHat > currentScarf)
                {
                    sets.Add(currentScarf + currentHat);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (currentHat < currentScarf)
                {
                    hats.Pop();
                }
                else 
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop()+1);
                    for (int i = 0; i < hats.Count-1; i++)
                    {
                        hats.Push(hats.Pop());
                    }
                }
            }
            Console.WriteLine("The most expensive set is: "+sets.Max());
            Console.WriteLine(String.Join(" ",sets));
        }
    }
}
