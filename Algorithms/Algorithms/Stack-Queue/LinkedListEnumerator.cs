using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private readonly Node<T> _first;
        private Node<T> _current;

        public LinkedListEnumerator(Node<T> first)
        {
            _first = first;
            _current = new Node<T>
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