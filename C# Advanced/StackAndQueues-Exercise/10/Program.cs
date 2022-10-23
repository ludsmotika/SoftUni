using System;
using System.Collections.Generic;

namespace _10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenSeconds = int.Parse(Console.ReadLine());
            int delay= int.Parse(Console.ReadLine());
            int carsPassed = 0;
            Queue<string> cars= new Queue<string>();
            string cmd = Console.ReadLine();
            while (cmd!="END")
            {
                if (cmd=="green")
                {
                    int currentSeconds = greenSeconds;
                   
                    while (currentSeconds>0 && (cars.Count!=0))
                    {
                        string car = cars.Peek();

                        if ( currentSeconds- car.Length >= 0)
                        {
                            cars.Dequeue();
                            carsPassed++;
                            currentSeconds -= car.Length;
                        }
                        else if( (currentSeconds+delay)- car.Length >= 0)
                        {
                            carsPassed++;
                            cars.Dequeue();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at {car[currentSeconds + delay]}.");
                            return;
                        }
                    }

                }
                else
                {
                    cars.Enqueue(cmd);
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
