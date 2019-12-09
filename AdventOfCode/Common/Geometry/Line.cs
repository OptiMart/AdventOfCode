using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Geometry
{

    [DebuggerDisplay("{Orientation} - ({StartPoint.PointX}/{StartPoint.PointY}) | ({EndPoint.PointX}/{EndPoint.PointY})")]
    public class Line
    {
        #region Data
        private int _prevDistance = 0;

        #endregion
        #region Constructor
        public Line() : this(new Point())
        { }

        public Line(Point end) : this(new Point(), end)
        { }

        public Line(Point start, Point end, int distance = 0)
        {
            StartPoint = start;
            EndPoint = end;
            PrevDistance = distance;
        }

        public Line(string vector, int distance = 0) : this(new Point(), vector, distance)
        { }

        public Line(Point start, string vector, int distance = 0)
        {
            StartPoint = start;
            EndPoint = new Point(start.PointX, start.PointY, vector);
            PrevDistance = distance;
        }

        #endregion

        #region Properties
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public int X1 => StartPoint.PointX < EndPoint.PointX ? StartPoint.PointX : EndPoint.PointX;
        public int X2 => StartPoint.PointX >= EndPoint.PointX ? StartPoint.PointX : EndPoint.PointX;
        public int Y1 => StartPoint.PointY < EndPoint.PointY ? StartPoint.PointY : EndPoint.PointY;
        public int Y2 => StartPoint.PointY >= EndPoint.PointY ? StartPoint.PointY : EndPoint.PointY;
        public int Length => X2 - X1 + Y2 - Y1;
        public int PrevDistance
        {
            get => _prevDistance;
            private set => _prevDistance = Math.Abs(value);
        }
        public int TotalDistance => PrevDistance + Length;

        public EnumOrientation Orientation
        {
            get
            {
                if (X1 == X2 && Y1 != Y2)
                    return EnumOrientation.Vertical;
                else if (Y1 == Y2 && X1 != X2)
                    return EnumOrientation.Horizontal;

                return EnumOrientation.General;
            }
        }
        #endregion

        #region Methods
        public bool HasIntersection(Line line)
        {
            if (this.Orientation == line.Orientation)
                return false;

            if (Orientation == EnumOrientation.Horizontal && X1 <= line.X1 && X2 >= line.X2 && Y1 >= line.Y1 && Y2 <= line.Y2)
                return true;

            if (Orientation == EnumOrientation.Vertical && line.X1 <= X1 && line.X2 >= X2 && line.Y1 >= Y1 && line.Y2 <= Y2)
                return true;

            return false;
        }

        public Tuple<Point, int> GetIntersection(Line line)
        {
            if (!HasIntersection(line))
                return null;

            Point point;

            if (Orientation == EnumOrientation.Horizontal)
                point = new Point(line.X1, Y1);
            else if (Orientation == EnumOrientation.Vertical)
                point = new Point(X1, line.Y1);
            else
                return null;

            Tuple<Point, int> intersection = new Tuple<Point, int>(point, GetDistanceToPoint(point) + line.GetDistanceToPoint(point));
            return intersection;
        }

        public int GetDistanceToPoint(Point point)
        {
            if (PointOnLine(point))
                return PrevDistance + Math.Abs(StartPoint.PointX - point.PointX) + Math.Abs(StartPoint.PointY - point.PointY);

            return 0;
        }

        public bool PointOnLine(Point point)
        {
            if (X1 == point.PointX && X2 == point.PointX && Y1 <= point.PointY && Y2 >= point.PointY)
                return true;
            else if (Y1 == point.PointY && Y2 == point.PointY && X1 <= point.PointX && X2 >= point.PointX)
                return true;

            return false;
        }

        #endregion
    }
}
