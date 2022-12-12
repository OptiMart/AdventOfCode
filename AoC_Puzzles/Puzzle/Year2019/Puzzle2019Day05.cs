using AoC.Puzzles.Common.IntCodeComputer;
using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2019
{
    public class Puzzle2019Day05 : PuzzleBase
    {
        #region Methods
        protected override string SolvePuzzlePartOne()
        {
            var res = SolvePuzzleHelper(1);
            //Console.WriteLine($"{res}");
            return res.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            var res = SolvePuzzleHelper(5);
            //Console.WriteLine($"{res}");
            return res.ToString();
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
