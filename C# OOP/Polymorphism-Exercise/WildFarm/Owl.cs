using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, 0, weight, wingSize)
        {
            Console.WriteLine(Sound());
        }
        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                Console.WriteLine($"Owl does not eat {food.GetType().Name}!");
            }
            else
            {
                this.Weight += food.Quantity * 0.25;
                this.FoodEaten += food.Quantity;
            }
        }

        public string Sound()
        {
            return "Hoot Hoot";
        }
    }
}
