using System;
using System.Collections.Generic;

namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string,Dictionary<string,double>> products=new SortedDictionary<string,Dictionary<string, double>>();
            string[] cmd=Console.ReadLine().Split(", ");
            while (cmd[0]!="Revision")
            {
                if (products.ContainsKey(cmd[0]))
                {
                    products[cmd[0]].Add(cmd[1], double.Parse(cmd[2]));
                }
                else
                {
                products.Add(cmd[0],new Dictionary<string, double>());
                    products[cmd[0]].Add(cmd[1],double.Parse(cmd[2]));
                }
                cmd = Console.ReadLine().Split(", ");
            }
            foreach (var item in products)
            {
                Console.WriteLine( item.Key+"->" );
                foreach (var prod in item.Value)
                {
                    Console.WriteLine($"Product: {prod.Key}, Price: {prod.Value}");
                }
            }
        }
    }
}
