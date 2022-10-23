using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, 0, weight, livingRegion)
        {
            Console.WriteLine(Sound());
        }
        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                Console.WriteLine($"Dog does not eat {food.GetType().Name}!");
            }
            else
            {
                this.Weight += food.Quantity * 0.4;
                this.FoodEaten += food.Quantity;
            }
        }
        public string Sound()
        {
            return "Woof!";
        }
    }
}
