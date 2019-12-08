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
        #region Constructor
        public Day06() : base(2019, 6)
        { }

        #endregion

        #region Methods
        public override int SolvePuzzle(int part = 0)
        {
            OrbitMap.Map orbitMap = new OrbitMap.Map();
            orbitMap.LoadOrbitalMap(PuzzleInput);

            return part == 2 ? orbitMap.CalcSantaDistance() : orbitMap.CalcAllOrbits();
        }

        #endregion
    }
}
