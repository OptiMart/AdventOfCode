using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Base
{
    public class BasePoint3D : BasePoint2D
    {
        #region Data
        private const int _thisDim = 3;

        #endregion
        
        #region Constructor
        public BasePoint3D() : this(0, 0, 0)
        { }

        public BasePoint3D(int x, int y, int z) : this(x, y, z, _thisDim)
        { }

        protected BasePoint3D(int x, int y, int z, int dimension) : base(x, y, dimension)
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
