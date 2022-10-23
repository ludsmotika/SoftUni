using System;
using System.Collections.Generic;

namespace _07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cmd=Console.ReadLine().Split(", ");
            HashSet<string> plates=new HashSet<string>();
            while (cmd[0]!="END")
            {
                if (cmd[0] == "IN")
                {
plates.Add(cmd[1]);
                }
                else 
                {
                plates.Remove(cmd[1]);
                }
                cmd = Console.ReadLine().Split(", ");
            }
            if (plates.Count==0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var item in plates)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
