using System;

namespace Algorithms.Sorting.Algorithm
{
    public static class Shell<T> where T : IComparable
    {
        public static void Sort(T[] array)
        {
            var h = 1;
            while (h < array.Length / 3)
            {
                h = 3 * h + 1;
            }

            while (h > 0)
            {
                for (var forward = h; forward < array.Length; forward++)
                {
                    var backward = forward;
                    while (backward > h - 1 && array[backward - h].CompareTo(array[backward]) > 0)
                    {
                        var valueToInsert = array[backward];
                        array[backward] = array[backward - h];
                        array[backward - h] = valueToInsert;
                        backward -= h;
                    }
                }

                h = (h - 1) / 3;
            }
        }
    }
}