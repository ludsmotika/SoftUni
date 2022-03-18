using System;
using System.Collections.Generic;
using System.Linq;

namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int preparedFood=int.Parse(Console.ReadLine());
            Queue<int> orders=new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Console.WriteLine(orders.Max());
            int n=orders.Count();
            for (int i = 0; i < n; i++)
            {
                if(preparedFood >= orders.Peek())
                {
                    preparedFood -= orders.Dequeue();
                    
                }
                else
                {
                    break;
                }

            }
            
                
            
            if (orders.Count>=1)
            {
                Console.WriteLine($"Orders left: {string.Join(" ",orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
            


        }
    }
}
