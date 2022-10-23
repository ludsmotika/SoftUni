using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public int Battery { get; set; }
        public string Model { get ; set ; }
        public string Color { get; set; }

        public Tesla(string model,string color,int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }
        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
    }
}
