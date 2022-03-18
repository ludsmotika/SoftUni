using System;
using System.Collections.Generic;
using System.Text;

namespace _03
{
    public class Person
    {
        private string name;
        private decimal money;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    this.money = value;
                }
            }
        }
        private List<Product> products;
        public IReadOnlyCollection<Product> Products { get { return this.products.AsReadOnly(); } }
        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            products = new List<Product>();
        }
        public void AddProduct(Product product) 
        {
        products.Add(product);
        }
    }
}
