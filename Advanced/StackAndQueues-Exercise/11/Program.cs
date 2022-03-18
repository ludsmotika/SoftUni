using System;
using System.Collections.Generic;
using System.Linq;

namespace _11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfBarrel= int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray()); 
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray()); 
            int valueOfIntellegence=int.Parse(Console.ReadLine());
            int bulletsInBarrel = sizeOfBarrel;
            int totalFiredBullets = 0;
            while (locks.Count>0 && bullets.Count>0)
            {
                if (bulletsInBarrel==0)
                {
                    Console.WriteLine("Reloading!");
                    bulletsInBarrel = sizeOfBarrel;
                }
                bulletsInBarrel--;
                int bullet = bullets.Pop();
                totalFiredBullets++;
                int currentLock= locks.Peek();
                if (bullet > currentLock) 
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
            }
            if (bulletsInBarrel == 0 && bullets.Count>0)
            {
                Console.WriteLine("Reloading!");
            }
            if (locks.Count>=1)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntellegence - (totalFiredBullets * priceOfBullet)}");
            }
            
        }
    }
}
