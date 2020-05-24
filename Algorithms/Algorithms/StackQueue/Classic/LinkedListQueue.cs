using System.Collections;
using System.Collections.Generic;
using Algorithms.StackQueue.Helpers;

namespace Algorithms.StackQueue.Classic
{
    public class LinkedListQueue<T> : IEnumerable<T>
    {
        private SinglyLinkedNode<T> _first;
        private SinglyLinkedNode<T> _last;

        public void Enqueue(T item)
        {
            var newLast = new SinglyLinkedNode<T>
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
            return new SinglyLinkedListEnumerator<T>(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}