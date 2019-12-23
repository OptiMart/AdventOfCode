using AoC.AdventOfCode.Common.IntCodeComputer;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    /// <summary>
    /// Springdroid Adventure
    /// </summary>
    public class Puzzle2019Day21 : PuzzleBase
    {
        #region Methods
        protected override long SolvePuzzlePartOne()
        {
            Computer cpu = new Computer(PuzzleInput);
            cpu.LoadDefaultInstructionSet();
            cpu.Initialize();

            StringBuilder input = new StringBuilder();
            input.Append("OR A T");
            input.Append((char)10);
            input.Append("AND B T");
            input.Append((char)10);
            input.Append("AND C T");
            input.Append((char)10);

            input.Append("NOT T T");
            input.Append((char)10);


            input.Append("OR D J");
            input.Append((char)10);

            input.Append("AND T J");
            input.Append((char)10);

            input.Append("WALK");
            input.Append((char)10);

            cpu.StartExecution();
            cpu.OutputStack.Clear();

            foreach (var item in input.ToString())
            {
                cpu.PushInput((int)item);
            }

            cpu.StartExecution();

            int res = 0;
            if (cpu.OutputStack.Count > 14)
            {
                do
                {
                    Console.Write((char)cpu.PopOutput());
                } while (cpu.OutputStack.Count > 0);
            }
            else
            {
                res = (int)cpu.OutputStack.Last();
            }

            Console.WriteLine($"{res}");
            return res;
        }

        protected override long SolvePuzzlePartTwo()
        {
            Computer cpu = new Computer(PuzzleInput);
            cpu.LoadDefaultInstructionSet();
            cpu.Initialize();

            StringBuilder input = new StringBuilder();
            input.Append("OR A T");
            input.Append((char)10);
            input.Append("AND B T");
            input.Append((char)10);
            input.Append("AND C T");
            input.Append((char)10);

            input.Append("NOT T T");
            input.Append((char)10);


            input.Append("OR D J");
            input.Append((char)10);

            input.Append("AND T J");
            input.Append((char)10);

            input.Append("RUN");
            input.Append((char)10);

            cpu.StartExecution();
            cpu.OutputStack.Clear();

            foreach (var item in input.ToString())
            {
                cpu.PushInput((int)item);
            }

            cpu.StartExecution();

            int res = 0;
            if (cpu.OutputStack.Count > 14)
            {
                do
                {
                    Console.Write((char)cpu.PopOutput());
                } while (cpu.OutputStack.Count > 0);
            }
            else
            {
                res = (int)cpu.OutputStack.Last();
            }

            Console.WriteLine($"{res}");
            return res;
        }

        #endregion
    }
}
