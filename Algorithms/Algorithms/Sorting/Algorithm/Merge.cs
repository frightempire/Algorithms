using System;

namespace Algorithms.Sorting.Algorithm
{
    public static class Merge<T> where T : IComparable
    {
        public static void Sort(T[] array)
        {
            RecursiveSort(array, new T[array.Length], 0, array.Length - 1);
        }

        private static void RecursiveSort(T[] array, T[] tmpArray, int low, int high)
        {
            if (high <= low)
            {
                return;
            }

            var mid = low + (high - low) / 2;
            RecursiveSort(array, tmpArray, low, mid);
            RecursiveSort(array, tmpArray, mid+1, high);
            MergeArrays(array, tmpArray, low, mid, high);
        }

        private static void MergeArrays(T[] array, T[] tmpArray, int low, int mid, int high)
        {
            for (var i = low; i <= high; i++)
            {
                tmpArray[i] = array[i];
            }

            var first = low;
            var second = mid + 1;
            for (var i = low; i <= high; i++)
            {
                if (second > high)
                {
                    array[i] = tmpArray[first];
                    first++;
                }
                else if (first > mid)
                {
                    array[i] = tmpArray[second];
                    second++;
                }
                else if (tmpArray[first].CompareTo(tmpArray[second]) >= 0)
                {
                    array[i] = tmpArray[second];
                    second++;
                }
                else
                {
                    array[i] = tmpArray[first];
                    first++;
                }
            }
        }
    }
}