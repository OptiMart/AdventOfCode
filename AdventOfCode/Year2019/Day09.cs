using AoC.AdventOfCode.Base;
using AoC.IntcodeComputer;
using AoC.SpaceImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Year2019
{
    public class Day09 : PuzzleBase
    {
        #region Data
        private Image image;

        #endregion
        
        #region Constructor
        public Day09() : base(2019, 9)
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
            var res = SolvePuzzleHelper(2);
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
