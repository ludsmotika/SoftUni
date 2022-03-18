using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayCatch_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int exceptions = 0;
            while (exceptions<3)
            {
                try
                {
                    string[] cmd = Console.ReadLine().Split();
                    switch (cmd[0])
                    {
                        case "Replace":
                            arr[int.Parse(cmd[1])] = int.Parse(cmd[2]);
                            break;
                        case "Show":
                            Console.WriteLine(arr[int.Parse(cmd[1])]);
                            break;
                        case "Print":
                            int start = int.Parse(cmd[1]);
                            int end = int.Parse(cmd[2]);
                            int[] newArr = new int[Math.Abs(end) - Math.Abs(start)+1];
                            int counter = 0;
                            for (int i = start; i <= end; i++)
                            {
                                newArr[counter++] = arr[i];
                            }
                            Console.WriteLine(String.Join(", ", newArr));
                            break;
                        default:
                            break;
                    }
                }
                catch (IndexOutOfRangeException )
                {
                    Console.WriteLine("The index does not exist!");
                    exceptions++;
                }
                catch (FormatException) 
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptions++;

                }

            }
            Console.WriteLine(String.Join(", ",arr));
        }
    }
}
