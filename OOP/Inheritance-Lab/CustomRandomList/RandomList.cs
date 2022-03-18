using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList: List<string>
    {
        public string RandomString() 
        {
        Random random = new Random();
            int n = random.Next(0, this.Count);
            string element = this[n];
            this.RemoveAt(n);

            return element;
        }
    }
}
