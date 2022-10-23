using System;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            Console.WriteLine(DateModifier.TakeDiff(first,second));
        }
    }
}
