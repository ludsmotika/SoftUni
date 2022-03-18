using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] startingInput= Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> stack= new Stack<int>(startingInput);
            string[] cmd=Console.ReadLine().ToLower().Split(" ").ToArray();
            while (cmd[0]!="end")
            {
                switch (cmd[0])
                {
                    case "add":
                        for (int i = 1; i < cmd.Length; i++)
                        {
                            stack.Push(int.Parse(cmd[i]));
                        }
                        break;
                    case "remove":
                        int elementsToRemove = int.Parse(cmd[1]);
                        if (elementsToRemove<stack.Count)
                        {
                            for (int i = 0; i < elementsToRemove; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                    default:
                        break;
                }
                cmd = Console.ReadLine().ToLower().Split(" ").ToArray();
            }
            int sum = 0;
            while (stack.Count>0)
            {
                sum += stack.Pop();
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
