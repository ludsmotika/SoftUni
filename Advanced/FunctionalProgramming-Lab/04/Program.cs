using System;
using System.Linq;

namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string,double> vatter= x=> double.Parse(x)*1.20;
            double[] collection = Console.ReadLine().Split(", ").Select(vatter).ToArray();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}
