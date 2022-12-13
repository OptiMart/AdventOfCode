using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Base.Points
{
    public class BasePoint2D<TPointData> : BasePoint1D<TPointData>, IEquatable<BasePoint2D<TPointData>> where TPointData : IEquatable<TPointData>, new()
    {
        #region Data
        private const int _thisDim = 2;

        #endregion

        #region Constructor
        public BasePoint2D(TPointData item) : this(item, 0, 0)
        { }

        public BasePoint2D(TPointData item, int x, int y) : this(item, x, y, _thisDim)
        { }

        protected BasePoint2D(TPointData item, int x, int y, uint dimension) : base(item, x, dimension)
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

        #region Methods
        public bool Equals(BasePoint2D<TPointData>? other)
        {
            if (other is null)
                return false;

            return Value.Equals(other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            return Equals(obj as BasePoint2D<TPointData>);
        }

        public override int GetHashCode()
        {
            return new Tuple<int, int>(base.GetHashCode(), Y).GetHashCode();
        }

        #endregion

    }
}
