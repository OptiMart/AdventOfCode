using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.SpaceMap
{
    [DebuggerDisplay("({PosX}/{PosY}) - {DetectedObjects}")]
    public class Asteroid : IComparer
    {
        #region Constructor
        public Asteroid() : this(0, 0)
        {

        }

        public Asteroid(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        #endregion

        #region Properties
        public int PosX { get; set; }
        public int PosY { get; set; }
        public List<Asteroid> DetectedObjects { get; set; } = new List<Asteroid>();

        #endregion

        #region Methods
        public int GetDistanceX(Asteroid target)
        {
            return target.PosX - PosX;
        }

        public int GetDistanceY(Asteroid target)
        {
            return target.PosY - PosY;
        }

        public double GetAngle(Asteroid target)
        {
            return GetDistanceX(target) >= 0 ? Math.PI - Math.Acos(GetDistanceY(target) / GetDistance(target)) : Math.PI + Math.Acos(GetDistanceY(target) / GetDistance(target));
        }

        public double? GetSlope(Asteroid target)
        {
            return GetDistanceX(target) == 0 ? (double?)null : (double)GetDistanceY(target) / GetDistanceX(target);
        }

        public double GetDistance(Asteroid target)
        {
            return Math.Sqrt(Math.Pow(GetDistanceX(target), 2) + Math.Pow(GetDistanceY(target), 2));
        }

        public bool BlocksLineOfSight(Asteroid target, Asteroid blockObject)
        {
            // Check Quadrant
            if (!SameSign(GetDistanceX(target), GetDistanceX(blockObject)) || !SameSign(GetDistanceY(target), GetDistanceY(blockObject)))
                return false;

            if (GetDistance(blockObject) > GetDistance(target))
                return false;

            if (GetSlope(target) == GetSlope(blockObject))
                return true;

            return false;
        }

        private bool SameSign(int num1, int num2)
        {
            return num1 >= 0 && num2 >= 0 || num1 < 0 && num2 < 0;
        }

        public void SortDetectedObjects()
        {
            //DetectedObjects.Sort();
        }

        public int Compare(object x, object y)
        {
            return 0;
        }



        #endregion
    }
}
