using System;

namespace Algorithms.Sorting.Algorithm
{
    public static class Insertion<T> where T : IComparable
    {
        public static void Sort(T[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var current = array[i];
                var j = i - 1;
                while (j >= 0 && array[j].CompareTo(current) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = current;
            }
        }
    }
}