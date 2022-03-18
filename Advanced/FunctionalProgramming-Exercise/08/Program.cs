using System;
using System.Collections.Generic;
using System.Linq;

namespace _08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int up = int.Parse(Console.ReadLine());
            Queue<int> down=new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            List<int> collection=new List<int>();
            for (int i = 1; i <= up; i++)
            {
                collection.Add(i);
            }
            List<Predicate<int>> checkEvery= new List<Predicate<int>>();
            foreach (var item in down)
            {
                checkEvery.Add(x => x % item == 0);
            }
            foreach (var item in collection)
            {
                bool isDiv = true;
                foreach (var div in checkEvery )
                {
                    if (!div(item))
                    {
                        isDiv= false;
                    }
                }
                if (isDiv) { Console.Write(item+" "); }
            }
        }
    }
}
