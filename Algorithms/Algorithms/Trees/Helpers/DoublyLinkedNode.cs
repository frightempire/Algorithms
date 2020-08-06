namespace Algorithms.Trees.Helpers
{
    public class DoublyLinkedNode<T>
    {
        public DoublyLinkedNode<T> Left { get; set; }

        public DoublyLinkedNode<T> Right { get; set; }

        public DoublyLinkedNode<T> Parent { get; set; }

        public Dimension Dimension { get; set; }

        public T Item { get; set; }
    }
}