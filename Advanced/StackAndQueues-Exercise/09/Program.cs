using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string[]> operations=new Stack<string[]>();
            int numberOfCommands = int.Parse(Console.ReadLine());
            StringBuilder answer = new StringBuilder();
            while (numberOfCommands>0)
            {
                string[] cmd = Console.ReadLine().Split();
               
                switch (cmd[0])
                {
                    case "1":
                        answer.Append(string.Join(" ",cmd.Skip(1)));
                        operations.Push(cmd);
                        break;
                    case "2":
                        string toRemove= answer.ToString().Substring(answer.Length - int.Parse(cmd[1]), int.Parse(cmd[1]));
                        answer.Remove(answer.Length-int.Parse(cmd[1]), int.Parse(cmd[1]));
                        cmd[1] = toRemove;
                        operations.Push(cmd);
                        break;
                    case "3":
                        Console.WriteLine(answer[int.Parse(cmd[1])-1]);
                        break;
                    case "4":
                        RemoveLast12Operation(answer, operations);
                        break;
                    default:
                        break;
                }
                numberOfCommands--;
            }
        }

        private static void RemoveLast12Operation(StringBuilder answer, Stack<string[]> operations)
        {
            while (operations.Count>0)
            {
                string[] current=operations.Pop();
                if (current[0] == "1")
                {
                    answer.Replace(current[1], "");
                    return;
                }
                else if (current[0] == "2")
                {
                    answer.Append(current[1]);
                    return;
                }
            }
        }
    }
}
