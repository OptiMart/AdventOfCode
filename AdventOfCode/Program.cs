using AoC.AdventOfCode.Common;
using AoC.AdventOfCode.Puzzle.Base;
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
            SolveAllPuzzles();

            Console.ReadKey();
        }

        private static void SolveAllPuzzles()
        {
            List<PuzzleBase> puzzles = new List<PuzzleBase>();

            foreach (var item in ReflectiveEnumerator.FindDerivedTypes(Assembly.GetExecutingAssembly(), typeof(PuzzleBase)))
                puzzles.Add((PuzzleBase)Activator.CreateInstance(item));

            foreach (var day in puzzles.OrderBy(x => x.Day))
                day.SolvePuzzle();

        }
    }
}
