using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics_Exercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();
            for (int i = 0; i < n; i++)
            {
            //  string input = Console.ReadLine();
              double input = double.Parse(Console.ReadLine());
                box.collection.Add(input);
            }
            double compare = double.Parse(Console.ReadLine());
            Console.WriteLine(Box<double>.Compare(box.collection,compare));
        }
    }
}
