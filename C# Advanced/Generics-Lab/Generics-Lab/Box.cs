using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public List<T> collection{ get; set; }
        public int Count { get { return collection.Count; } }
        public Box()
        {
            collection = new List<T>();
        }
        public void Add(T element) 
        {
        collection.Add(element);
        }
        public T Remove()
        {
            var save = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count-1);
            return save;
        }

    }
}
