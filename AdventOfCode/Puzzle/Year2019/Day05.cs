using AoC.AdventOfCode.Common.IntCodeComputer;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Day05 : PuzzleBase
    {
        #region Constructor
        public Day05() : base(2019, 5)
        { }

        #endregion

        #region Methods
        protected override long SolvePuzzlePartOne()
        {
            var res = SolvePuzzleHelper(1);
            Console.WriteLine($"{res}");
            return res;
        }

        protected override long SolvePuzzlePartTwo()
        {
            var res = SolvePuzzleHelper(5);
            Console.WriteLine($"{res}");
            return res;
        }

        private long SolvePuzzleHelper(int input)
        {
            Computer cpu = new Computer(PuzzleInput);

            cpu.LoadDefaultInstructionSet();
            cpu.InputStack.AddFirst(input);

            cpu.StartExecution();

            var res = cpu.OutputStack.Last();
            return res;
        }

        #endregion
    }
}
