using System;
using System.Collections.Generic;

namespace SetsAndDictionaries_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> collection=new HashSet<string>();
            for (int i = 0; i <n; i++)
            {
                string text = Console.ReadLine();
                collection.Add(text);
            }
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
