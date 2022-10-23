using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare( Book x,  Book y)
        {
            int n = x.Title.CompareTo(y.Title);
            if (n==0)
            {
                return y.Year.CompareTo(x.Year);
            }
            return n;
        }
    }
}
