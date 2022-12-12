using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Base
{
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
        public List<TNodeType> Neighbors { get; private set; } = new List<TNodeType>();
        public TNodeType Parent { get; private set; }

        #endregion

        #region Methods
        /// <summary>
        /// Checks if item is a Neighbor
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool IsNeighbor(TNodeType item)
        {
            return Neighbors.Contains(item);
        }

        public void RemoveNeighbor(TNodeType item)
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
        /// Adds an item as Neighbor regardless if it already is or not
        /// </summary>
        /// <param name="item"></param>
        public void AddNeighbor(TNodeType item)
        {
            Neighbors.Add(item);
        }

        #endregion
    }
}
