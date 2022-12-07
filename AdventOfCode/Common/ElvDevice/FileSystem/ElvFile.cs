using AoC.AdventOfCode.Common.Base.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.ElvDevice.FileSystem
{
    internal class ElvFile : TreeNode
    {
        #region Constructor
        public ElvFile(string name, long size)
        {
            Name = name;
            Size = size;
        }

        #endregion

        #region Properties
        public string Name { get; set; }
        public string Path { get; set; }
        public string FullPath { get; set; }
        public long Size { get; set; }

        #endregion

        #region Methods

        #endregion
    }
}
