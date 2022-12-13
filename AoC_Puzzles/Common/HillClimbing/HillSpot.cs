using AoC.Puzzles.Common.Base;
using AoC.Puzzles.Common.Base.Points;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AoC.Puzzles.Common.HillClimbing
{
    [DebuggerDisplay("{Value} - ({X}/{Y})")]
    internal class HillSpot : BasePoint2D<char>, IEquatable<HillSpot>
    {
        #region Constructor
        public HillSpot(int x, int y, char value) : base(value, x, y)
        {
            //SetCoord(x, y);
            //X = x;
            //Y = y;
            //Value = value;
            Height = GetHeight(value);
        }

        #endregion

        #region Properties
        public int Height { get; private set; }

        #endregion

        #region Methods
        public int GetHeight(char value)
        {
            switch (value)
            {
                case 'S':
                    return 1;
                case 'E':
                    return 26;
                default:
                    return value.ToString().ToLower()[0] - 'a' + 1;
            }
        }

        public bool Equals(HillSpot? other)
        {
            if (other is null)
                return false;

            return this == other;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            return Equals(obj as HillSpot);
        }

        public override int GetHashCode()
        {
            return new Tuple<int, int>(base.GetHashCode(), Height.GetHashCode()).GetHashCode();
        }
        #endregion
    }
}
