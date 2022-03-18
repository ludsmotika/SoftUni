using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> collection=new List<Person> ();
            string[] currentPerson=Console.ReadLine().Split(" ");
            while (currentPerson[0]!="END")
            {
                collection.Add(new Person { Name = currentPerson[0],Age=int.Parse(currentPerson[1]),Town=currentPerson[2] });
                currentPerson = Console.ReadLine().Split(" ");
            }
            collection.Sort();
            int n= int.Parse(Console.ReadLine());
            Person toCheck = collection[n-1];
            int same = 0;
            foreach (var item in collection)
            {
                if (item.CompareTo(toCheck)==0)
                {
                    same++;
                }
            }
            if (same==1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{same} {collection.Count-same} {collection.Count}");
            }
        }
    }
}
