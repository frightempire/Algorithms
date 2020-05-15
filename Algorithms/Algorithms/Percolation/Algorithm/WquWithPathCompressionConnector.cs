using System.Collections.Generic;

namespace Algorithms.Percolation.Algorithm
{
    /// <summary>
    /// Weighted quick union (WQU) with path compression
    /// </summary>
    public class WquWithPathCompressionConnector
    {
        public void Connect(int indexA, int indexB, List<int> tiles, List<int> treeSizes)
        {
            var treeSizeA = treeSizes[indexA];
            var treeSizeB = treeSizes[indexB];
            var rootA = Root(indexA, tiles);
            var rootB = Root(indexB, tiles);

            if (treeSizeA <= treeSizeB)
            {
                tiles[rootA] = rootB;
                treeSizes[rootB] += treeSizes[rootA];
            }
            else
            {
                tiles[rootB] = rootA;
                treeSizes[rootA] += treeSizes[rootB];
            }
        }

        public bool Connected(int indexA, int indexB, List<int> tiles) => Root(indexA, tiles) == Root(indexB, tiles);

        private int Root(int index, List<int> tiles)
        {
            while (tiles[index] != index)
            {
                index = tiles[tiles[index]];
            }
            return index;
        }
    }
}