using AoC.AdventOfCode.Common.IntCodeComputer;
using AoC.AdventOfCode.Common.RepairDroid;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Puzzle2019Day15 : PuzzleBase
    {
        #region Data
        private RepairDroid droid;

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            droid = new RepairDroid(PuzzleInput);
            droid.CheckMap();
        }

        protected override string SolvePuzzlePartOne()
        {
            int res = droid.FindShortestWay();            
            Console.WriteLine($"{res}");
            return res.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            int res = droid.GetFarthestOxygenDistance();
            Console.WriteLine($"{res}");
            return res.ToString();
        }

        #endregion
    }
}
