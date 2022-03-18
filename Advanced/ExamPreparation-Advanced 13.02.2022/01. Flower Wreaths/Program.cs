using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lil = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> lilies = new Stack<int>(lil);
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            int saveForLater =0;
            int totalWreaths = 0;
            while (lilies.Count > 0 && roses.Count > 0)
            {
                int rose = roses.Dequeue();
                int lily = lilies.Pop();
                if ((rose + lily) == 15)
                {
                    totalWreaths++;
                }
                else if ((rose+lily)>15) 
                {
                    while ((rose+lily)>15)
                    {
                        lily -= 2;
                    }
                    if ((rose + lily) == 15)
                    {
                        totalWreaths++;
                    }
                    else
                    {
                        saveForLater += (rose + lily);
                    }
                }
                else
                {
                    saveForLater += (rose + lily);
                }
            }
            totalWreaths += saveForLater /15;
            if (totalWreaths>=5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {totalWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-totalWreaths} wreaths more!");
            }
        }
    }
}
