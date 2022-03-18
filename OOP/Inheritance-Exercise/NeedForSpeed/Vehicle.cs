using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        //•	DefaultFuelConsumption – double 
        //•	FuelConsumption – virtual double
        //•	Fuel – double
        //•	HorsePower – int
        public const double DefaultFuelConsumption=1.25;
        public virtual double FuelConsumption => DefaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePower{ get; set; }
        public Vehicle(int horsePower, double fuel)
        {
            Fuel= fuel;
            HorsePower= horsePower;
        }
        public virtual void Drive(double kilometers) 
        {
            if (Fuel-(kilometers*FuelConsumption)>=0)
            {
                Fuel -= kilometers * FuelConsumption;
            }
        }
    }
}
