using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Base.Points
{
    public class BasePoint<TPointData> : BasePoint, IEquatable<BasePoint<TPointData>> where TPointData : IEquatable<TPointData>, new()
    {
        #region Constructor
        protected BasePoint(TPointData item) : this(item, 1)
        { }

        protected BasePoint(TPointData item, uint dimension) : base(dimension)
        {
            Value = item ?? new TPointData();
        }

        #endregion

        #region Properties
        public TPointData Value { get; set; }
        public Type Type => typeof(TPointData);

        #endregion

        #region Methods
        public bool Equals(BasePoint<TPointData>? other)
        {
            if (other is null)
                return false;

            return Value.Equals(other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            return Equals(obj as BasePoint<TPointData>);
        }

        public override int GetHashCode()
        {
            return new Tuple<int, TPointData>(base.GetHashCode(), Value).GetHashCode();
        }

        #endregion
    }
}
