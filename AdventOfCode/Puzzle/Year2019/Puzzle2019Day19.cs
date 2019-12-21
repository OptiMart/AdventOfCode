using AoC.AdventOfCode.Common.IntCodeComputer;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Puzzle2019Day19 : PuzzleBase
    {
        #region Data
        private Computer cpu;
        private int[,] resultSet;

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            cpu = new Computer(PuzzleInput);
            cpu.LoadDefaultInstructionSet();
        }

        protected override long SolvePuzzlePartOne()
        {
            resultSet = new int[50, 50];

            int startX = 0;
            int endX = 0;
            int statX = 25;

            for (int x = 0; x < 50; x++)
            {
                cpu.Initialize();
                cpu.PushInput(x);
                cpu.PushInput(statX);
                cpu.StartExecution();

                int position = (int)cpu.PopOutput();

                if (startX == 0 && position == 1)
                    startX = x;

                if (startX > 0 && endX == 0 && position == 0)
                {
                    endX = x - 1;
                    break;
                }
            }

            int startY = 0;
            int endY = 0;
            int statY = 10;

            for (int y = 0; y < 50; y++)
            {
                cpu.Initialize();
                cpu.PushInput(statY);
                cpu.PushInput(y);
                cpu.StartExecution();

                int position = (int)cpu.PopOutput();

                if (startY == 0 && position == 1)
                    startY = y;

                if (startY == 1 && endY == 0 && position == 0)
                {
                    endY = y - 1;
                    break;
                }
            }

            int res = 0;
            foreach (var item in resultSet)
            {
                res += item;
            }

            Console.WriteLine($"{res}");
            return res;
        }

        protected override long SolvePuzzlePartTwo()
        {
            int res = 0;
            Console.WriteLine($"{res}");
            return res;
        }

        #endregion
    }
}
