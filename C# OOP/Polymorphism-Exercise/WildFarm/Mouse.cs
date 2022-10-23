using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, 0, weight, livingRegion)
        {
            Console.WriteLine(Sound());
        }
        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Fruit")
            {
                Console.WriteLine($"Mouse does not eat {food.GetType().Name}!");
            }
            else
            {
                this.Weight += food.Quantity * 0.1;
                this.FoodEaten += food.Quantity;
            }
        }

        public string Sound()
        {
            return "Squeak";
        }
    }
}
