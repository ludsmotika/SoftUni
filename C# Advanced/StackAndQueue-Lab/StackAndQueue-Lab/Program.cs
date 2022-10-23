using System;
using System.Collections;
using System.Collections.Generic;

namespace StackAndQueue_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            foreach (char item in input)
            {
                stack.Push(item);
            }
            while (stack.Count>0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
