using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    internal class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        public override double FuelConsumption => 8;
    }
}
