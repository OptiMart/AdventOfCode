using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Base.Points
{
    public class BasePoint1D<TPointData> : BasePoint<TPointData>
    {
        #region Data
        private const int _thisDim = 1;

        #endregion

        #region Constructor
        public BasePoint1D() : this(default)
        { }

        public BasePoint1D(TPointData item) : this (item, 0)
        { }

        public BasePoint1D(TPointData item, int x) : this(item, x, _thisDim)
        { }

        protected BasePoint1D(TPointData item, int x, int dimension) : base(item, dimension)
        {
            X = x;
        }

        #endregion

        #region Properties
        public int X
        {
            get => GetCoord(_thisDim) ?? 0;
            set => SetCoord(_thisDim, value);
        }

        #endregion
    }
}
