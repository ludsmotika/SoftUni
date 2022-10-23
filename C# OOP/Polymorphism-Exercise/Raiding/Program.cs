using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> col= new List<BaseHero>();
            while (col.Count<n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                switch (type)
                {
                    case "Druid":
                        col.Add(new Druid(name));
                        break;
                    case "Paladin":
                        col.Add(new Paladin(name));
                        break;
                    case "Rogue":
                        col.Add(new Rogue(name));
                        break;
                    case "Warrior":
                        col.Add(new Warrior(name));
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }
              
            
            int toBeat = int.Parse(Console.ReadLine());
            int sum = 0;
            foreach (var item in col)
            {
                sum += item.Power;
                Console.WriteLine(item.CastAbility());
            }
            if (toBeat>sum)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}
