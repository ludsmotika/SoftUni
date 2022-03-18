using System;
using System.Collections.Generic;
using System.Linq;

namespace _07
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> collection=new List<Car>();   
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                Engine engine = new Engine(int.Parse(carInfo[1]), int.Parse(carInfo[2]));
                Cargo cargo = new Cargo(int.Parse(carInfo[3]), carInfo[4]);
                Tire[] currentTires = new Tire[4];
                List<int> years = new List<int>();
                List<double> pressures = new List<double>();
                for (int k = 5; k <=12; k++)
                {
                    if (k % 2 == 0)
                    {
                        years.Add(int.Parse(carInfo[k]));
                      
                    }
                    else
                    {
                        pressures.Add(double.Parse(carInfo[k]));
                    }
                }
                for (int k = 0; k <= 3; k++)
                {
                    Tire current = new Tire(years[k], pressures[k]);
                    currentTires[k] = current;
                }
                Car currentCar = new Car(carInfo[0], engine, cargo, currentTires);
                collection.Add(currentCar);
            }
            string filter=Console.ReadLine();
            if (filter == "fragile")
            {
                collection = collection.Where(x=>x.Cargo.Type=="fragile" && (x.Tires.Where(x=>x.Pressure<1).Any())).ToList();

            }
            else 
            {
                collection = collection.Where(x=>x.Cargo.Type=="flammable" && x.Engine.Power>250).ToList();
            }
            foreach (var item in collection)
            {
                Console.WriteLine(item.Model);
            }
        }
    }
}
