using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Algorithms.Percolation.Algorithm;
using Algorithms.Percolation.Helpers;

namespace Algorithms.Percolation
{
    public class Percolator
    {
        private readonly List<int> _tiles;
        private readonly List<int> _treeSizes;
        private readonly List<bool> _openTiles;
        private readonly int _size;

        private readonly WquWithPathCompressionConnector _connector;
        private readonly RandomProvider _randomProvider;
        private readonly SquareMatrixOperations _matrixOperations;

        public Percolator(int size,
            WquWithPathCompressionConnector connector,
            WquWithCompressionPathTilesGenerator tilesGenerator,
            RandomProvider randomProvider,
            SquareMatrixOperations matrixOperations)
        {
            _size = size;
            _connector = connector ?? throw new ArgumentNullException(nameof(connector));
            _randomProvider = randomProvider ?? throw new ArgumentNullException(nameof(randomProvider));
            _matrixOperations = matrixOperations ?? throw new ArgumentNullException(nameof(matrixOperations));
            if (tilesGenerator == null)
            {
                throw new ArgumentNullException(nameof(tilesGenerator));
            }

            _tiles = tilesGenerator.GenerateInitialTiles(size);
            _treeSizes = tilesGenerator.GenerateInitialTreeSizes(size);
            _openTiles = tilesGenerator.GenerateOpenTiles(size);
        }

        public int BeginPercolation()
        {
            while (!_connector.Connected(0, _tiles.Count - 1, _tiles))
            {
                OpenTile();
                Thread.Sleep(250);
                _matrixOperations.PrintMatrixMap(_openTiles, _size);
            }

            return _openTiles.Count(t => t);
        }

        private void OpenTile()
        {
            var tileToOpen = FindClosedTile();
            _openTiles[tileToOpen] = true;
            var adjustmentTiles = _matrixOperations.FindAdjustmentElements(tileToOpen, _size);
            foreach (var adjustmentTile in adjustmentTiles)
            {
                if (_openTiles[adjustmentTile])
                {
                    _connector.Connect(tileToOpen, adjustmentTile, _tiles, _treeSizes);
                }
            }
        }

        private int FindClosedTile()
        {
            var tile = 0;
            while (_openTiles[tile])
            {
                tile = _randomProvider.GetRandomNumberInRange(1, _tiles.Count - 2);
            }
            return tile;
        }
    }
}