using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Base.Points
{
    public class BasePoint<TPointData> : BasePoint
    {
        #region Constructor
        protected BasePoint() : this(default)
        { }

        protected BasePoint(TPointData item) : this(item, 1)
        { }

        protected BasePoint(TPointData item, int dimension) : base(dimension)
        {
            Value = item;
            Vector4 vector4 = new Vector4();
        }

        #endregion

        #region Properties
        public TPointData Value { get; set; }
        public Type Type => typeof(TPointData);

        
        #endregion
    }
}
