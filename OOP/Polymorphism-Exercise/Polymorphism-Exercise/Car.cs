using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism_Exercise
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption,double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.fuelConsumption += 0.9;
        }
        public override void Refuel(double liters)
        {
            if (liters<=0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (fuelQuantity + liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                this.fuelQuantity += liters;
            }
        }
    }
}
