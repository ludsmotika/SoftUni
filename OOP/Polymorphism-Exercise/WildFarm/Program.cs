using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> col=new List<Animal>();
            string[] animal=Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            while (animal[0]!="End")
            { 
                string[] foodInfo= Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Animal currentAnimal = null;
                switch (animal[0])
                {
                    case "Owl":
                        currentAnimal = new Owl(animal[1],double.Parse(animal[2]),double.Parse(animal[3]));
                        break;
                    case "Dog":
                        currentAnimal = new Dog(animal[1], double.Parse(animal[2]), animal[3]);

                        break;
                    case "Cat":
                        currentAnimal = new Cat(animal[1], double.Parse(animal[2]),animal[3],animal[4]);

                        break;
                    case "Tiger":
                        currentAnimal = new Tiger(animal[1], double.Parse(animal[2]),animal[3],animal[4]);

                        break;
                    case "Hen":
                        currentAnimal = new Hen(animal[1], double.Parse(animal[2]), double.Parse(animal[3]));

                        break;
                    case "Mouse":
                        currentAnimal = new Mouse(animal[1], double.Parse(animal[2]), animal[3]);

                        break;
                    default:
                        break;
                }
                Food food = null;
                switch (foodInfo[0])
                {
                    case "Vegetable":
                        food = new Vegetable(int.Parse(foodInfo[1]));
                        break;
                    case "Fruit":
                        food = new Fruit(int.Parse(foodInfo[1]));
                        break;
                    case "Meat":
                        food = new Meat(int.Parse(foodInfo[1]));
                        break;
                    case "Seeds":
                        food = new Seeds(int.Parse(foodInfo[1]));
                        break;
                    default:
                        break;
                }
                currentAnimal.Eat(food);
                col.Add(currentAnimal);
                animal = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in col)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
