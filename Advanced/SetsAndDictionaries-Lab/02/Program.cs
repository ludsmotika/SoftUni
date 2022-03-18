using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,List<decimal>> studentsGrades=new Dictionary<string,List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                string[] student= Console.ReadLine().Split(' ');
                if (studentsGrades.ContainsKey(student[0]))
                {
                    studentsGrades[student[0]].Add(decimal.Parse(student[1]));
                }
                else
                {
                    studentsGrades .Add(student[0], new List<decimal>() { decimal.Parse(student[1])});
                }
            }
            foreach (var item in studentsGrades)
            {
                Console.Write(item.Key+" -> ");
                foreach (var grade in item.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write("(avg: "+$"{item.Value.Average():f2}"+")");
                Console.WriteLine();
            }
        }
    }
}
