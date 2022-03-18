using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> collection= new List<Person>();
            int n = int.Parse(Console.ReadLine());

            Func<int, bool> toAdd = x => x > 30;
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ");
                if (toAdd(int.Parse(info[1]))) { collection.Add(new Person(info[0], int.Parse(info[1]))); }
            }
            collection = collection.OrderBy(x=>x.Name).ToList();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
