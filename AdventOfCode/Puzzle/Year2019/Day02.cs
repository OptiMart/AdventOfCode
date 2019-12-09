using AoC.AdventOfCode.Common.IntCodeComputer;
using AoC.AdventOfCode.Common.IntCodeComputer.Instructions;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Day02 : PuzzleBase
    {
        #region Constructor
        public Day02() : base(2019, 2)
        { }

        #endregion

        #region Methods
        protected override long SolvePuzzlePartOne()
        {
            long res = GetCpuResult(12, 2);
            Console.WriteLine($"{res}");
            return res;
        }

        protected override long SolvePuzzlePartTwo()
        {
            int target = 19690720;
            int pos1 = 0;
            int pos2 = 0;

            for (int i = 0; i <= 99; i++)
            {
                for (int n = 0; n <= 99; n++)
                {
                    var val = GetCpuResult(i, n);

                    if (val == target)
                    {
                        pos1 = i;
                        pos2 = n;
                    }
                }
            }

            int res = pos1 * 100 + pos2;
            Console.WriteLine($"{res}");
            return res;
        }

        private long GetCpuResult(int pos1, int pos2)
        {
            Computer cpu = new Computer(PuzzleInput);
            cpu.LoadInstruction(new OpAddition());
            cpu.LoadInstruction(new OpMultiplication());
            cpu.LoadInstruction(new OpTermination());
            cpu.Memory.SaveAtAddress(1, pos1);
            cpu.Memory.SaveAtAddress(2, pos2);

            cpu.StartExecution();

            return cpu.Memory.GetFromAddress(0);
        }

        #endregion
    }
}
