using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsAndDictionaries_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
         double[] input=Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Dictionary<double,int> collection=new Dictionary<double,int>();
            foreach (var item in input)
            {
                if (collection .ContainsKey(item))
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
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
