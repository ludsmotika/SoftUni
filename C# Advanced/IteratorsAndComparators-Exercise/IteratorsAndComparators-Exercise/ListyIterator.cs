using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators_Exercise
{
    public class ListyIterator<T>: IEnumerable<T>
    {
        private List<T> items;
        private int index;
        public ListyIterator(List<T> items)
        {
            this.items = items.ToList();
            index = 0;
        }
        public bool Move()
        {
            if (index+1<items.Count)
            {
                index++;
                return true;
            }
            return false;
        }
        public bool HasNext() 
        {
            if (index+1 < items.Count)
            {
                return true;
            }
            return false;

        }
        public void Print() 
        {
            if (items.Count==0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(items[index]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
      
    }
}
