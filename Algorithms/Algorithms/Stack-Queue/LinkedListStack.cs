using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class LinkedListStack<T> : IEnumerable<T>
    {
        private Node<T> _first;

        public void Push(T item)
        {
            var currentFirst = _first;
            _first = new Node<T>
            {
                Next = currentFirst,
                Item = item
            };
            Count++;
        }

        public T Pop()
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