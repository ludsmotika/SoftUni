using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, 0, weight, livingRegion, breed)
        {
            Console.WriteLine(Sound());
        }
        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Meat" && food.GetType().Name != "Vegetable")
            {
                Console.WriteLine($"Cat does not eat {food.GetType().Name}!");
            }
            else
            {
                this.Weight += food.Quantity * 0.3;
                this.FoodEaten += food.Quantity;
            }
        }
        public string Sound()
        {
            return "Meow";
        }
    }
}
