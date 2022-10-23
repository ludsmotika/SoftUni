using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation_Exercise
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value > 0)
                {
                    length = value;
                }
                else
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }


            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                  
                }


            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value>0)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
            }
        }
        public double SurfaceArea()
        {
        return 2*width*height + 2* height*length+2*width*length;
        }
        public double LateralSurfaceArea()
        {
            return 2 * width * height + 2 * height * length;
        }
        public double Volume()
        {
            return width*length*height;
        }

    }
}
