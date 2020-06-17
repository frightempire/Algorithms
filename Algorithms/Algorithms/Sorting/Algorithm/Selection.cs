using System;

namespace Algorithms.Sorting.Algorithm
{
    public static class Selection<T> where T : IComparable
    {
        public static void Sort(T[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var minIndex = i;
                for (var j = i+1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                var beginning = array[i];
                array[i] = array[minIndex];
                array[minIndex] = beginning;
            }
        }
    }
}