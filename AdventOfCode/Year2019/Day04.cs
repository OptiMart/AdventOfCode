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
        #region Constructor
        public Day04() : base(2019, 4)
        { }

        #endregion

        #region Methods
        public override int SolvePuzzle(int part = 0)
        {
            return SolvePuzzlePart1();
        }

        private int SolvePuzzlePart1()
        {
            LoadPuzzleInputFromFile(@"D:\AdventofCode\Input_Day4_1.txt");
            Computer cpu = new Computer(PuzzleInput);

            cpu.LoadDefaultInstructionSet();
            cpu.Stack.Push(1);

            cpu.StartExecution();

            int res = cpu.Stack.Pop();
            return res;
        }

        #endregion
    }
}
