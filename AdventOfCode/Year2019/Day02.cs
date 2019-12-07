using AoC.AdventOfCode.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Year2019
{
    public class Day02 : PuzzleBase
    {
        #region Constructor
        public Day02() : base(2019, 2)
        { }

        #endregion

        #region Methods
        public override int SolvePuzzle(int part = 0)
        {
            if (part == 1)
                return SolvePuzzlePart1();
            else if (part == 2)
                return SolvePuzzlePart2();

            return 0;
        }

        public override void LoadAdditionalParameter(string[] args)
        {
            base.LoadAdditionalParameter(args);
        }

        private int SolvePuzzlePart1()
        {
            return 0;
        }

        private int SolvePuzzlePart2()
        {
            return 0;
        }

        #endregion
    }
}
