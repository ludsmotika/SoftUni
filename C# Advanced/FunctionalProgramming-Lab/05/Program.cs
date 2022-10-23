using System;
using System.Collections.Generic;
using System.Linq;

namespace _05
{
    internal class Program
    {
        class Student 
        {
            public Student (string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            List<Student> collection= new List<Student> ();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input= Console.ReadLine().Split(", ");
                collection.Add(new Student(input[0], int.Parse(input[1])));
            }
            string condition = Console.ReadLine();
            int ageToTest = int.Parse(Console.ReadLine());
            string printingCondition = Console.ReadLine();
            Func<Student, bool> filter = GetFilter(condition,ageToTest);
            collection = collection.Where(filter).ToList();
            Action<Student> print = GetAction(printingCondition);
            foreach (var item in collection)
            {
             print(item);
            }
        }

        private static Action<Student> GetAction(string printingCondition)
        {
            if (printingCondition == "age")
            {
                return x => Console.WriteLine(x.Age);
            }
            else if (printingCondition == "name") 
            {
                return x => Console.WriteLine(x.Name);
            }
            else
            {
                return x => Console.WriteLine($"{x.Name} - {x.Age }");
            }
        }

        private static Func<Student, bool> GetFilter(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x.Age < age;
            }
            else 
            {
                return x => x.Age >= age;
            }
                 
               
            
        }
    }
}
