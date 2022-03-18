using System;
using System.Collections.Generic;

namespace _08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> numbers=    new HashSet<string>();
            string invited=Console .ReadLine();
            while (invited !="PARTY")
            {
                numbers.Add(invited);
                invited = Console.ReadLine();
            }
            string guests=Console .ReadLine();
            while (guests!="END")
            {
                numbers.Remove(guests);
                guests = Console.ReadLine();
            }
            Console.WriteLine(numbers.Count);
            foreach (var item in numbers)
            {
                if (item[0]>=48 && item[0] <= 57)
                {
                    Console.WriteLine(item);
                   
                }
            }
            foreach (var item in numbers)
            {
                if (item[0] < 48 || item[0] > 57)
                {
                    Console.WriteLine(item);

                }

            }
        }
    }
}
