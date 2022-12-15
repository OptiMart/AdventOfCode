using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Base.Points
{
    public class BasePoint1D<TPointData> : BasePoint<TPointData>, IEquatable<BasePoint1D<TPointData>> where TPointData : IEquatable<TPointData>, new()
    {
        #region Data
        private const int _thisDim = 1;

        #endregion

        #region Constructor
        public BasePoint1D(TPointData item) : this(item, 0)
        { }

        public BasePoint1D(TPointData item, int x) : this(item, x, _thisDim)
        { }

        protected BasePoint1D(TPointData item, int x, uint dimension) : base(item, dimension)
        {
            X = x;
        }

        #endregion

        #region Properties
        public long X
        {
            get => GetCoord(_thisDim) ?? 0;
            set => SetCoord(_thisDim, value);
        }

        #endregion

        #region Methods
        public bool Equals(BasePoint1D<TPointData>? other)
        {
            if (other is null)
                return false;

            return Value.Equals(other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            return Equals(obj as BasePoint1D<TPointData>);
        }

        public override int GetHashCode()
        {
            return new Tuple<int, long>(base.GetHashCode(), X).GetHashCode();
        }

        #endregion

    }
}
