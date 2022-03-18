using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries );
                Engine engine = new Engine();

                engine.Model = engineInfo[0];
                engine.Power = int.Parse(engineInfo[1]);

                if (engineInfo.Length == 3)
                {

                    bool canParse = int.TryParse(engineInfo[2], out int p);
                    if (canParse)
                    {
                        engine.Diplacement = int.Parse(engineInfo[2]);
                    }
                    else
                    {
                        engine.Efficiency  =engineInfo[2];
                    }
                }
                else if (engineInfo.Length == 4)
                {

                    engine.Diplacement = int.Parse(engineInfo[2]);
                    engine.Efficiency = engineInfo[3];
                }
                engines.Add(engineInfo[0], engine);
            }
            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Car currentCar= new Car();
                currentCar.Model = carInfo[0];
                currentCar.Engine = engines[carInfo[1]];
                if (carInfo.Length == 3)
                {
                    bool canParse = int.TryParse(carInfo[2], out int p);
                    if (canParse)
                    {
                        currentCar.Weight= int.Parse(carInfo[2]);
                    }
                    else
                    {
                        currentCar.Color = carInfo[2];
                    }
                }
                else if (carInfo.Length == 4)
                {
                    currentCar.Weight = int.Parse(carInfo[2]);
                    currentCar.Color = carInfo[3];
                }
                cars.Add(currentCar);
            }
            foreach (Car car in cars)
            {
                Console.WriteLine(car.Model + ":");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                string hasDiplacement = car.Engine.Diplacement.HasValue ? $"Displacement: { car.Engine.Diplacement}" : $"Displacement: n/a";
                string hasEF= car.Engine.Efficiency!=null? $"Efficiency: { car.Engine.Efficiency}" : $"Efficiency: n/a";
                string hasWe= car.Weight.HasValue ? $"Weight: { car.Weight}" : $"Weight: n/a";
                string hasColor= car.Color!=null ? $"Color: { car.Color}" : $"Color: n/a";
                Console.WriteLine("    "+hasDiplacement);
                Console.WriteLine("    "+hasEF);
                Console.WriteLine("  "+hasWe);
                Console.WriteLine("  "+hasColor);
            }
        }
    }
}
