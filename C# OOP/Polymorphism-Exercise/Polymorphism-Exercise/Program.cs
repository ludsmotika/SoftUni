using System;

namespace Polymorphism_Exercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carinfo = Console.ReadLine().Split(); 
            string[] truckinfo = Console.ReadLine().Split();
            string[] businfo = Console.ReadLine().Split();
            Car car = new Car(double.Parse(carinfo[1]), double.Parse(carinfo[2]),double.Parse(carinfo[3]));
            Truck truck = new Truck(double.Parse(truckinfo[1]), double.Parse(truckinfo[2]), double.Parse(truckinfo[3]));
            Bus bus = new Bus(double.Parse(businfo[1]), double.Parse(businfo[2]), double.Parse(businfo[3]));
            
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                if (cmd[1] == "Truck")
                {
                    if (cmd[0] == "Drive")
                    {
                        Console.WriteLine(truck.Drive(double.Parse(cmd[2])));
                    }
                    else
                    {
                        truck.Refuel(double.Parse(cmd[2]));
                    }
                }
                else if(cmd[1] == "Car")
                {
                    if (cmd[0] == "Drive")
                    {
                        Console.WriteLine(car.Drive(double.Parse(cmd[2])));
                    }
                    else if(cmd[0] == "Refuel")
                    {
                        car.Refuel(double.Parse(cmd[2]));
                    }
                }
                else if (cmd[1] == "Bus")
                {
                    if (cmd[0] == "Drive")
                    {
                        bus.fuelConsumption += 1.4;
                        Console.WriteLine(bus.Drive(double.Parse(cmd[2])));
                        bus.fuelConsumption -= 1.4;
                    }
                    else if (cmd[0] == "Refuel")
                    {
                        bus.Refuel(double.Parse(cmd[2]));
                    }
                    else
                    {
                        Console.WriteLine(bus.Drive(double.Parse(cmd[2])));
                    }
                }
            }
            Console.WriteLine($"Car: {car.fuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.fuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.fuelQuantity:f2}");
        }
    }
}
