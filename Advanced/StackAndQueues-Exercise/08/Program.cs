using System;
using System.Collections.Generic;

namespace _08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string problem= Console.ReadLine();
            Stack<char> brackets= new Stack<char>();
            foreach (char item in problem)
            {
                if (brackets.Count == 0)
                {
                    brackets.Push(item);
                }
                else
                {
                    //if (item == brackets.Peek())
                    //{
                    //    brackets.Pop();
                    //}
                    if (item == ')' && brackets.Peek() == '(')
                    {
                        brackets.Pop();
                    }
                    else if (item == '}' && brackets.Peek() == '{')
                    {
                        brackets.Pop();
                    }
                    else if (item == ']' && brackets.Peek() == '[')
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        brackets.Push(item);
                    }
                }
              
            }
            if (brackets.Count==0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
