using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; set; }

        public int CompareTo(Book other)
        {
            int n = this.Year - other.Year;
            if (n > 0) { return 1; }
            else if (n < 0) { return -1; }
            else
            {
                return this.Title.CompareTo(other.Title);
            }

        }
        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
