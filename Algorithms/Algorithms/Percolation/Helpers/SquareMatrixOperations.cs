using System;
using System.Collections.Generic;

namespace Algorithms.Percolation.Helpers
{
    public class SquareMatrixOperations
    {
        public List<int> FindAdjustmentElements(int tileIndex, int size)
        {
            var tileRow = FindRowNumber(tileIndex, size);
            var tileColumn = FindColumnNumber(tileIndex, size);

            if (tileRow == 1 && tileColumn == 1)
            {
                return new List<int> { tileIndex + 1, tileIndex + size };
            }

            if (tileRow == 1 && tileColumn == size)
            {
                return new List<int> { tileIndex - 1, tileIndex + size };
            }

            if (tileRow == size && tileColumn == 1)
            {
                return new List<int> { tileIndex + 1, tileIndex - size };
            }

            if (tileRow == size && tileColumn == size)
            {
                return new List<int> { tileIndex - 1, tileIndex - size };
            }

            if (tileRow == 1)
            {
                return new List<int> { tileIndex - 1, tileIndex + 1, tileIndex + size };
            }

            if (tileRow == size)
            {
                return new List<int> { tileIndex - 1, tileIndex + 1, tileIndex - size };
            }

            if (tileColumn == 1)
            {
                return new List<int> { tileIndex + 1, tileIndex - size, tileIndex + size };
            }

            if (tileColumn == size)
            {
                return new List<int> { tileIndex - 1, tileIndex - size, tileIndex + size };
            }

            return new List<int> { tileIndex - 1, tileIndex + 1, tileIndex - size, tileIndex + size };
        }

        public void PrintMatrixMap(List<bool> map, int size)
        {
            Console.Clear();

            var stringsToPrint = new List<string>();
            for (var i = 0; i < size; i++)
            {
                var stringToPrint = string.Empty;
                for (var j = i * size + 1; j < i * size + size + 1; j++)
                {
                    stringToPrint += map[j] ? "*" : "-";
                }
                stringsToPrint.Add(stringToPrint);
            }
            stringsToPrint.Reverse();

            foreach (var stringToPrint in stringsToPrint)
            {
                Console.WriteLine(stringToPrint);
            }
        }

        private int FindRowNumber(int index, int size) => index % size == 0 ? index / size : index / size + 1;

        private int FindColumnNumber(int index, int size) => index % size == 0 ? size : index % size;
    }
}