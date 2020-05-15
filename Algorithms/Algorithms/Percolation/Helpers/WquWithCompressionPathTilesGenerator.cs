using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Percolation.Helpers
{
    public class WquWithCompressionPathTilesGenerator
    {
        public List<int> GenerateInitialTiles(int size)
        {
            var tiles = Enumerable.Range(0, size * size + 2).ToList();
            for (var i = 1; i <= size; i++)
            {
                tiles[i] = 0;
            }
            for (var i = tiles.Count - 2; i > size * size - size; i--)
            {
                tiles[i] = tiles.Count - 1;
            }
            return tiles;
        }

        public List<int> GenerateInitialTreeSizes(int size)
        {
            var treeSizes = Enumerable.Repeat(1, size * size + 2).ToList();
            treeSizes[0] = treeSizes[treeSizes.Count - 1] = size;
            return treeSizes;
        }

        public List<bool> GenerateOpenTiles(int size)
        {
            var openTiles = Enumerable.Repeat(false, size * size + 2).ToList();
            openTiles[0] = openTiles[openTiles.Count - 1] = true;
            return openTiles;
        }
    }
}