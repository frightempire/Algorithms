using System;

namespace Algorithms.PriorityQueue.Structure
{
    public class BinaryHeap<T> where T : class, IComparable
    {
        private readonly T[] _queue;
        private int _size;

        public BinaryHeap()
        {
            _queue = new T[100];
            _queue[0] = null;
        }

        public void Insert(T element)
        {
            _size++;
            _queue[_size] = element;
            Swim(_size);
        }

        public T PopMinimum()
        {
            var minimum = _queue[1];
            Exchange(1, _size);
            _size--;
            Sink(1);
            _queue[_size + 1] = null;
            return minimum;
        }

        private void Swim(int position)
        {
            while (position > 1 && _queue[position].CompareTo(_queue[position/2]) < 0)
            {
                Exchange(position, position/2);
                position /= 2;
            }
        }

        private void Sink(int position)
        {
            while (position * 2 < _size)
            {
                var firstChild = _queue[position * 2];
                var secondChild = _queue[position * 2 + 1];
                if (firstChild.CompareTo(secondChild) <= 0)
                {
                    Exchange(position * 2, position);
                    position *= 2;
                }
                else
                {
                    Exchange(position * 2 + 1, position);
                    position = position * 2 + 1;
                }
            }
        }

        private void Exchange(int firstPosition, int secondPosition)
        {
            var temporary = _queue[firstPosition];
            _queue[firstPosition] = _queue[secondPosition];
            _queue[secondPosition] = temporary;
        }
    }
}