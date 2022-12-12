using AoC.Puzzles.Common.SpaceMap;
using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2019
{
    public class Puzzle2019Day06 : PuzzleBase
    {
        #region Data
        private OrbitMap orbitMap;

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            orbitMap = new OrbitMap();
            orbitMap.LoadOrbitalMap(PuzzleInput);
        }

        protected override string SolvePuzzlePartOne()
        {
            int res = orbitMap.CalcAllOrbits();
            //Console.WriteLine($"{res}");
            return res.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            int res = orbitMap.CalcSantaDistance();
            //Console.WriteLine($"{res}");
            return res.ToString();
        }

        #endregion
    }
}
