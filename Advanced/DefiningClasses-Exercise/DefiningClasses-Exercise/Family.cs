using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        List<Person> family;
        public List<Person> MyProperty { get; set; }
        public Family() 
        {
        family= new List<Person>();
        }
        public void AddMember(Person member) 
        {
        family.Add(member);
        }
        public Person GetOldestMember() 
        {
            Person oldest = family.OrderByDescending(x => x.Age).First();
            return oldest;
        }
    }
}
