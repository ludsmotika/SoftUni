using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Smartphone smart= new Smartphone();
            StationaryPhone stationaryPhone= new StationaryPhone();
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var number in phoneNumbers)
            {
                bool invalid = false;
                foreach (var item in number)
                {
                    if (Char.IsLetter(item))
                    {
                        Console.WriteLine("Invalid number!");
                        invalid = true;
                        break;
                    }
                }
                if (invalid == false)
                {

                    if (number.Length == 7)
                    {
                        stationaryPhone.Dial(number);
                    }
                    else if (number.Length == 10)
                    {
                        smart.Call(number);
                    }
                }
            }
            foreach (var url in urls)
            {
                bool invalid = false;
                foreach (var item in url)
                {
                    if (Char.IsDigit(item))
                    {
                        Console.WriteLine("Invalid URL!");
                        invalid = true;
                        break;
                    }
                }
                if (invalid==false)
                {
                    smart.Browse(url);
                }
                
            }


        }
    }
}
