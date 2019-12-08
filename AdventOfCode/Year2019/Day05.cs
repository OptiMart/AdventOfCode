using AoC.AdventOfCode.Base;
using AoC.IntcodeComputer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Year2019
{
    public class Day05 : PuzzleBase
    {
        #region Constructor
        public Day05() : base(2019, 5)
        { }

        #endregion

        #region Methods
        public override int SolvePuzzle(int part = 0)
        {
            return part == 2 ? SolvePuzzlePart2() : SolvePuzzlePart1();
        }

        private int SolvePuzzlePart1()
        {
            LoadPuzzleInputFromFile(@"D:\AdventofCode\Input_Day5_1.txt");
            Computer cpu = new Computer(PuzzleInput);

            cpu.LoadDefaultInstructionSet();
            cpu.Stack.Push(1);

            cpu.StartExecution();

            int res = cpu.Stack.Pop();
            return res;
        }

        private int SolvePuzzlePart2()
        {
            LoadPuzzleInputFromFile(@"D:\AdventofCode\Input_Day5_1.txt");
            Computer cpu = new Computer(PuzzleInput);

            cpu.LoadDefaultInstructionSet();
            cpu.Stack.Push(5);

            cpu.StartExecution();

            int res = cpu.Stack.Pop();
            return res;
        }
        #endregion

    }
}
