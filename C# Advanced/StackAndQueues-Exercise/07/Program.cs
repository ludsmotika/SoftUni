using System;
using System.Collections.Generic;
using System.Linq;

namespace _07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stations = int.Parse(Console.ReadLine());
            Queue<int[]> circle=new Queue<int[]>();
            for (int i = 0; i < stations; i++)
            {
                circle.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }
            for (int i = 0; i < circle.Count; i++)
            {
                if (CheckIfPossible(circle))
                {
                    Console.WriteLine(i);
                    return;
                }
                else
                {
                    circle.Enqueue(circle.Dequeue());
                }
                
            }
        }
        static public bool CheckIfPossible(Queue<int[]> copy) 
        {
            
            Queue<int[]> copyOfCircle = new Queue<int[]>(copy);
            int gas = 0;

            for (int i = 0; i < copyOfCircle.Count; i++) 
            {
                if (copyOfCircle.Peek()[0]+gas>= copyOfCircle.Peek()[1])
                { 
                int[] current=copyOfCircle.Dequeue();
                    gas +=current[0];
                    gas -=current[1];
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
