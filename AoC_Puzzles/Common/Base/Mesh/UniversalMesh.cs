using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Base
{
    public class UniversalMesh<TNodeType>  where TNodeType : IEquatable<TNodeType>
    {
        #region Constructor
        public UniversalMesh()
        { }

        #endregion

        #region Properties
        public List<GenericNode<TNodeType>> Nodes { get; private set; } = new List<GenericNode<TNodeType>>();

        #endregion

        #region Methods
        public void AddNode(GenericNode<TNodeType> node)
        {
            Nodes.Add(node);
        }

        public void AddNode(TNodeType node)
        {
            AddNode(new GenericNode<TNodeType>(node));
        }

        public void InitPathfinding(GenericNode<TNodeType> start)
        {
            Nodes.ForEach(x => x.PathFinding = long.MaxValue);
            start.PathFinding = 0;
        }

        public List<GenericNode<TNodeType>> GetShortestPath(GenericNode<TNodeType> start, GenericNode<TNodeType> target, Func<GenericNode<TNodeType>, GenericNode<TNodeType>, bool> predicate)
        {
            InitPathfinding(start);
            return start.GetPathToTarget(target, predicate);
        }

        public List<GenericNode<TNodeType>> GetShortestPath(GenericNode<TNodeType> start, Func<GenericNode<TNodeType>, bool> target, Func<GenericNode<TNodeType>, GenericNode<TNodeType>, bool> predicate)
        {
            InitPathfinding(start);
            return start.GetPathToTarget(target, predicate, x => x.PathFinding + 1);
        }

        #endregion
    }
}
