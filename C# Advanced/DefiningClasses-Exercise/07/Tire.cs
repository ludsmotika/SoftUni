using System;
using System.Collections.Generic;
using System.Text;

namespace _07
{
    public class Tire
    {
        int age;
        double pressure;
        public  int Age { get { return this.age; } set { this.age = value; } }
        public double Pressure { get { return this.pressure; } set { this.pressure = value; } }
        public Tire(int age,double pressure)
        {
        this.Age = age;
            this.Pressure = pressure; 
        }
    }
}
