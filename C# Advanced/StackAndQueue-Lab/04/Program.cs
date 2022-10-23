using System;
using System.Collections.Generic;

namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string problem = Console.ReadLine();
            Stack<int> indexes=new Stack<int>();
            for (int i = 0; i < problem.Length; i++)
            {
                if (problem[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (problem[i] == ')') 
                {
                    int n = indexes.Pop();
                    Console.WriteLine(problem.Substring(n,i-n+1));
                }
            }        
        }
    }
}
