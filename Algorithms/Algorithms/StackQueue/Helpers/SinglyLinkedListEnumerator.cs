using System.Collections;
using System.Collections.Generic;

namespace Algorithms.StackQueue.Helpers
{
    public class SinglyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private readonly SinglyLinkedNode<T> _first;
        private SinglyLinkedNode<T> _current;

        public SinglyLinkedListEnumerator(SinglyLinkedNode<T> first)
        {
            _first = first;
            _current = new SinglyLinkedNode<T>
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