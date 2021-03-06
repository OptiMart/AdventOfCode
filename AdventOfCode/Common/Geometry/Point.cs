﻿using AoC.AdventOfCode.Common.IntCodeComputer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Geometry
{
    [DebuggerDisplay("({PointX}/{PointY})")]
    public class Point
    {
        #region Constructor
        public Point() : this(0, 0)
        { }

        public Point(int x, int y)
        {
            PointX = x;
            PointY = y;
        }

        public Point(string vector) : this(0, 0, vector)
        { }

        public Point(int x, int y, string vector) : this(x, y)
        {
            MovePoint(vector);
        }

        #endregion

        #region Properties
        public int PointX { get; set; }
        public int PointY { get; set; }
        public int ManhattanDistance => Math.Abs(PointX) + Math.Abs(PointY);
        public Tiles Tile { get; set; }

        #endregion

        #region Methods
        public void MovePoint(int x, int y)
        {
            PointX += x;
            PointY += y;
        }

        public void MovePoint(string vector)
        {
            if (string.IsNullOrEmpty(vector))
                return;

            char direction = vector[0];
            int.TryParse(vector.Substring(1), out int distance);

            if (direction == 'L' || direction == 'D')
                distance *= -1;

            if (direction == 'R' || direction == 'L')
                MovePoint(distance, 0);
            else if (direction == 'U' || direction == 'D')
                MovePoint(0, distance);

        }

        #endregion
    }
}
