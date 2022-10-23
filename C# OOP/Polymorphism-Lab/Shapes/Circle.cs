using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public double Radius { get { return this.radius; } set { this.radius = value; } }
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI*radius*radius;
        }

        public override double CalculatePerimeter()
        {
            return 2*Math.PI*radius;
        }
        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
