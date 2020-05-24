namespace Algorithms.StackQueue.Helpers
{
    public class DoublyLinkedNode<T>
    {
        public DoublyLinkedNode<T> Previous { get; set; }

        public DoublyLinkedNode<T> Next { get; set; }

        public T Item { get; set; }
    }
}