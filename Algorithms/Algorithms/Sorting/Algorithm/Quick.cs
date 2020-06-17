using System;

namespace Algorithms.Sorting.Algorithm
{
    public static class Quick<T> where T : IComparable
    {
        public static void Sort(T[] array)
        {
            RecursiveSort(array, 0, array.Length - 1);
        }

        private static void RecursiveSort(T[] array, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            var partitionIndex = Partition(array, low, high);
            RecursiveSort(array, low, partitionIndex - 1);
            RecursiveSort(array, partitionIndex + 1, high);
        }

        private static int Partition(T[] array, int low, int high)
        {
            var partitionElement = array[low];

            var i = low + 1;
            var j = high;

            while (true)
            {
                while (i < high && array[i].CompareTo(partitionElement) <= 0)
                {
                    i++;
                }
                while (j > low && array[j].CompareTo(partitionElement) > 0)
                {
                    j--;
                }

                if (i >= j)
                {
                    break;
                }

                Swap(array, i, j);
            }

            Swap(array, low, j);
            return j;
        }

        private static void Swap(T[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}