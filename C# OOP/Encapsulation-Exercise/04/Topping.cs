using System;
using System.Collections.Generic;
using System.Text;

namespace _04
{
    public class Topping
    {
        private string type;
        private int grams;
        private decimal calories;
        private string Type
        {
            set
            {
                if (value.ToLower()=="meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce" )
                {
                    type = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        private int Grams
        {
            set
            {
                if (value>=1 && value <=50)
                {
                    grams = value;
                }
                else
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }
            }
        }
        public decimal Calories { get { return this.calories; } }
        public Topping(string type, int grams)
        {
            Type = type;
            Grams = grams;
            calories = grams * 2;
            CalculateCalories();
        }
        public void CalculateCalories()
        {
            decimal cal = 0;
            if (this.type.ToLower() == "meat")
            {
                cal = 1.2m;
            }
            else if (this.type.ToLower() == "veggies") 
            {
                cal = 0.8m;
            }
            else if (this.type.ToLower() == "cheese")
            {
                cal = 1.1m;
            }
            else if (this.type.ToLower() == "sauce")
            {
                cal =0.9m;
            }
            calories = calories*cal;
        }
    }
}
