using AoC.AdventOfCode.Common.IntCodeComputer;
using AoC.AdventOfCode.Common.SpaceMap;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Day10 : PuzzleBase
    {
        #region Data
        private AsteroidMap map;
        #endregion

        #region Constructor
        public Day10() : base(2019, 10)
        { }

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            map = new AsteroidMap();
        }

        protected override long SolvePuzzlePartOne()
        {
            map.LoadAsteroids(PuzzleInput);
            var res = map.GetMaxDetectionValue();
            Console.WriteLine($"{res}");
            return res;
        }

        protected override long SolvePuzzlePartTwo()
        {
            var ast = map.GetBetAsteroid();
            var res = ast.PosX * 100 + ast.PosY;
            Console.WriteLine($"{res}");
            return res;
        }

        #endregion
    }
}
