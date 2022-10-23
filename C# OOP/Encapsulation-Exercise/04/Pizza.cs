using System;
using System.Collections.Generic;
using System.Text;

namespace _04
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;
        private decimal totalCalories;
        private int NumberOfToppings=>this.toppings.Count;
        public decimal TotalCalories=>this.totalCalories;
        public string Name
        {
            get
            {
                return this.name;
            }
            private set 
            {
                if (value.Length>=1 && value.Length <= 15 && string.IsNullOrEmpty(value)==false)
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
            }
        }
        public Dough Dough {set { this.totalCalories += value.Calories; this.dough = value; } }
        public Pizza(string name)
        {
            Name= name;
            toppings = new List<Topping>();
        }
        public void AddTopping(Topping topping) 
        {
            if (NumberOfToppings>=10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            else
            {
                toppings.Add(topping);
                totalCalories+=topping.Calories;
            }

        }

    }
}
