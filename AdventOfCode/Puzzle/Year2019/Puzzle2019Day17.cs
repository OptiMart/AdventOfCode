using AoC.AdventOfCode.Common.IntCodeComputer;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Puzzle2019Day17 : PuzzleBase
    {
        #region Data
        private Computer cpu;
        private List<long> output = new List<long>();

        #endregion

        #region Constructor
        public Puzzle2019Day17() : base(2019, 17)
        { }

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            cpu = new Computer(PuzzleInput);
            cpu.LoadDefaultInstructionSet();
        }

        protected override long SolvePuzzlePartOne()
        {
            var opCode = cpu.StartExecution();

            WriteOutput();

            int res = 0;
            Console.WriteLine($"{res}");
            return res;
        }

        protected override long SolvePuzzlePartTwo()
        {
            cpu.Initialize();
            cpu.Memory.SaveAtAddress(0, 2);

            StringBuilder input = new StringBuilder();
            input.Append("A,B,A,C,A,B,A,C,B,C");
            input.Append((char)10);
            input.Append("R,4,L,12,L,8,R,4");
            input.Append((char)10);
            input.Append("L,8,R,10,R,10,R,6");
            input.Append((char)10);
            input.Append("R,4,R,10,L,12");
            input.Append((char)10);
            input.Append("n");
            input.Append((char)10);

            foreach (var item in input.ToString())
            {
                cpu.PushInput((int)item);
            }

            var opCode = cpu.StartExecution();

            WriteOutput();

            long res = output.First();
            Console.WriteLine($"{res}");
            return res;
        }

        private void WriteOutput()
        {
            do
            {
                var symb = cpu.PopOutput();

                if (symb > 255)
                    output.Add((long)symb);
                else
                    Console.Write((char)symb);
            } while (cpu.OutputStack.Count > 0);
        }

        #endregion
    }
}
