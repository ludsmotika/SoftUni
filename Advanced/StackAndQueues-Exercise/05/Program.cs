using System;
using System.Collections.Generic;
using System.Linq;

namespace _05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes=new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());
            int currentCap = 0;
            int racks = 1;
            while (clothes.Count>0)
            {
                if (clothes.Peek()+currentCap>rackCapacity)
                {
                    racks++;
                    currentCap = 0;
                }
                else if (clothes.Peek()+currentCap<rackCapacity )
                {
                    currentCap += clothes.Pop();
                }
                else
                {
                    clothes.Pop();
                    currentCap = 0;
                    if (clothes.Count>0)
                    {
                        racks++;
                    }
                    
                }
            }
            Console.WriteLine(racks);
        }
    }
}
