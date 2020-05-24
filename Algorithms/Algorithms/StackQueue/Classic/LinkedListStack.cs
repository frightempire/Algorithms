using System.Collections;
using System.Collections.Generic;
using Algorithms.StackQueue.Helpers;

namespace Algorithms.StackQueue.Classic
{
    public class LinkedListStack<T> : IEnumerable<T>
    {
        private SinglyLinkedNode<T> _first;

        public void Push(T item)
        {
            var currentFirst = _first;
            _first = new SinglyLinkedNode<T>
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
            return new SinglyLinkedListEnumerator<T>(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}