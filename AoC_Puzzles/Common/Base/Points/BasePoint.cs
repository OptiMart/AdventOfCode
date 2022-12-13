using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Base.Points
{
    public abstract class BasePoint 
    {
        #region Data
        private readonly int[] _coords;

        #endregion

        #region Constructor
        protected BasePoint() : this(1)
        { }

        protected BasePoint(uint dimension)
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

        public long GetManhattanDistance(BasePoint point)
        {
            int minDim = Dimensions < point.Dimensions ? Dimensions : point.Dimensions;
            long result = 0;

            for (int i = 1; i <= minDim; i++)
                result += GetDimensionDistance(point, i);

            return result;
        }

        public double GetStraightLineDistance(BasePoint point)
        {
            int minDim = Dimensions < point.Dimensions ? Dimensions : point.Dimensions;
            double result = 0;

            for (int i = 1; i <= minDim; i++)
                result += Math.Pow(GetDimensionDistance(point, i), 2);

            return Math.Sqrt(result);
        }

        public int GetDimensionDistance(BasePoint point, int dimension)
        {
            return Math.Abs(GetCoord(dimension) ?? 0 - point.GetCoord(dimension) ?? 0);
        }

        #endregion
    }
}
