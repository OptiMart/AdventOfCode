using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.SpaceMap
{
    [DebuggerDisplay("<{X}, {Y}, {Z}>")]
    public class SpaceVector : ICoord3D
    {
        #region Constructor
        public SpaceVector() : this (0, 0, 0)
        { }

        public SpaceVector(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

        #region Properties
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        #endregion

        #region Methods
        public int GetEnergy()
        {
            return Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
        }

        public override bool Equals(object? obj)
        {
            SpaceVector vec = obj as SpaceVector;

            if (vec is null)
                return false;
            else
                return this.X == vec.X && this.Y == vec.Y && this.Z == vec.Z;
        }
        #endregion
    }
}
