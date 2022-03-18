using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public void Dial(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
