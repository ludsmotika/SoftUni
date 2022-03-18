using System;
using System.Collections.Generic;

namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cmd= Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            List<string> ids= new List<string>();
            while (cmd[0]!="End")
            {
                if (cmd[0]=="Citizen" || cmd[0]=="Pet")
                {
                    ids.Add(cmd[cmd.Length - 1]);
                }
                cmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            string n = Console.ReadLine();
            bool isEmpty = true;
            foreach (string id in ids) 
            {
                if (id.EndsWith(n))
                {
                    Console.WriteLine(id);
                    isEmpty = false;
                }
            }
        }
    }
}
