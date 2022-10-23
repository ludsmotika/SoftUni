using System;
using System.Collections.Generic;
using System.Linq;

namespace _07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split(" ");
            Dictionary<string, List<HashSet<string>>> vlog = new Dictionary<string, List<HashSet<string>>>();
            while (cmd[0]!="Statistics")
             {
                if (cmd[1] == "joined" && !vlog.ContainsKey(cmd[0]))
                {
                    vlog.Add(cmd[0], new List<HashSet<string>>() { new HashSet<string>(), new HashSet<string>()});
                }
                else
                {
                    if (vlog.ContainsKey(cmd[0]) && vlog.ContainsKey(cmd[2]) && (cmd[0]!=cmd[2]))
                    {
                        vlog[cmd[2]][0].Add(cmd[0]);
                        vlog[cmd[0]][1].Add(cmd[2]);
                        
                    }
                }
                cmd = Console.ReadLine().Split(" ");
            }
            vlog = vlog.OrderByDescending(x=> x.Value[0].Count).ThenBy(x => x.Value[1].Count).ToDictionary(x=>x.Key, y=>y.Value);
//            KeyValuePair<string, KeyValuePair<HashSet<string>, HashSet<string>>> best = vlog.First();
            Console.WriteLine($"The V-Logger has a total of {vlog.Count} vloggers in its logs.");
            int count = 1;
            foreach (var item in vlog)
            {
                if (count==1)
                {
                    Console.WriteLine($"1. {item.Key} : {item.Value[0].Count} followers, {item.Value[1].Count} following");
                    item.Value[0] = item.Value[0].OrderBy(x => x).ToHashSet();
                    foreach (var follower in item.Value[0])
                    {
                        Console.WriteLine("*  " + follower);
                    }
                }
                else
                {
                    Console.WriteLine($"{count}. {item.Key} : {item.Value[0].Count} followers, {item.Value[1].Count} following");
                }
                count++;
            }
        }
    }
}
