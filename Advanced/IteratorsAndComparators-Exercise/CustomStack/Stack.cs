using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> list;
        public Stack()
        {
            this.list= new List<T>();  
        }
        public void Pop()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No elements");
            }
            else
            {

                list.RemoveAt(list.Count - 1);
            }
        }
        public void Push(params T[] newItems)
        {
            list.AddRange(newItems);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = list.Count-1; i>=0 ; i--)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
    
}
