using System;
using System.Collections.Generic;
using System.Linq;

namespace _06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", ").ToArray());
            
            while (songs.Count > 0)
            {
                string[] cmd = Console.ReadLine().Split(" ");
                switch (cmd[0])
                    {
                        case "Play":
                            songs.Dequeue();
                            break;
                        case "Show":
                            Console.WriteLine(string.Join(", ", songs));
                            break;
                        case "Add":
                            string song = string.Join(" ", cmd.Skip(1));
                            if (songs.Contains(song))
                            {
                                Console.WriteLine($"{song} is already contained!");
                            }
                            else
                            {
                                songs.Enqueue(song);
                            }
                            break;
                        default:
                            break;
                    }
                
            }
            Console.WriteLine("No more songs!");
        }
    }
}
