using System.Collections;
using System.Collections.Generic;
using Algorithms.StackQueue.Helpers;

namespace Algorithms.StackQueue.Modifications
{
    /// <summary>
    /// A double-ended queue or deque is a generalization of a stack and a queue
    /// that supports adding and removing items from either the front or the back of the data structure
    /// </summary>
    public class Deque<T> : IEnumerable<T>
    {
        private DoublyLinkedNode<T> _first;
        private DoublyLinkedNode<T> _last;

        public void AddFirst(T item)
        {
            var newFirst = new DoublyLinkedNode<T>
            {
                Next = _first,
                Previous = null,
                Item = item
            };

            _first = newFirst;

            if (_last == null)
            {
                _last = newFirst;
            }

            if (_first?.Next != null)
            {
                _first.Next.Previous = _first;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            var newLast = new DoublyLinkedNode<T>
            {
                Next = null,
                Previous = _last,
                Item = item
            };

            _last = newLast;

            if (_first == null)
            {
                _first = newLast;
            }

            if (_last?.Previous != null)
            {
                _last.Previous.Next = _last;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            var item = _first.Item;
            _first = _first.Next;
            _first.Previous = null;
            Count--;
            return item;
        }

        public T RemoveLast()
        {
            var item = _last.Item;
            _last = _last.Previous;
            _last.Next = null;
            Count--;
            return item;
        }

        public int Count { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}