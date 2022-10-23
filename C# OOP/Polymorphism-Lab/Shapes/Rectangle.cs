using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;
        public double Width { get {return this.width; } set { this.width = value; } }
        public double Height { get {return this.height; } set { this.height = value; } }
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public override double CalculateArea()
        {
            return width * height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (height + width);
        }
        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
