using System;
using System.Collections.Generic;

namespace _06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,Dictionary<string,int>> wardrobe=  new Dictionary<string,Dictionary<string,int>>();   
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] clothes = input[1].Split(",");
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                foreach (var cloth in clothes)
                {
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color].Add(cloth, 0);
                        
                    }
                    wardrobe[color][cloth]++;
                }
            }
            string[] search = Console.ReadLine().Split(" ");
            string searchColor = search[0];
            string searchCloth= search[1];
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var item in color.Value)
                {
                    if (color.Key.ToLower() == searchColor.ToLower() && item.Key.ToLower() == searchCloth.ToLower())
                    {

                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
