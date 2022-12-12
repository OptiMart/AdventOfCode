using AoC.Puzzles.Common.Base.Tree;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.ElvDevice.FileSystem
{
    [DebuggerDisplay("Directory - {Name} - Level {Level} - Size {Size}")]
    internal class ElvDirectory : TreeNode
    {
        #region Data

        #endregion

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
            ElvFile result = new ElvFile(name, size, this);
            AddChild(result);
            return result;
        }

        public void CalcDirectorySize()
        {
            foreach (var directory in Children.OfType<ElvDirectory>())
                directory.CalcDirectorySize();

            Size = Children.Sum(x => x.Size);
        }

        public long GetDirectorySize(int depth)
        {
            long result = 0;

            foreach (var file in Children.OfType<ElvFile>())
                result += file.Size;

            if (depth != 0)
            {
                foreach (var directory in Children.OfType<ElvDirectory>())
                {
                    result += directory.GetDirectorySize(depth - 1);
                }
            }

            return result;
        }

        public long GetDirectorySizeSummary(int depth, Func<ElvDirectory, bool> predicate)
        {
            long result = 0;
            long sub = 0;

            if (depth != 0)
            {
                foreach (var directory in Children.OfType<ElvDirectory>())
                {
                    sub += directory.GetDirectorySizeSummary(depth - 1, predicate);
                }
            }

            if (predicate.Invoke(this))
                result += Size;

            result += sub;
            
            return result;
        }

        public List<ElvDirectory> GetDirectory(Func<ElvDirectory, bool> predicate)
        {
            List<ElvDirectory> result = Children.OfType<ElvDirectory>().Where(predicate).ToList();

            foreach (var dir in Children.OfType<ElvDirectory>())
                result.AddRange(dir.GetDirectory(predicate));

            return result;
        }

        #endregion
    }
}
