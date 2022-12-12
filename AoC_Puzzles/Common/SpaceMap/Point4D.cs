using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.SpaceMap
{
    [DebuggerDisplay("<{X}, {Y}, {Z}, {T}>")]
    public class Point4D
    {
        #region Data
        private int _x;
        private int _y;
        private int _z;
        private int _t;
        private bool _marked;

        #endregion

        public Point4D(string input, char separator = ',')
        {
            var coord = input.Split(separator);

            int.TryParse(coord[0], out _x);
            int.TryParse(coord[1], out _y);
            int.TryParse(coord[2], out _z);
            int.TryParse(coord[3], out _t);
        }

        public Point4D(int x, int y, int z, int t)
        {
            _x = x;
            _y = y;
            _z = z;
            _t = t;
        }

        #region Properties
        public int X => _x;
        public int Y => _y;
        public int Z => _z;
        public int T => _t;
        public List<Point4D> Neighbours { get; private set; } = new List<Point4D>();
        public Point4D Parent { get; set; }
        public int Constellation { get; set; } = int.MaxValue;

        #endregion

        #region Methods
        public int GetManhattanDistance(Point4D point)
        {
            return Math.Abs(X - point.X) + Math.Abs(Y - point.Y) + Math.Abs(Z - point.Z) + Math.Abs(T - point.T);
        }

        public void CheckAllNeighbours(List<Point4D> points)
        {
            foreach (var point in points)
            {
                if (this == point || GetManhattanDistance(point) > 3)
                    continue;

                if (!Neighbours.Contains(point))
                {
                    Neighbours.Add(point);
                }

                //if (point.Parent is null)
                //{
                //    if (!point.Neighbours.Contains(this))
                //    {
                //        point.Parent = this;
                //        Neighbours.Add(point);
                //    }
                //    else
                //    {
                //        int i = 0;
                //    }
                //}
                //else
                //{
                //    point.Neighbours.Add(this);
                //    Parent = point;
                //}
            }
        }

        public int MarkConstellation(int number)
        {
            if (Constellation <= number)
                return Constellation;

            //int minConst = number < Constellation ? number : Constellation;

            //do
            //{
            //    Constellation = minConst;
            //    foreach (var item in Neighbours)
            //    {
            //        int result = item.MarkConstellation(Constellation);
            //        minConst = result < minConst ? result : minConst;
            //    }
            //} while (Constellation != minConst);

            Constellation = number;
            bool error = false;
            foreach (var item in Neighbours)
            {
                if (item.Constellation > Constellation)
                {
                    if (item.MarkConstellation(Constellation) != Constellation)
                        error = true;
                }
                else if (item.Constellation != number)
                    error = true;
            }
            return Constellation;
        }

        #endregion
    }
}
