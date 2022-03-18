using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] peopleInfo= Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            try
            {
                foreach (string person in peopleInfo)
                {
                    string[] info = person.Split("=");
                    people.Add(new Person(info[0], int.Parse(info[1])));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            List<Product> products = new List<Product>();
            try
            {
                string[] productInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (string product in productInfo)
                {
                    string[] info = product.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    products.Add(new Product(info[0], int.Parse(info[1])));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
           
            string[] cmd = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            while (cmd[0]!="END")
            {
                Person person = people.Find(x => x.Name == cmd[0]);
                Product product = products.Find(x => x.Name==cmd[1]);
                if (person.Money>=product.Cost)
                {
                    person.Money -= product.Cost;
                    person.AddProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var person in people)
            {
                Console.Write($"{person.Name} - ");
                if (person.Products.Count==0)
                {
                    Console.Write("Nothing bought");
                }
                else
                {
                    Console.Write($"{string.Join(", ",person.Products.Select(x=>x.Name))}");
                }
                Console.WriteLine();
            }
        }
    }
}
