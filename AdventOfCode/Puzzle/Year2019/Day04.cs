using AoC.AdventOfCode.Base;
using AoC.IntcodeComputer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Year2019
{
    class Day04 : PuzzleBase
    {
        #region Data
        private int lbound = 0;
        private int ubound = 0;

        #endregion
        
        #region Constructor
        public Day04() : base(2019, 4)
        { }

        #endregion

        #region Methods
        public override void LoadAdditionalParameter(string[] args)
        {
            int.TryParse(args[0], out lbound);
            int.TryParse(args[1], out ubound);
        }

        protected override void DoPreparations()
        {
            LoadAdditionalParameter(new[] { "171309", "643603" });
        }

        protected override long SolvePuzzlePartOne()
        {
            int res = 0;

            for (int i = lbound; i <= ubound; i++)
            {
                if (IsSixDigits(i) && HasAdjacentSameInt(i) &&  NeverDecreses(i))
                    res++;
            }

            Console.WriteLine($"{res}");
            return res;

        }

        protected override long SolvePuzzlePartTwo()
        {
            int res = 0;

            for (int i = lbound; i <= ubound; i++)
            {
                if (IsSixDigits(i) && HasAdjacentSameInt(i) && NeverDecreses(i) && HasPairOfInt(i))
                    res++;
            }

            Console.WriteLine($"{res}");
            return res;
        }

        private bool IsSixDigits(int number)
        {
            return false;
        }

        private bool HasAdjacentSameInt(int number)
        {
            return false;
        }

        private bool NeverDecreses(int number)
        {
            return false;
        }

        private bool HasPairOfInt(int number)
        {
            return false;
        }

        #endregion
    }
}
