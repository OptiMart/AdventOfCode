using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Geometry
{
    public enum Orientation_ENUM
    {
        General = 0,
        Horizontal = 1,
        Vertical = 2,
    }

    [DebuggerDisplay("{Orientation} - ({StartPoint.PointX}/{StartPoint.PointY}) | ({EndPoint.PointX}/{EndPoint.PointY})")]
    public class Line
    {
        #region Constructor
        public Line() : this(new Point())
        { }

        public Line(Point end) : this(new Point(), end)
        { }

        public Line(Point start, Point end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public Line(string vector) : this(new Point(), vector)
        { }

        public Line(Point start, string vector)
        {
            StartPoint = start;
            EndPoint = new Point(start.PointX, start.PointY, vector);
        }

        #endregion

        #region Properties
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public int Length
        {
            get
            {
                return 0;
            }
        }

        public int X1 => StartPoint.PointX < EndPoint.PointX ? StartPoint.PointX : EndPoint.PointX;
        public int X2 => StartPoint.PointX >= EndPoint.PointX ? StartPoint.PointX : EndPoint.PointX;
        public int Y1 => StartPoint.PointX < EndPoint.PointY ? StartPoint.PointY : EndPoint.PointY;
        public int Y2 => StartPoint.PointX >= EndPoint.PointY ? StartPoint.PointY : EndPoint.PointY;

        public Orientation_ENUM Orientation
        {
            get
            {
                if (X1 == X2 && Y1 != Y2)
                    return Orientation_ENUM.Vertical;
                else if (Y1 == Y2 && X1 != X2)
                    return Orientation_ENUM.Horizontal;

                return Orientation_ENUM.General;
            }
        }
        #endregion

        #region Methods
        public bool HasIntersection(Line line)
        {
            if (this.Orientation == line.Orientation)
                return false;

            if (Orientation == Orientation_ENUM.Horizontal && X1 <= line.X1 && X2 >= line.X2 && Y1 >= line.Y1 && Y2 <= line.Y2)
                return true;

            if (Orientation == Orientation_ENUM.Vertical && line.X1 <= X1 && line.X2 >= X2 && line.Y1 >= Y1 && line.Y2 <= Y2)
                return true;

            return false;
        }

        public Point GetIntersection(Line line)
        {
            if (!HasIntersection(line))
                return null;

            if (Orientation == Orientation_ENUM.Horizontal)
                return new Point(line.X1, Y1);
            else if (Orientation == Orientation_ENUM.Vertical)
                return new Point(X1, line.Y1);

            return null;
        }

        #endregion
    }
}
