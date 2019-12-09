﻿using AoC.AdventOfCode.Base;
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
        protected override int SolvePuzzlePartOne()
        {
            int res = SolvePuzzleHelper(1);
            Console.WriteLine($"{res}");
            return res;
        }

        protected override int SolvePuzzlePartTwo()
        {
            int res = SolvePuzzleHelper(5);
            Console.WriteLine($"{res}");
            return res;
        }

        private int SolvePuzzleHelper(int input)
        {
            Computer cpu = new Computer(PuzzleInput);

            cpu.LoadDefaultInstructionSet();
            cpu.InputStack.AddFirst(input);

            cpu.StartExecution();

            int res = cpu.OutputStack.Last();
            return res;
        }

        #endregion
    }
}
