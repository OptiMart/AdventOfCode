using AoC.AdventOfCode.Common.Base.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.ElvDevice.FileSystem
{
    internal class ElvDirectory : TreeNode
    {
        #region Constructor
        public ElvDirectory(string name) : this(name, null)
        {
        }

        public ElvDirectory(string name, ElvDirectory parent) : base(parent)
        {
            Name = name;
        }

        #endregion

        #region Properties
        public string Name { get; set; }

        #endregion

        #region Methods
        public ElvDirectory AddDirectory(string name)
        {
            ElvDirectory result = new ElvDirectory(name, this);
            AddChild(result);
            return result;
        }

        public ElvFile AddFile(string name, long size)
        {
            ElvFile result = new ElvFile(name, size);
            AddChild(result);
            return result;
        }
        #endregion
    }
}
