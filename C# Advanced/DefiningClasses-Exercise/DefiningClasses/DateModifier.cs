using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public static int TakeDiff(string first, string second) 
        {
            DateTime dateOne =DateTime.Parse(first);
            DateTime dateTwo=DateTime.Parse(second);
            int days =(int) Math.Abs((dateOne - dateTwo).Days);
            return days;
        
        }
    }
}
