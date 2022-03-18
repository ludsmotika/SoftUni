using System;
using System.Collections.Generic;

namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int,int> numbers= new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }
                else
                {
                    numbers .Add(number, 1);
                }
            }
            foreach (var item in numbers)
            {
                if (item.Value%2==0)
                {
                    Console.WriteLine(item.Key);
                    return;
                }
            }
        }
    }
}
