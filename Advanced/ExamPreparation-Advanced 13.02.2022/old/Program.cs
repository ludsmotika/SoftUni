using System;
using System.Collections.Generic;

namespace old
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> collection = new Dictionary<string, Car>();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(' ');
                Car currentCar = new Car(info[0], double.Parse(info[1]), double.Parse(info[2]));
                collection.Add(info[0], currentCar);
            }
            string[] driving = Console.ReadLine().Split(' ');
            while (driving[0] != "End")
            {
                collection[driving[1]].Drive(double.Parse(driving[2]));
                driving = Console.ReadLine().Split(' ');
            }
            foreach (var item in collection.Values)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.TravelledDistance}");
            }
        }
    }
}
