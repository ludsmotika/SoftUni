using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    internal class Car
    {
        string make;
        string model;
        int year;
        double fuelQuantity;
        double fuelConsumption;
        Engine engine;
        Tire[] tires;

        public Engine Engine { get { return this.engine; } set {this.engine=value; } }
        public Tire[]  Tires { get { return this.tires; } set {this.tires=value; } }
        public string Make { get { return this.make; } set { this.make = value; } }
        public string Model { get { return this.model; } set { this.model = value; } }
        public int Year { get { return this.year; } set { this.year = value; } }
        public double FuelQuantity { get { return this.fuelQuantity; } set { this.fuelQuantity = value; } }
        public double FuelConsumption { get { return this.fuelConsumption; } set { this.fuelConsumption = value; } }
        public void Drive(double distance)
        {
            if (fuelQuantity - (fuelConsumption * distance/100) > 0)
            {
                fuelQuantity -= fuelConsumption * distance/100;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            StringBuilder text = new StringBuilder();
            text.Append($"Make: {this.make}");
            text.AppendLine($"Model: {this.model}");
            text.AppendLine($"Year: {this.year}");
            text.AppendLine($"Fuel: {this.fuelQuantity:f2}");
            return text.ToString();
        }
        public Car() 
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity  = 200;
            this.FuelConsumption  = 10;
        }
        public Car(string make,string model, int year) :this() 
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year,double fuelQuantity, double fuelConsumption) : this(make,model, year)
        {
            this.FuelConsumption= fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,Engine engine,Tire[] tires) : this(make, model, year,fuelQuantity,fuelConsumption)
        {
            this.Engine= engine;
            this.Tires = tires;
        }
    }
}
