using System;
using System.Collections.Generic;

namespace _10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] func = Console.ReadLine().Split(";");
            List<string> lefted = new List<string>();
            foreach (var item in people)
            {
                lefted.Add(item);
            }
            while (func[0] != "Print")
            {
                Func<string, bool> filter = GetFilter(func);

                if (func[0] == "Add filter")
                {
                    foreach (var item in people)
                    {
                        if (filter(item))
                        {
                            lefted.Remove(item);
                        }
                    }
                }
                else
                {

                    for (int i = 0; i < people.Length; i++)
                    {
                        if (filter(people[i]) && (lefted.Contains(people[i]) == false))
                        {
                            lefted.Add(people[i]);
                            i--;
                        }
                    }
                }

                func = Console.ReadLine().Split(";");
            }
            foreach (var item in people)
            {
                if (lefted.Contains(item))
                {
                    Console.Write(item+ " ");
                }
            }
        }

        private static Func<string, bool> GetFilter(string[] func)
        {
            Func<string, bool> filter;
            string toMatch = func[2];
            switch (func[1])
            {
                case "Starts with":
                    filter = x => x.Substring(0, toMatch.Length) == toMatch;
                    break;
                case "Ends with":
                    filter = x => x.Substring(x.Length - toMatch.Length) == toMatch;
                    break;
                case "Length":
                    filter = x => x.Length == int.Parse(toMatch);
                    break;
                case "Contains":
                    filter = x => x.Contains(toMatch);
                    break;
                default:
                    filter = x => x != "lol";
                    break;
            }
            return filter;
        }
    }
}
