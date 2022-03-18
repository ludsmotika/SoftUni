using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, 0, weight, livingRegion, breed)
        {
            Console.WriteLine(Sound());
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name!="Meat")
            {
                Console.WriteLine ($"Tiger does not eat {food.GetType().Name}!");
            }
            else
            {

                this.Weight += food.Quantity * 1.0;
                this.FoodEaten += food.Quantity;
            }
        }

        public string Sound()
        {
            return "ROAR!!!";
        }
    }
}
