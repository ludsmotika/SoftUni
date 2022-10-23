using System;
using System.Collections.Generic;
using System.Linq;

namespace _09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] cmd=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            while (cmd[0]!="Party!")
            {
              Predicate<string> current = GetCurrentPredicate(cmd);
                Func<string, bool> filter = new Func<string, bool>(current);
                if (cmd[0] == "Double")
                {
                    List<string> namesToDouble = people.Where(filter).ToList();
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (namesToDouble.Contains(people[i]))
                        {
                            people.Insert(i,people[i]);
                            i++;
                        }
                    }
                }
                else
                {
                    List<string> toRemove= people.Where(filter).ToList();
                    for (int n = 0; n < people.Count; n++)
                    {
                        if (toRemove.Contains(people[n]))
                        {
                            people.RemoveAt(n);
                            n--;
                        }
                    }
                }
                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (people.Count==0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(String.Join(", ", people) + " are going to the party!");
            }
           
        }

        private static Predicate<string> GetCurrentPredicate(string[] cmd)
        {
             
            if (cmd[1]=="StartsWith")
            {
                return x => x.Substring(0,cmd[2].Length)==cmd[2];
            }
            else if (cmd[1] == "EndsWith")
            {
                return x => x.Substring(x.Length-cmd[2].Length) == cmd[2];
            }
            else
            {
                return x=> x.Length==int.Parse(cmd[2]);
            }
        }
    }
}
