using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        public string Name{ get; set; }
        public int FoodEaten { get; set; }
        public double Weight { get; set; }
        public Animal(string name,int foodEaten,double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }
        public abstract void Eat(Food food);
    }
}
