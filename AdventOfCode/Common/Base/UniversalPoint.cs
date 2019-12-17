using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Base
{
    public abstract class UniversalPoint
    {
        #region Data
        private int[] _coords;

        #endregion

        #region Constructor
        protected UniversalPoint() : this(1)
        { }

        protected UniversalPoint(int dimension)
        {
            if (dimension <= 0)
                throw new ArgumentException("Point dimension cannot be less or equals zero!");

            _coords = new int[dimension];
        }

        #endregion

        #region Properties
        public int Dimensions => _coords.Length;

        #endregion

        #region Methods
        public int? GetCoord(int dimension)
        {
            if (DimensionIsInRange(dimension))
                return _coords[dimension - 1];

            return null;
        }

        public void SetCoord(int dimension, int value)
        {
            if (DimensionIsInRange(dimension))
                _coords[dimension - 1] = value;
        }

        private bool DimensionIsInRange(int dimension)
        {
            if (dimension <= 0 || dimension > Dimensions)
                return false;

            return true;
        }

        public long GetManhattanDistance(UniversalPoint point)
        {
            int minDim = Dimensions < point.Dimensions ? Dimensions : point.Dimensions;
            long result = 0;

            for (int i = 1; i <= minDim; i++)
                result += GetDimensionDistance(point, i);

            return result;
        }

        public double GetStraightLineDistance(UniversalPoint point)
        {
            int minDim = Dimensions < point.Dimensions ? Dimensions : point.Dimensions;
            double result = 0;

            for (int i = 1; i <= minDim; i++)
                result += Math.Pow(GetDimensionDistance(point, i), 2);

            return Math.Sqrt(result);
        }

        public int GetDimensionDistance(UniversalPoint point, int dimension)
        {
            return Math.Abs(GetCoord(dimension) ?? 0 - point.GetCoord(dimension) ?? 0);
        }

        #endregion
    }
}
