using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Dictionary<KeyValuePair<string, int>, int> cooked = new Dictionary<KeyValuePair<string, int>, int>();
            cooked.Add(new KeyValuePair<string, int>("Chocolate cake", 300), 0);
            cooked.Add(new KeyValuePair<string, int>("Dipping sauce", 150), 0);
            cooked.Add(new KeyValuePair<string, int>("Green salad", 250), 0);
            cooked.Add(new KeyValuePair<string, int>("Lobster", 400), 0);
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int ingre = ingredients.Peek();
                int fresh = freshness.Peek();
                int total = ingre*fresh;
                if (ingredients.Peek()==0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                if (freshness.Peek() == 0)
                {
                    freshness.Pop();
                    continue;
                }
                switch (total)
                {
                    case 150:
                        cooked[new KeyValuePair<string, int>("Dipping sauce", 150)]++;
                        flag1 = true;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;
                    case 250:
                        cooked[new KeyValuePair<string, int>("Green salad", 250)]++;
                        flag2 = true;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;
                    case 300:
                        cooked[new KeyValuePair<string, int>("Chocolate cake", 300)]++;
                        flag3 = true;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;
                    case 400:
                        cooked[new KeyValuePair<string, int>("Lobster", 400)]++;
                        flag4 = true;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;
                    default:
                       freshness.Pop();
                        ingredients.Enqueue(ingredients.Dequeue() + 5);
                        break;
                }
            }
            if (flag1&&flag2&&flag3&&flag4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredients.Count>=1)
            {
                Console.WriteLine($"Ingredients left: { ingredients.Sum()}");
            }
            foreach (var item in cooked)
            {
                if (item.Value>=1)
                {
                    Console.WriteLine($" # {item.Key.Key} --> {item.Value}");
                }
            }
        }
    }
}
