using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
          
            List<Tire[]> indexesOfTires = new List<Tire[]>();
            string[] infoForTires = Console.ReadLine().Split(' ');
            while (infoForTires[0] != "No")
            {
                Tire[] currentTires = new Tire[4];
                List<int>years=new List<int>();
                List<double >pressures=new List<double>();
                for (int i = 0; i < infoForTires.Length; i++)
                {
                    if (i%2==0)
                    {
                        years.Add(int.Parse(infoForTires[i]));
                    }
                    else
                    {
                        pressures.Add(double.Parse(infoForTires[i]));
                    }
                }
                for (int i = 0; i <= 3; i++)
                {
                    Tire current = new Tire(years[i], pressures[i]);
                    currentTires[i] = current;
                }
                indexesOfTires.Add(currentTires);
                infoForTires = Console.ReadLine().Split(' ');
            }
            List<Engine> indexesOfEngines=new List<Engine>();
            string[] cmd = Console.ReadLine().Split();
            while (cmd[0] !="Engines")
            {
                indexesOfEngines.Add(new Engine(int.Parse(cmd[0]),double.Parse(cmd[1])));
                cmd = Console.ReadLine().Split();
            }
            string[] carInfo = Console.ReadLine().Split();
            List<Car> specialCars=new List<Car>();
            while (carInfo[0] != "Show")
            {
                Car currentCar = new Car(carInfo[0],carInfo[1],int.Parse(carInfo[2]),double.Parse(carInfo[3]), double.Parse(carInfo[4]), indexesOfEngines[int.Parse(carInfo[5])],indexesOfTires[int.Parse(carInfo[6])]);
                double tyrePressureSum = 0;
                foreach (var tyre in currentCar.Tires)
                {
                    tyrePressureSum += tyre.Presure;
                }
                if (currentCar.Year>=2017 && currentCar.Engine.HorsePower>=330 && tyrePressureSum>=9 && tyrePressureSum<=10)
                {
                    currentCar.Drive(20);
                    specialCars.Add(currentCar);
                }
                carInfo = Console.ReadLine().Split();
            }
            foreach (Car car in specialCars) 
            {
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower }");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
