using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Geometry
{
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

        #endregion

        #region Methods
        public bool HasIntersection(Line line)
        {
            return true;
        }
        #endregion
    }
}
