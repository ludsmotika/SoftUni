namespace CustomDoublyLinkedList
{
    public class Node<T>
    {
        public Node<T> NextItem{ get; set; }
        public Node<T> PrevItem{ get; set; }
        public T Value{ get; set; }
        public Node(T item)
        {
            Value = item;
        }
    }
}