using AoC.AdventOfCode.Base;
using AoC.AdventOfCode.Year2019;
using AoC.IntcodeComputer;
using AoC.IntcodeComputer.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.AdventOfCode
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<PuzzleBase> puzzles = new List<PuzzleBase>()
            {
                new Day01(),
                new Day02(),
                new Day03(),
                new Day04(),
                new Day05(),
                new Day06(),
                new Day07(),
                new Day08(),
            };

            foreach (var day in puzzles)
            {
                day.SolvePuzzle();
            }

            Console.ReadKey();
        }
    }
}
