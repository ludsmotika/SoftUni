using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, 0, weight, wingSize)
        {
            Console.WriteLine(Sound());
        }
        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * 0.35;
            this.FoodEaten += food.Quantity;
        }
        public string Sound()
        {
            return "Cluck";
        }
    }
}
