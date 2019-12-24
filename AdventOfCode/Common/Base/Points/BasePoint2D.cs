using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Base.Points
{
    public class BasePoint2D<TPointData> : BasePoint1D<TPointData>
    {
        #region Data
        private const int _thisDim = 2;

        #endregion

        #region Constructor
        public BasePoint2D() : this(default)
        { }

        public BasePoint2D(TPointData item) : this(item, 0, 0)
        { }

        public BasePoint2D(TPointData item, int x, int y) : this(item, x, y, _thisDim)
        { }

        protected BasePoint2D(TPointData item, int x, int y, int dimension) : base(item, x, dimension)
        {
            Y = y;
        }

        #endregion

        #region Properties
        public int Y
        {
            get => GetCoord(_thisDim) ?? 0;
            set => SetCoord(_thisDim, value);
        }

        #endregion
    }
}
