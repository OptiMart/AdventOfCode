using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Base
{
    public class BasePoint2D : BasePoint1D
    {
        #region Data
        private const int _thisDim = 2;

        #endregion
        
        #region Constructor
        public BasePoint2D() : this(0, 0)
        { }

        public BasePoint2D(int x, int y) : this(x, y, _thisDim)
        { }

        protected BasePoint2D(int x, int y, int dimension) : base(x, dimension)
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
