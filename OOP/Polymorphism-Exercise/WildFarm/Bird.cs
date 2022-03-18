using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; set; }
        public Bird(string name, int foodEaten, double weight,double wingSize) : base(name, foodEaten, weight)
        {
            WingSize = wingSize;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
