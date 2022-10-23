using System;
using System.Text;

namespace Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input1=Console .ReadLine().Split(' ');
            string name = input1[0] +" "+ input1[1];
            StringBuilder town=new StringBuilder();
            for (int i = 3; i < input1.Length; i++)
            {
                town.Append(input1[i]);
            }
            MyTuple<string, string,string> collection1 = new MyTuple<string, string,string>(name,input1[2],town.ToString());
            string[] input2 = Console.ReadLine().Split(' ');
            int liters=int.Parse(input2[1]);
            bool isDrunk = input2[2] == "drunk" ? true : false;
            MyTuple<string, int,bool> collection2 = new MyTuple<string, int,bool>(input2[0], liters,isDrunk);
            string[] input3 = Console.ReadLine().Split(' ');
            double doubleValue = double.Parse(input3[1]);
            MyTuple<string, double,string> collection3 = new MyTuple<string, double,string>(input3[0], doubleValue,input3[2]) ;
            Console.WriteLine($"{collection1.Item1} -> {collection1.Item2} -> {collection1.Item3}");
            Console.WriteLine($"{collection2.Item1} -> {collection2.Item2} -> {collection2.Item3}");
            Console.WriteLine($"{collection3.Item1} -> {collection3.Item2} -> {collection3.Item3}");
        }
    }
}
