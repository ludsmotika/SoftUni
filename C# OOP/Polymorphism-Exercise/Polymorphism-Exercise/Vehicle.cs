using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism_Exercise
{
    public abstract class Vehicle
    {
        private double tankCapacity;
        public double fuelQuantity { get; set; }
        public double fuelConsumption { get; set; }
        public double TankCapacity
        { get { return this.tankCapacity; }
            set 
            {
                if (value<=0)
                {
                    Console.WriteLine("Fuel must be a positive number");
                }
                else
                {
                    this.tankCapacity = value;
                }
            }
        }
        public Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
            if (fuelQuantity>TankCapacity)
            {
                this.fuelQuantity = 0;
            }
        }

        public string Drive(double distance) 
        {
            if (fuelConsumption * distance <= fuelQuantity)
            {
                fuelQuantity -= distance * fuelConsumption;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }
        public abstract void Refuel(double liters);

    }
}
