using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparation_Advanced_13._02._2022
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> stack = new Stack<int>();
            for (int i = 1; i <= numberOfWaves; i++)
            {
                Stack<int> currentWave = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
                ToAdd(i, plates);
                if (plates.Count > 0)
                {
                    int currentPlate = plates.Dequeue();
                    while (currentWave.Count > 0)
                    {
                        currentPlate =War(plates,currentWave,currentPlate);
                        if (plates.Count==0)
                        {
                            break;
                        }
                    }
                    if (currentPlate > 0)
                    {
                        plates.Enqueue(currentPlate);
                        for (int k = 0; k < plates.Count - 1; k++)
                        {
                            plates.Enqueue(plates.Dequeue());
                        }
                    }
                    if (stack.Count==0 && plates.Count == 0)
                    {
                        stack = currentWave;
                    }
                }
            }
            if (plates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine("Orcs left: " + String.Join(", ", stack));
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine("Plates left: " + String.Join(", ", plates));
            }
        }

        public static int War(Queue<int> plates, Stack<int> currentWave,int currentPlate)
        {
            int ork = currentWave.Pop();
            while (ork > 0)
            {
                if (ork > currentPlate)
                {
                    ork -= currentPlate;
                    currentPlate = 0;
                    if (plates.Count > 0)
                    {
                        currentPlate = plates.Dequeue();
                    }
                    else
                    {
                        break;
                    }

                }
                else if (ork == currentPlate)
                {
                    currentPlate = 0;
                    ork = 0;
                }
                else
                {
                    currentPlate -= ork;
                    ork = 0;
                    if (currentWave.Count > 0)
                    {
                        ork = currentWave.Pop();

                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (ork > 0)
            {
                currentWave.Push(ork);
            }
            return currentPlate;
        }

        private static void ToAdd(int i, Queue<int> plates)
        {

            if (i % 3 == 0)
            {
                int n = int.Parse(Console.ReadLine());
                if (plates.Count > 0)
                {
                    plates.Enqueue(n);
                }
            }
        }
    }
}
