using System;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split(" ").Select(double.Parse).ToArray());
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split(" ").Select(double.Parse).ToArray());
            Dictionary<string, int> cooked = new Dictionary<string, int>();
            cooked.Add("Bagel", 0);
            cooked.Add("Baguette", 0);
            cooked.Add("Croissant", 0);
            cooked.Add("Muffin", 0);
            while (flour.Count>0 && water.Count>0)
            {
                double currentWater = water.Dequeue();
                double currentFlour= flour.Pop();
                double sum = currentWater + currentFlour;
                if (currentWater == currentFlour)
                {
                    cooked["Croissant"]++;
                }
                else if ((currentWater*100)/sum==40)
                {
                    cooked["Muffin"]++;
                }
                else if ((currentWater * 100) / sum == 30)
                {
                    cooked["Baguette"]++;
                }
                else if ((currentWater * 100) / sum == 20)
                {
                    cooked["Bagel"]++;
                }
                else
                {
                    cooked["Croissant"]++;
                    currentFlour -= currentWater;
                    flour =  new Stack<double>(flour.Reverse());
                    flour.Push(currentFlour);
                    flour = new Stack<double>(flour.Reverse());
                }

            }
            cooked = cooked.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            foreach (var item in cooked)
            {
                if (item.Key=="Bagel" && cooked["Bagel"] >= 1)
                {
                    Console.WriteLine($"Bagel: {cooked["Bagel"]}");
                }
                if (item.Key == "Baguette" && cooked["Baguette"] >= 1)
                {
                    Console.WriteLine($"Baguette: {cooked["Baguette"]}");
                }
                if (item.Key == "Croissant" && cooked["Croissant"] >= 1)
                {
                    Console.WriteLine($"Croissant: {cooked["Croissant"]}");
                }
                if (item.Key == "Muffin" && cooked["Muffin"] >= 1)
                {
                    Console.WriteLine($"Muffin: {cooked["Muffin"]}");
                }
            }
           
            if (water.Count>=1)
            {
                Console.WriteLine("Water left: "+String.Join(", ",water));
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flour.Count >= 1)
            {
                Console.WriteLine("Flour left: " + String.Join(", ", flour));
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }

        }
    }
}
