using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {

        Node<T> head;
        Node<T> tail;
        public int Count { get; set; }
        public void AddFirst(T element)
        {
            Node<T> currentNode = new Node<T>(element); 
            if (Count==0)
            {
                head = currentNode;
                tail = currentNode;
                currentNode.NextItem = null;
                currentNode.PrevItem = null;

            }
            else
            {
                Node < T >save= head;// save old head
                
                head = currentNode;
                save.PrevItem = head;
                head.NextItem = save;
                head.PrevItem = null;
            }
            Count++;
        }
        public void AddLast(T element)
        {
            Node<T> currentNode = new Node<T>(element);
            if (Count == 0)
            {
                head = currentNode;
                tail = currentNode;
                currentNode.NextItem = null;
                currentNode.PrevItem = null;

            }
            else
            {
                Node<T> save = tail;

                tail = currentNode;
                save.NextItem = tail;
                tail.PrevItem = save;
                tail.NextItem = null;
            }
            Count++;
        }
        public T RemoveFirst() 
        {
            if (Count==0)
            {
                throw new InvalidOperationException("This list is empty!");
            }
            Node<T> removedNode = head;
            head = removedNode.NextItem;
            if (head != null)
            {
                head.PrevItem = null;
            }
            else
            {
                tail = null;
            }
            Count--;
            return removedNode.Value;
        }
        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("This list is empty!");
            }
            Node<T> removedNode = tail;
            tail = removedNode.PrevItem;
            if (tail != null)
            {
                tail.NextItem = null;
            }
            else
            {
                head = null;
            }
            Count--;
            return removedNode.Value;
        }
        public void ForEach(Action<T> action) 
        {
            var currentNode = this.head;
            while (currentNode != null) 
            {
                action(currentNode.Value);
            currentNode=currentNode.NextItem;
            }

        }
        public T[] ToArray() 
        {
            T[] arr = new T[Count];
            int index= 0;
            var currentNode = this.head;
            while (currentNode != null)
            {
                arr[index++] = currentNode.Value;
                currentNode = currentNode.NextItem;
            }
            return arr;
        }
    }
}
