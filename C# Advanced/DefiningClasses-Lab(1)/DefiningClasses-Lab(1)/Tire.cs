using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        int year;
        double presure;
        public int Year{ get {return this.year; } set {this.year=value; } }
        public double Presure{ get {return this.presure; } set {this.presure = value; } }
        public Tire(int year,double presure) 
        {
            this.Year = year;
            this.Presure=presure;
        }
    }
}
