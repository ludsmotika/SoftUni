using System;
using System.Collections.Generic;
using System.Linq;

namespace LakeWithStones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] stones = Console.ReadLine().Split(", ").Select(int.Parse).ToArray(); 
           Lake jump= new Lake(stones);
            List<int> coll = new List<int>();
            foreach (var item in jump)
            {
             coll.Add(item);
            }
            Console.WriteLine(String.Join(", ",coll));
        }
    }
}
