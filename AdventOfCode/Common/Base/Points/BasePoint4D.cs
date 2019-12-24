using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Base.Points
{
    public class BasePoint4D<TPointData> : BasePoint3D<TPointData>
    {
        #region Data
        private const int _thisDim = 4;

        #endregion

        #region Constructor
        public BasePoint4D() : this(default)
        { }

        public BasePoint4D(TPointData item) : this(item, 0, 0, 0, 0)
        { }

        public BasePoint4D(TPointData item, int x, int y, int z, int t) : this(item, x, y, z, t, _thisDim)
        { }

        protected BasePoint4D(TPointData item, int x, int y, int z, int t, int dimension) : base(item, x, y, z, dimension)
        {
            T = t;
        }

        #endregion

        #region Properties
        public int T
        {
            get => GetCoord(_thisDim) ?? 0;
            set => SetCoord(_thisDim, value);
        }

        #endregion
    }
}
