using System;
using System.Collections.Generic;

namespace _05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text= Console.ReadLine();
            SortedDictionary<char,int> collection= new SortedDictionary<char,int>();
            
            foreach (char item in text)
            {
                if (collection.ContainsKey(item))
                {
                    collection[item]++;
                }
                else
                {
                    collection.Add(item, 1);
                }
            }
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
