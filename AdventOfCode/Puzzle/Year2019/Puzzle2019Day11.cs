using AoC.AdventOfCode.Common.PaintingRobot;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Puzzle2019Day11 : PuzzleBase
    {
        #region Data
        private Robot robot;
        #endregion

        #region Constructor
        public Puzzle2019Day11() : base(2019, 11)
        { }

        #endregion

        #region Methods
        protected override long SolvePuzzlePartOne()
        {
            robot = new Robot();
            robot.LoadProgram(PuzzleInput);

            robot.StartPainting();
            var res = robot.PaintArea.CountMarkedSpots();
            Console.WriteLine($"{res}");
            return res;
        }

        protected override long SolvePuzzlePartTwo()
        {
            robot = new Robot();
            robot.LoadProgram(PuzzleInput);

            robot.StartPainting(1);
            var res = robot.PaintArea.ToString().Replace('.', ' ');
            Console.WriteLine($"{res}");
            return 0;
        }

        #endregion
    }
}
