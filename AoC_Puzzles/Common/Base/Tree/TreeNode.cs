using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Base.Tree
{
    public class TreeNode
    {
        #region Constructor
        public TreeNode()
        { }

        public TreeNode(TreeNode parent)
        {
            Parent = parent;
        }

        #endregion

        #region Properties
        public List<TreeNode> Children { get; private set; } = new List<TreeNode>();
        public TreeNode Parent { get; private set; }
        public long Size { get; set; }
        public int Level
        {
            get { return Parent?.Level + 1 ?? 0; }
        }

        public bool IsLeaf
        {
            get { return !Children?.Any() ?? false; }
        }

        public bool IsRoot
        {
            get { return Parent is null; }
        }

        #endregion

        #region Methods
        public void AddChild(TreeNode node)
        {
            Children?.Add(node);
        }

        public void AddChildren(IEnumerable<TreeNode> nodes)
        {
            foreach (var node in nodes)
                AddChild(node);
        }

        public void RemoveChild(TreeNode node)
        {
            Children?.Remove(node);
        }

        public void RemoveChildren(IEnumerable<TreeNode> nodes)
        {
            foreach (var node in nodes)
                RemoveChild(node);
        }

        #endregion
    }
}
