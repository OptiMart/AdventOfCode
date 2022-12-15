using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Base.Points
{
    public class BasePoint3D<TPointData> : BasePoint2D<TPointData>, IEquatable<BasePoint3D<TPointData>> where TPointData : IEquatable<TPointData>, new()
    {
        #region Data
        private const int _thisDim = 3;

        #endregion

        #region Constructor
        public BasePoint3D(TPointData item) : this(item, 0, 0, 0)
        { }

        public BasePoint3D(TPointData item, int x, int y, int z) : this(item, x, y, z, _thisDim)
        { }

        protected BasePoint3D(TPointData item, int x, int y, int z, uint dimension) : base(item, x, y, dimension)
        {
            Z = z;
        }

        #endregion

        #region Properties
        public long Z
        {
            get => GetCoord(_thisDim) ?? 0;
            set => SetCoord(_thisDim, value);
        }

        #endregion

        #region Methods
        public bool Equals(BasePoint3D<TPointData>? other)
        {
            if (other is null)
                return false;

            return Value.Equals(other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            return Equals(obj as BasePoint3D<TPointData>);
        }

        public override int GetHashCode()
        {
            return new Tuple<int, long>(base.GetHashCode(), Z).GetHashCode();
        }

        #endregion

    }
}
