using Algorithms.PriorityQueue.Algorithm;

namespace Algorithms.PriorityQueue.Helpers
{
    public class PuzzleSolver
    {
        private readonly BinaryHeap<SolutionNode> _solution = new BinaryHeap<SolutionNode>();
        private readonly Board _initialBoard;

        public PuzzleSolver(Board initialBoard)
        {
            _initialBoard = initialBoard;
        }

        public int Solve()
        {
            _solution.Insert(new SolutionNode(_initialBoard, null));
            var isGoal = false;
            while (!isGoal)
            {
                var minimumNode = _solution.PopMinimum();
                var minimumBoard = minimumNode.Board;

                if (minimumBoard.IsGoal())
                {
                    isGoal = true;
                    continue;
                }

                var children = minimumBoard.GetChildBoards();
                foreach (var child in children)
                {
                    if (minimumNode.ParentBoardNode != null && child.ToString() == minimumNode.ParentBoardNode.Board.ToString())
                    {
                        continue;
                    }
                    _solution.Insert(new SolutionNode(child, minimumNode));
                }
            }

            return _solution.PopMinimum().GetHeight();
        }
    }
}