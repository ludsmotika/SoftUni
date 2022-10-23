using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model{ get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelCons)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelCons;
            this.TravelledDistance = 0.0;
        
        }
        public void Drive(double distance) 
        {
            if (FuelAmount>= FuelConsumptionPerKilometer*distance)
            {
                FuelAmount -= FuelConsumptionPerKilometer * distance;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
