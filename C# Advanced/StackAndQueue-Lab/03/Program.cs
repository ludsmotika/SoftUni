using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            Stack<int> numbers=new Stack<int>();

            string symbl = "";
            foreach (var item in input)
            {
                int n = 0;

                if (numbers.Count == 2)
                {
                    if (symbl == "+")
                    {
                        numbers.Push(numbers.Pop() + numbers.Pop());
                    }
                    else
                    {
                        int prev = numbers.Pop();
                        numbers.Push(numbers.Pop() - prev);
                    }
                }
                if (int.TryParse(item.ToString(), out n))
                {
                    n = int.Parse(item.ToString());
                    numbers.Push(n);
                }
                else if(item=="+" || item=="-")
                {
                    symbl = item;
                }

            }
            if (symbl == "+")
            {
                numbers.Push(numbers.Pop() + numbers.Pop());
            }
            else
            {
                int prev = numbers.Pop();
                numbers.Push(numbers.Pop() - prev);
            }
            Console.WriteLine(numbers.Pop());
        }
    }
}
