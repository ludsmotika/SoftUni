using System;

namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] doughInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Dough cur = new Dough(doughInfo[1], doughInfo[2], int.Parse(doughInfo[3]));
                Pizza pizza = new Pizza(pizzaInfo[1]);
                pizza.Dough = cur;
                string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                while (info[0] != "END")
                {
                    if (info[0] == "Topping")
                    {
                        Topping toppingToAdd = new Topping(info[1], int.Parse(info[2]));
                        pizza.AddTopping(toppingToAdd);
                    }
                    info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

        }
    }
}
