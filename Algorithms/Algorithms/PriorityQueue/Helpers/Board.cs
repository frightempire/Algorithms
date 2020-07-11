using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.PriorityQueue.Helpers
{
    public class Board : IComparable
    {
        private readonly int[][] _tiles;
        private readonly int[][] _goalTiles = 
        {
            new[] {1, 2, 3},
            new[] {4, 5, 6},
            new[] {7, 8, 0}
        };

        public Board(int[][] tiles)
        {
            _tiles = tiles;
        }

        public bool IsGoal()
        {
            return "1 2 3 \n4 5 6 \n7 8 0 \n" == ToString();
        }

        public int HammingDistance()
        {
            var distance = 0;
            for (var i = 0; i < _goalTiles.Length; i++)
            {
                for (var j = 0; j < _goalTiles[i].Length; j++)
                {
                    if (_goalTiles[i][j] != _tiles[i][j])
                    {
                        distance++;
                    }
                }
            }
            return distance;
        }

        public List<Board> GetChildBoards()
        {
            int zeroRow = 0, zeroColumn = 0;
            for (var i = 0; i < _tiles.Length; i++)
            {
                for (var j = 0; j < _tiles[i].Length; j++)
                {
                    if (_tiles[i][j] != 0)
                    {
                        continue;
                    }

                    zeroRow = i;
                    zeroColumn = j;
                    break;
                }
            }

            if (zeroRow == 0 && zeroColumn == 0)
            {
                return new List<Board>
                {
                    new Board(new []
                    {
                        new[] { _tiles[0][1], _tiles[0][0], _tiles[0][2] },
                        new[] { _tiles[1][0], _tiles[1][1], _tiles[1][2] },
                        new[] { _tiles[2][0], _tiles[2][1], _tiles[2][2] }
                    }),
                    new Board(new []
                    {
                        new[] { _tiles[1][0], _tiles[0][1], _tiles[0][2] },
                        new[] { _tiles[0][0], _tiles[1][1], _tiles[1][2] },
                        new[] { _tiles[2][0], _tiles[2][1], _tiles[2][2] }
                    })
                };
            }

            if (zeroRow == 0 && zeroColumn == 2)
            {
                return new List<Board>
                {
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][1], _tiles[1][2] },
                        new[] { _tiles[1][0], _tiles[1][1], _tiles[0][2] },
                        new[] { _tiles[2][0], _tiles[2][1], _tiles[2][2] }
                    }),
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][2], _tiles[0][1] },
                        new[] { _tiles[1][0], _tiles[1][1], _tiles[1][2] },
                        new[] { _tiles[2][0], _tiles[2][1], _tiles[2][2] }
                    })
                };
            }

            if (zeroRow == 2 && zeroColumn == 0)
            {
                return new List<Board>
                {
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][1], _tiles[0][2] },
                        new[] { _tiles[2][0], _tiles[1][1], _tiles[1][2] },
                        new[] { _tiles[1][0], _tiles[2][1], _tiles[2][2] }
                    }),
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][1], _tiles[0][2] },
                        new[] { _tiles[1][0], _tiles[1][1], _tiles[1][2] },
                        new[] { _tiles[2][1], _tiles[2][0], _tiles[2][2] }
                    })
                };
            }

            if (zeroRow == 2 && zeroColumn == 2)
            {
                return new List<Board>
                {
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][1], _tiles[0][2] },
                        new[] { _tiles[1][0], _tiles[1][1], _tiles[2][2] },
                        new[] { _tiles[2][0], _tiles[2][1], _tiles[1][2] }
                    }),
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][1], _tiles[0][2] },
                        new[] { _tiles[1][0], _tiles[1][1], _tiles[1][2] },
                        new[] { _tiles[2][0], _tiles[2][2], _tiles[2][1] }
                    })
                };
            }

            if (zeroRow == 0)
            {
                return new List<Board>
                {
                    new Board(new []
                    {
                        new[] { _tiles[0][1], _tiles[0][0], _tiles[0][2] },
                        new[] { _tiles[1][0], _tiles[1][1], _tiles[1][2] },
                        new[] { _tiles[2][0], _tiles[2][1], _tiles[2][2] }
                    }),
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][2], _tiles[0][1] },
                        new[] { _tiles[1][0], _tiles[1][1], _tiles[1][2] },
                        new[] { _tiles[2][0], _tiles[2][1], _tiles[2][2] }
                    }),
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[1][1], _tiles[0][2] },
                        new[] { _tiles[1][0], _tiles[0][1], _tiles[1][2] },
                        new[] { _tiles[2][0], _tiles[2][1], _tiles[2][2] }
                    })
                };
            }

            if (zeroRow == 2)
            {
                return new List<Board>
                {
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][1], _tiles[0][2] },
                        new[] { _tiles[1][0], _tiles[1][1], _tiles[1][2] },
                        new[] { _tiles[2][1], _tiles[2][0], _tiles[2][2] }
                    }),
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][1], _tiles[0][2] },
                        new[] { _tiles[1][0], _tiles[1][1], _tiles[1][2] },
                        new[] { _tiles[2][0], _tiles[2][2], _tiles[2][1] }
                    }),
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][1], _tiles[0][2] },
                        new[] { _tiles[1][0], _tiles[2][1], _tiles[1][2] },
                        new[] { _tiles[2][0], _tiles[1][1], _tiles[2][2] }
                    })
                };
            }

            if (zeroColumn == 0)
            {
                return new List<Board>
                {
                    new Board(new []
                    {
                        new[] { _tiles[1][0], _tiles[0][1], _tiles[0][2] },
                        new[] { _tiles[0][0], _tiles[1][1], _tiles[1][2] },
                        new[] { _tiles[2][0], _tiles[2][1], _tiles[2][2] }
                    }),
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][1], _tiles[0][2] },
                        new[] { _tiles[2][0], _tiles[1][1], _tiles[1][2] },
                        new[] { _tiles[1][0], _tiles[2][1], _tiles[2][2] }
                    }),
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][1], _tiles[0][2] },
                        new[] { _tiles[1][1], _tiles[1][0], _tiles[1][2] },
                        new[] { _tiles[2][0], _tiles[2][1], _tiles[2][2] }
                    })
                };
            }

            if (zeroColumn == 2)
            {
                return new List<Board>
                {
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][1], _tiles[1][2] },
                        new[] { _tiles[1][0], _tiles[1][1], _tiles[2][2] },
                        new[] { _tiles[2][0], _tiles[2][1], _tiles[2][2] }
                    }),
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][1], _tiles[0][2] },
                        new[] { _tiles[1][0], _tiles[1][1], _tiles[2][2] },
                        new[] { _tiles[2][0], _tiles[2][1], _tiles[1][2] }
                    }),
                    new Board(new []
                    {
                        new[] { _tiles[0][0], _tiles[0][1], _tiles[0][2] },
                        new[] { _tiles[1][0], _tiles[1][2], _tiles[1][1] },
                        new[] { _tiles[2][0], _tiles[2][1], _tiles[2][2] }
                    })
                };
            }

            return new List<Board>
            {
                new Board(new []
                {
                    new[] { _tiles[0][0], _tiles[1][1], _tiles[0][2] },
                    new[] { _tiles[1][0], _tiles[0][1], _tiles[1][2] },
                    new[] { _tiles[2][0], _tiles[2][1], _tiles[2][2] }
                }),
                new Board(new []
                {
                    new[] { _tiles[0][0], _tiles[0][1], _tiles[0][2] },
                    new[] { _tiles[1][1], _tiles[1][0], _tiles[1][2] },
                    new[] { _tiles[2][0], _tiles[2][1], _tiles[2][2] }
                }),
                new Board(new []
                {
                    new[] { _tiles[0][0], _tiles[0][1], _tiles[0][2] },
                    new[] { _tiles[1][0], _tiles[2][1], _tiles[1][2] },
                    new[] { _tiles[2][0], _tiles[1][1], _tiles[2][2] }
                }),
                new Board(new []
                {
                    new[] { _tiles[0][0], _tiles[0][1], _tiles[0][2] },
                    new[] { _tiles[1][0], _tiles[1][2], _tiles[1][1] },
                    new[] { _tiles[2][0], _tiles[2][1], _tiles[2][2] }
                })
            };
        }

        public override string ToString()
        {
            return _tiles.Aggregate(string.Empty, (current1, zeroRow) => $"{zeroRow.Aggregate(current1, (current, tile) => current + $"{tile} ")}\n");
        }

        public int CompareTo(object obj)
        {
            var compareWith = (Board) obj;
            return compareWith.HammingDistance() < HammingDistance() ? 1 : compareWith.HammingDistance() == HammingDistance() ? 0 : -1;
        }
    }
}