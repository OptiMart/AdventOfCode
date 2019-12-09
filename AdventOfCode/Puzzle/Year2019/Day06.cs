using AoC.AdventOfCode.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Year2019
{
    public class Day06 : PuzzleBase
    {
        #region Data
        private OrbitMap.OrbitMap orbitMap;

        #endregion

        #region Constructor
        public Day06() : base(2019, 6)
        { }

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            orbitMap = new OrbitMap.OrbitMap();
            orbitMap.LoadOrbitalMap(PuzzleInput);
        }

        protected override long SolvePuzzlePartOne()
        {
            int res = orbitMap.CalcAllOrbits();
            Console.WriteLine($"{res}");
            return res;
        }

        protected override long SolvePuzzlePartTwo()
        {
            int res = orbitMap.CalcSantaDistance();
            Console.WriteLine($"{res}");
            return res;
        }

        #endregion
    }
}
