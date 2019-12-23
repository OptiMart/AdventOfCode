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
    /// Day 19: Tractor Beam
    /// </summary>
    public class Puzzle2019Day19 : PuzzleBase
    {
        #region Data
        private Computer cpu;
        private int[,] resultSet;
        private double kStart;
        private double kEnd;
        private Tuple<int, int> startPoint;
        private Tuple<int, int> endPoint;

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            cpu = new Computer(PuzzleInput);
            cpu.LoadDefaultInstructionSet();
            FindStartEnd();
        }

        protected override long SolvePuzzlePartOne()
        {
            int res = GetTriangle(endPoint) - GetTriangle(startPoint) + 1;
            Console.WriteLine($"{res}");
            return res;
        }

        protected override long SolvePuzzlePartTwo()
        {
            int target = 100;
            int start = (int)((target / (kStart - kEnd)) * (kEnd > 1 ? kEnd : 1));

            int x = 0;
            int y = 0;
            int lastX = 0;
            bool found = false;

            for (y = start; y < int.MaxValue; y++)
            {
                for (x = lastX; x < int.MaxValue; x++)
                {
                    if (GetMovement(x, y))
                    {
                        if (GetMovement(x + target - 1, y - target + 1))
                            found = true;

                        lastX = x;
                        break;
                    }
                }

                if (found)
                    break;
            }

            int res = x * 10000 + y - 99;
            Console.WriteLine($"{res}");
            return res;
        }

        private bool TargetFits(int x)
        {

            return false;
        }

        private void FindStartEnd()
        {
            bool start = false;

            for (int y = 49; y > 0; y--)
            {
                if (y == 49)
                {
                    for (int x = 0; x < 50; x++)
                    {
                        if (!start && GetMovement(x, y))
                        {
                            start = true;
                            startPoint = new Tuple<int, int>(x - 1, y);
                            kStart = (double)y / (x - 1);
                        }
                        else if (start && !GetMovement(x, y))
                        {
                            endPoint = new Tuple<int, int>(x - 1, y);
                            kEnd = (double)y / (x - 1);
                            return;
                        }
                    }

                }
                else
                {
                    int x = 49;
                    if (!start && GetMovement(x, y))
                    {
                        start = true;
                        startPoint = new Tuple<int, int>(x, y + 1);
                        kStart = (double)(y + 1) / x;
                    }
                    else if (start && !GetMovement(x, y))
                    {
                        endPoint = new Tuple<int, int>(x, y + 1);
                        kEnd = (double)(y + 1) / x;
                        return;
                    }
                }
            }
        }

        private bool GetMovement(int x, int y)
        {
            if (x < 0 || y < 0)
                return false;

            cpu.Initialize();
            cpu.PushInput(x);
            cpu.PushInput(y);
            cpu.StartExecution();

            return cpu.PopOutput() == 1;
        }

        private int GetTriangle(Tuple<int, int> point)
        {
            return (point.Item1 + 1) * (point.Item2 + 1) / 2;
        }

        #endregion
    }
}
