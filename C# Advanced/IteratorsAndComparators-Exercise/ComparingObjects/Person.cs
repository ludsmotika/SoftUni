using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
    public class Person:IComparable<Person>
    {
        public string Name{ get; set; }
        public int Age{ get; set; }
        public string Town{ get; set; }

        public int CompareTo( Person other)
        {
            int n=this.Name .CompareTo(other.Name);
            if (n==0)
            {
                n = this.Age.CompareTo(other.Age);
                if (n==0)
                {
                    return this.Town.CompareTo(other.Town);
                }
            }
            return n;
        }
    }
}
