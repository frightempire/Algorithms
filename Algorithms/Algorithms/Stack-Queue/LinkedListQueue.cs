using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class LinkedListQueue<T> : IEnumerable<T>
    {
        private Node<T> _first;
        private Node<T> _last;

        public void Enqueue(T item)
        {
            var newLast = new Node<T>
            {
                Next = null,
                Item = item
            };

            if (_last != null)
            {
                _last.Next = newLast;
            }

            if (_first == null)
            {
                _first = newLast;
            }

            _last = newLast;
            Count++;
        }

        public T Dequeue()
        {
            var item = _first.Item;
            _first = _first.Next;
            Count--;
            return item;
        }

        public int Count { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}