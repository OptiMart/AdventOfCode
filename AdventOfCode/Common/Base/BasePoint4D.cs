using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Base
{
    public class BasePoint4D : BasePoint3D
    {
        #region Data
        private const int _thisDim = 4;

        #endregion
        
        #region Constructor
        public BasePoint4D() : this(0, 0, 0, 0)
        { }

        public BasePoint4D(int x, int y, int z, int t) : this(x, y, z, t, _thisDim)
        { }

        protected BasePoint4D(int x, int y, int z, int t, int dimension) : base(x, y, z, dimension)
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
