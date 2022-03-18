using System;
using System.Collections.Generic;
using System.Text;

namespace _03
{
    public class Product
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            private set
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
        private decimal cost;
        public decimal Cost
        {
            get { return this.cost; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    this.cost = value;
                }
               
            } 
        }

        public Product(string name, int cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
    }
}
