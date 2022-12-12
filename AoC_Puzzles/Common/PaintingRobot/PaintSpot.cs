using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.PaintingRobot
{
    public class PaintSpot
    {
        #region Constructor
        public PaintSpot() : this(0, 0)
        { }

        public PaintSpot(int x, int y) : this(x, y, PaintColor.Black)
        { }

        public PaintSpot(int x, int y, PaintColor color)
        {
            CoordX = x;
            CoordY = y;
            Color = color;
        }

        #endregion

        #region Properties
        public int CoordX { get; private set; }
        public int CoordY { get; private set; }
        public PaintColor Color { get; set; }

        #endregion
    }
}
