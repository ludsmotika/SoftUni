using System;
using System.Collections.Generic;
using System.Text;

namespace Generics_Exercise
{
    public class Box<T> where T:IComparable
    {
        public List<T> collection { get; set; }
        public Box()
        {
        this.collection = new List<T>();
        }
        public override string ToString() 
        {
            StringBuilder answer=new StringBuilder();
            foreach (var part in collection)
            {
                answer.AppendLine($"{part.GetType()}: {part}");
            }
            return answer.ToString();
        }
        public static void Swap(List<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        public static int Compare(List<T> collection, T compare)
        {
           int counter= 0;
            foreach (var item in collection)
            {
                if (item.CompareTo(compare)>0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
