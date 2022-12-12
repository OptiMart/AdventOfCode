using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Base.Points
{
    public class BasePoint3D<TPointData> : BasePoint2D<TPointData>
    {
        #region Data
        private const int _thisDim = 3;

        #endregion

        #region Constructor
        public BasePoint3D() : this(default)
        { }

        public BasePoint3D(TPointData item) : this(item, 0, 0, 0)
        { }

        public BasePoint3D(TPointData item, int x, int y, int z) : this(item, x, y, z, _thisDim)
        { }

        protected BasePoint3D(TPointData item, int x, int y, int z, int dimension) : base(item, x, y, dimension)
        {
            Z = z;
        }

        #endregion

        #region Properties
        public int Z
        {
            get => GetCoord(_thisDim) ?? 0;
            set => SetCoord(_thisDim, value);
        }

        #endregion
    }
}
