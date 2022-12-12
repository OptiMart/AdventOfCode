using AoC.Puzzles.Common.HillClimbing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Base
{
    [DebuggerDisplay("Node: {Node} - Pathfinding({PathFinding})")]
    public class GenericNode<TNodeType>
    {
        #region Constructor
        public GenericNode() : this(default)
        { }

        public GenericNode(TNodeType node)
        {
            Node = node;
        }

        #endregion

        #region Properties
        public TNodeType Node { get; set; }
        public Type NodeType => typeof(TNodeType);
        public List<GenericNode<TNodeType>> Neighbors { get; private set; } = new List<GenericNode<TNodeType>>();
        public GenericNode<TNodeType> Parent { get; private set; }
        public long PathFinding { get; set; }

        #endregion

        #region Methods
        /// <summary>
        /// Checks if item is a Neighbor
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool IsNeighbor(TNodeType item)
        {
            return Neighbors.Any(x => x.Node.Equals(item));
        }

        /// <summary>
        /// Checks if item is a Neighbor
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool IsNeighbor(GenericNode<TNodeType> item)
        {
            return Neighbors.Contains(item);
        }

        public void RemoveNeighbor(TNodeType item)
        {
            Neighbors.RemoveAll(x => x.Node.Equals(item));
        }

        public void RemoveNeighbor(GenericNode<TNodeType> item)
        {
            while (Neighbors.Remove(item))
            {
                // Remove all occurancies of this item
            }

        }

        /// <summary>
        /// Adds an item as Neighbor if not already added
        /// </summary>
        /// <param name="item"></param>
        public void CheckOrAddNeighbor(TNodeType item)
        {
            if (!IsNeighbor(item))
                AddNeighbor(item);
        }

        /// <summary>
        /// Adds an item as Neighbor if not already added
        /// </summary>
        /// <param name="item"></param>
        public void CheckOrAddNeighbor(GenericNode<TNodeType> item)
        {
            if (!IsNeighbor(item))
                AddNeighbor(item);
        }

        /// <summary>
        /// Adds an item as Neighbor regardless if it already is or not
        /// </summary>
        /// <param name="item"></param>
        public void AddNeighbor(TNodeType item)
        {
            AddNeighbor(new GenericNode<TNodeType>(item));
        }

        /// <summary>
        /// Adds an item as Neighbor regardless if it already is or not
        /// </summary>
        /// <param name="item"></param>
        public void AddNeighbor(GenericNode<TNodeType> item)
        {
            if (item != null && !Equals(item))
                Neighbors.Add(item);
        }

        public long GetDistanceToTarget(GenericNode<TNodeType> target)
        {
            if (Equals(target))
                return 0;

            long distance = int.MaxValue;

            foreach (var item in Neighbors)
            {
                var dist = item.GetDistanceToTarget(target) + 1;

                if (dist < distance)
                    distance = dist;
            }

            return distance;
        }

        public List<GenericNode<TNodeType>> GetPathToTarget(GenericNode<TNodeType> target, Func<GenericNode<TNodeType>, GenericNode<TNodeType>, bool> neighbor)
        {
            return GetPathToTarget(x => x.Equals(target), neighbor, y => y.PathFinding + 1);
        }

        public List<GenericNode<TNodeType>> GetPathToTarget(Func<GenericNode<TNodeType>, bool> target, Func<GenericNode<TNodeType>, GenericNode<TNodeType>, bool> neighbor, Func<GenericNode<TNodeType>, long> pathcost)
        {
            List<GenericNode<TNodeType>> result = new List<GenericNode<TNodeType>>();

            foreach (var item in Neighbors.Where(x => x.PathFinding > pathcost.Invoke(this) && neighbor.Invoke(this, x)))
            {
                //item.PathFinding = PathFinding + 1;
                item.PathFinding = pathcost.Invoke(this);

                if (target.Invoke(item))
                {
                    result.Add(this);
                    result.Add(item);
                    return result;
                }

                var path = item.GetPathToTarget(target, neighbor, pathcost);

                if (path.Any())
                {
                    if (result.Count > path.Count)
                        result.Clear();

                    if (result.Count == 0)
                    {
                        result.Add(this);
                        result.AddRange(path);
                    }
                }
            }

            return result;
        }

        #endregion
    }
}
