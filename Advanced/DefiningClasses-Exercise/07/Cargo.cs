using System;
using System.Collections.Generic;
using System.Text;

namespace _07
{
    public class Cargo
    {
        string type;
        int weight;
        public string Type{ get { return this.type; } set { this.type = value; } }
        public int Weight{ get { return this.weight; } set { this.weight = value; } }

        public Cargo(int weight,string type) 
        {
            this.Type = type;
            this.Weight = weight;
        }
    }
}
