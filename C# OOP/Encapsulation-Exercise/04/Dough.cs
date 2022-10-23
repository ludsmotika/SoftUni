using System;
using System.Collections.Generic;
using System.Text;

namespace _04
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int grams;
        private decimal calories;
        private string FlourType
        {
            set 
            {
                if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
                {
                    flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        private string BakingTechnique
        {
            set
            {
                if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
                {
                    bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        private int Grams
        {
            set
            {
                if (value >=1 && value<=200)
                {
                    grams = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }
        public decimal Calories { get { return this.calories; } }
        public Dough(string flourType,string bakingTechnique,int grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
            CalculateCalories();
        }
        private void CalculateCalories() 
        {
            decimal current=2*this.grams;
            if (this.flourType.ToLower()=="white")
            {
                current *= 1.5m;
            }
            if (this.bakingTechnique.ToLower() == "crispy")
            {
                current *= 0.9m;
            }
            else if (this.bakingTechnique.ToLower() == "chewy") 
            {
                current *= 1.1m;
            }
            this.calories = current;
        }
    }
}
