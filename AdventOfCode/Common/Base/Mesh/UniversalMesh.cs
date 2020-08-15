using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Base
{
    public class UniversalMesh<TNodeType>
    {
        #region Constructor
        public UniversalMesh()
        {

        }

        #endregion

        #region Properties
        public List<GenericNode<TNodeType>> Nodes { get; private set; }

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

        #endregion
    }
}
