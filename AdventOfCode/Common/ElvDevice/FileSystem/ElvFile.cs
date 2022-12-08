using AoC.AdventOfCode.Common.Base.Tree;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.ElvDevice.FileSystem
{
    [DebuggerDisplay("File - {Name} - Level {Level} - Size {Size}")]
    internal class ElvFile : TreeNode
    {
        #region Constructor
        public ElvFile(string name, long size) : this(name, size, null)
        { }

        public ElvFile(string name, long size, TreeNode parent) : base(parent)
        {
            Name = name;
            Size = size;
        }

        #endregion

        #region Properties
        public string Name { get; set; }

        #endregion

        #region Methods

        #endregion
    }
}
