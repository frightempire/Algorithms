using System.Collections.Generic;
using System.Linq;
using Algorithms.Trees.Helpers;

namespace Algorithms.Trees.Structure
{
    /// <summary>
    /// 2d binary search tree
    /// </summary>
    public class TwoDimensionalTree
    {
        private DoublyLinkedNode<Point> Root { get; set; }

        public bool Contains(Point point)
        {
            var child = Root;
            while (child != null)
            {
                if (point.CompareTo(child.Item) == 0)
                {
                    return true;
                }

                child = child.Dimension == Dimension.X ?
                    point.X <= child.Item.X ? child.Left : child.Right :
                    point.Y <= child.Item.Y ? child.Left : child.Right;
            }

            return false;
        }

        public void Add(Point point)
        {
            if (Root == null)
            {
                Root = new DoublyLinkedNode<Point> { Item = point, Left = null, Right = null, Dimension = Dimension.X, Parent = null };
                return;
            }

            if (Contains(point))
            {
                return;
            }

            var child = Root;
            var parent = child;
            var isLeft = true;
            while (child != null)
            {
                parent = child;
                if (child.Dimension == Dimension.X && point.X <= child.Item.X || child.Dimension == Dimension.Y && point.Y <= child.Item.Y)
                {
                    child = child.Left;
                    isLeft = true;
                }
                else
                {
                    child = child.Right;
                    isLeft = false;
                }
            }

            child = new DoublyLinkedNode<Point>
            {
                Item = point, Left = null, Right = null, Parent = parent,
                Dimension = parent.Dimension == Dimension.X ? Dimension.Y : Dimension.X
            };

            if (isLeft)
            {
                parent.Left = child;
            }
            else
            {
                parent.Right = child;
            }
        }

        #region Remove

        public void Remove(Point point)
        {
            if (!Contains(point))
            {
                return;
            }

            var child = Root;
            while (point.CompareTo(child.Item) != 0)
            {
                child = child.Dimension == Dimension.X ?
                    point.X <= child.Item.X ? child.Left : child.Right :
                    point.Y <= child.Item.Y ? child.Left : child.Right;
            }

            RecursiveRemove(child);
        }

        private void RecursiveRemove(DoublyLinkedNode<Point> node)
        {
            // deleting leaf
            if (node.Left == null && node.Right == null)
            {
                if (node.Parent.Left != null && node.Parent.Left.Item.CompareTo(node.Item) == 0)
                {
                    node.Parent.Left = null;
                }
                else
                {
                    node.Parent.Right = null;
                }
                return;
            }

            // replace with minimum from right side
            if (node.Right != null)
            {
                var minimum = Minimum(node.Right, node.Dimension);
                node.Item = minimum.Item;
                RecursiveRemove(minimum);
            }
            // replace with minimum from left side
            else if (node.Left != null)
            {
                var minimum = Minimum(node.Left, node.Dimension);
                node.Item = minimum.Item;
                node.Right = node.Left;
                node.Left = null;
                RecursiveRemove(minimum);
            }
        }

        private DoublyLinkedNode<Point> Minimum(DoublyLinkedNode<Point> parent, Dimension dimension)
        {
            if (parent == null)
            {
                return null;
            }

            if (parent.Left == null && parent.Right == null)
            {
                return parent;
            }

            return MinimumNode(parent, Minimum(parent.Left, dimension), Minimum(parent.Right, dimension), dimension);
        }

        private DoublyLinkedNode<Point> MinimumNode(DoublyLinkedNode<Point> parent, DoublyLinkedNode<Point> left, DoublyLinkedNode<Point> right, Dimension dimension)
        {
            var minimum = parent;
            if (left != null &&
                (dimension == Dimension.X && left.Item.X < minimum.Item.X || dimension == Dimension.Y && left.Item.Y < minimum.Item.Y))
            {
                minimum = left;
            }
            if (right != null &&
                (dimension == Dimension.X && right.Item.X < minimum.Item.X || dimension == Dimension.Y && right.Item.Y < minimum.Item.Y))
            {
                minimum = right;
            }
            return minimum;
        }

        #endregion

        #region RectangleSearch

        public List<Point> RectangleSearch(Rectangle rectangle)
        {
            return RecursiveRectangleSearch(rectangle, Root);
        }

        private List<Point> RecursiveRectangleSearch(Rectangle rectangle, DoublyLinkedNode<Point> root)
        {
            if (root == null)
            {
                return new List<Point>();
            }

            var points = new List<Point>();
            if (rectangle.Contains(root.Item))
            {
                points.Add(root.Item);
            }

            if (root.Dimension == Dimension.X)
            {
                if (rectangle.MaxX <= root.Item.X)
                {
                    points.AddRange(RecursiveRectangleSearch(rectangle, root.Left));
                }
                else if (rectangle.MaxX > root.Item.X && rectangle.MinX > root.Item.X)
                {
                    points.AddRange(RecursiveRectangleSearch(rectangle, root.Right));
                }
                else
                {
                    points.AddRange(RecursiveRectangleSearch(rectangle, root.Left).Concat(RecursiveRectangleSearch(rectangle, root.Right)));
                }
            }
            else
            {
                if (rectangle.MaxY <= root.Item.Y)
                {
                    points.AddRange(RecursiveRectangleSearch(rectangle, root.Left));
                }
                else if (rectangle.MaxY > root.Item.Y && rectangle.MinY > root.Item.Y)
                {
                    points.AddRange(RecursiveRectangleSearch(rectangle, root.Right));
                }
                else
                {
                    points.AddRange(RecursiveRectangleSearch(rectangle, root.Left).Concat(RecursiveRectangleSearch(rectangle, root.Right)));
                }
            }

            return points;
        }

        #endregion

        #region NearestNeighborSearch

        public Point NearestNeighborSearch(Point point)
        {
            return RecursiveNearestNeighborSearch(point, Root);
        }

        private Point RecursiveNearestNeighborSearch(Point point, DoublyLinkedNode<Point> root)
        {
            if (root.Parent != null && point.DistanceTo(root.Parent.Item) < point.DistanceTo(root.Item))
            {
                return root.Parent.Item;
            }

            return root.Dimension == Dimension.X ? 
                RecursiveNearestNeighborSearch(point, point.X <= root.Item.X ? root.Left : root.Right) :
                RecursiveNearestNeighborSearch(point, point.Y <= root.Item.Y ? root.Left : root.Right);
        }

        #endregion
    }
}