using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        int horsePower;
        double cubicCapacity;
        public int HorsePower { get { return this.horsePower; } set { this.horsePower = value; } }
        public double CubicCapacity { get { return this.cubicCapacity; } set { this.cubicCapacity = value; } }
        public Engine(int horsePower,double cubicCapacity)
        {
        this.HorsePower=horsePower;
            this.CubicCapacity=cubicCapacity;
        }
    }
}
