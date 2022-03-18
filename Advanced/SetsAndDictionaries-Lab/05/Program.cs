using System;
using System.Collections.Generic;

namespace _05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> collection = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] input=Console.ReadLine().Split(' ');
                string continent = input[0];
                string country = input[1];
                string city = input[2];
                if (collection.ContainsKey(continent))
                {
                    if (!collection[continent].ContainsKey(country))
                    {
                        collection[continent].Add(country, new List<string>());

                    }
                    collection[continent][country].Add(city);
                }
                else
                {
                    collection.Add(continent,new Dictionary<string, List<string>>());
                    if (!collection[continent].ContainsKey(country))
                    {
                        collection[continent].Add(country, new List<string>());

                    }
                        collection[continent][country].Add(city);
                    
                }
            }
            foreach (var item in collection)
            {
                Console.WriteLine(item.Key+":");
                foreach (var country in item.Value)
                {
                    Console.WriteLine(country.Key+" -> "+string.Join(", ",country.Value));
                }
            }
        }
    }
}
