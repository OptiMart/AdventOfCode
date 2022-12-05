using AoC.AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Base
{
    public static class PuzzleHelper
    {
        public static List<PuzzleBase> GetPuzzles(int year = 0, int day = 0)
        {
            List<PuzzleBase> puzzles = new List<PuzzleBase>();

            foreach (var item in ReflectiveEnumerator.FindDerivedTypes(Assembly.GetExecutingAssembly(), typeof(PuzzleBase)))
            {
                if ((year == 0 || year == PuzzleBase.GetYear(item)) && (day == 0 || day == PuzzleBase.GetDay(item)))
                    puzzles.Add((PuzzleBase)Activator.CreateInstance(item));
            }

            return puzzles;
        }

        public static PuzzleBase GetPuzzle(int year, int day)
        {
            return GetPuzzles(year, day).OrderBy(x => x.Year * 100 + x.Day).FirstOrDefault();
        }

    }
}
