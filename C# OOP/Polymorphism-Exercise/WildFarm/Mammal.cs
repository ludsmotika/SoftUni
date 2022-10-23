using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        public string LivingRegion { get; set; }
        public Mammal(string name, int foodEaten, double weight, string livingRegion) : base(name, foodEaten, weight)
        {
            LivingRegion=livingRegion;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
