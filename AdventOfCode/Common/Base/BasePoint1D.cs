using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Base
{
    public class BasePoint1D : UniversalPoint
    {
        #region Data
        private const int _thisDim = 1;

        #endregion

        #region Constructor
        public BasePoint1D() : this(0)
        { }

        public BasePoint1D(int x) : this(x, _thisDim)
        { }

        protected BasePoint1D(int x, int dimension) : base(dimension)
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
