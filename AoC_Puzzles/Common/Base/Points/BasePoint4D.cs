using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Base.Points
{
    public class BasePoint4D<TPointData> : BasePoint3D<TPointData>, IEquatable<BasePoint4D<TPointData>> where TPointData : IEquatable<TPointData>, new()
    {
        #region Data
        private const int _thisDim = 4;

        #endregion

        #region Constructor
        public BasePoint4D(TPointData item) : this(item, 0, 0, 0, 0)
        { }

        public BasePoint4D(TPointData item, int x, int y, int z, int t) : this(item, x, y, z, t, _thisDim)
        { }

        protected BasePoint4D(TPointData item, int x, int y, int z, int t, uint dimension) : base(item, x, y, z, dimension)
        {
            T = t;
        }

        #endregion

        #region Properties
        public long T
        {
            get => GetCoord(_thisDim) ?? 0;
            set => SetCoord(_thisDim, value);
        }

        #endregion

        #region Methods
        public bool Equals(BasePoint4D<TPointData>? other)
        {
            if (other is null)
                return false;

            return Value.Equals(other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            return Equals(obj as BasePoint4D<TPointData>);
        }

        public override int GetHashCode()
        {
            return new Tuple<int, long>(base.GetHashCode(), T).GetHashCode();
        }

        #endregion

    }
}
