using System;

namespace Algorithms.PriorityQueue.Helpers
{
    public class SolutionNode : IComparable
    {
        public Board Board { get; }

        public SolutionNode ParentBoardNode { get; }

        public SolutionNode(Board board, SolutionNode parentBoardNode)
        {
            Board = board;
            ParentBoardNode = parentBoardNode;
        }

        public int GetHeight()
        {
            var height = 1;
            var currentParentNode = ParentBoardNode;
            while (currentParentNode.ParentBoardNode != null)
            {
                height += 1;
                currentParentNode = currentParentNode.ParentBoardNode;
            }
            return height;
        }

        public int CompareTo(object obj)
        {
            var compareWith = (SolutionNode) obj;
            return Board.CompareTo(compareWith.Board);
        }
    }
}