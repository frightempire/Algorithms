using System.Collections;
using System.Collections.Generic;

namespace Algorithms.StackQueue.Helpers
{
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private readonly DoublyLinkedNode<T> _first;
        private DoublyLinkedNode<T> _current;

        public DoublyLinkedListEnumerator(DoublyLinkedNode<T> first)
        {
            _first = first;
            _current = new DoublyLinkedNode<T>
            {
                Next = first,
                Item = default
            };
        }

        public bool MoveNext()
        {
            _current = _current.Next;
            return _current != null;
        }

        public void Reset()
        {
            _current = _first;
        }

        public T Current => _current.Item;

        object IEnumerator.Current => Current;

        public void Dispose() { }
    }
}