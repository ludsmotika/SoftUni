using System;
using System.Linq;

namespace CustomStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> coll= new Stack<string>();
            string[] input= Console.ReadLine().Substring(5).Split(", ");
            coll.Push(input);
            string[] cmd=Console.ReadLine().Split(" ");
            Func<string, string> recreate = x =>  x.Substring(0, x.Length - 1).Length==0 ?  x :  x.Substring(0, x.Length - 1);
            while (cmd[0] !="END")
            {
                if (cmd[0] == "Push")
                {
                    string[] arr = cmd.Skip(1).ToArray();
                    coll.Push(cmd.Skip(1).Select(recreate).ToArray());
                }
                else 
                {
                    coll.Pop();
                }
                cmd = Console.ReadLine().Split(" ");
            }
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }
        }
    }
}
