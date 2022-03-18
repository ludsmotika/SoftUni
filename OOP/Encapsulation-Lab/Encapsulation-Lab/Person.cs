using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (value.Length<3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                else
                {
                    this.firstName = value;

                }
            
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                else
                {
                    this.lastName = value;
                }
               

            }
        }
        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                else
                {

                    this.age = value;
                }
            }
        }
        public decimal Salary
        {
            get { return this.salary; }
            private set
            {

                if (value <650)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                else
                {
                    this.salary = value;
                }
               
            
            }
        }
        public Person(string fName, string lName, int age, decimal salary)
        {
            FirstName = fName;
            LastName = lName;
            Age = age;
            Salary = salary;
        }
        public override string ToString()
        {
            return $"{firstName} {lastName} receives {salary:f2} leva.";
        }
        public void IncreaseSalary(decimal percentage)
        {
            if (this.age > 30)
            {
                this.salary += this.salary * (percentage / 100);
            }
            else
            {
                percentage /= 2;
                this.salary += this.salary * (percentage / 100);
            }
        }
    }
}
