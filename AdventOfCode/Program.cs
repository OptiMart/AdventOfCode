using AoC.AdventOfCode.Common;
using AoC.AdventOfCode.Puzzle.Base;
using AoC.AdventOfCode.Puzzle.Year2018;
using AoC.AdventOfCode.Puzzle.Year2019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.AdventOfCode
{
    static class Program
    {
        static void Main(string[] args)
        {
            int[] start = new int[] { 0, 0, 0 };

            for (int i = 0; i < args.Length; i++)
                int.TryParse(args[i], out start[i]);

            start[0] = 2019;
            start[1] = 1;
            start[2] = 0;

            try
            {
                SolveAllPuzzles(start[0], start[1], start[2]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler");
            }

            Console.ReadKey();
        }

        private static void SolveAllPuzzles(int year = 0, int day = 0, int part = 0)
        {
            var puzzles = PuzzleBase.GetPuzzles(year, day);

            foreach (var puzzle in puzzles.OrderBy(x => x.Year * 100 + x.Day))
                puzzle.SolvePuzzle(part);

        }
    }
}
