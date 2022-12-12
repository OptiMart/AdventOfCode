using AoC.Puzzles.Common.IntCodeComputer;
using AoC.Puzzles.Common.SpaceMap;
using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2019
{
    public class Puzzle2019Day10 : PuzzleBase
    {
        #region Data
        private AsteroidMap map;
        
        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            map = new AsteroidMap();
        }

        protected override string SolvePuzzlePartOne()
        {
            map.LoadAsteroids(PuzzleInput);
            var res = map.GetMaxDetectionValue();
            Console.WriteLine($"{res}");
            return res.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            var ast = map.GetBetAsteroid();
            var res = ast.PosX * 100 + ast.PosY;
            Console.WriteLine($"{res}");
            return res.ToString();
        }

        #endregion
    }
}
