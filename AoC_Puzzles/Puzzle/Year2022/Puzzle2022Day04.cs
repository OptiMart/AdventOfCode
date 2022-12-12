using AoC.Puzzles.Common.Extensions;
using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2022
{
    /// <summary>
    /// Camp Cleanup
    /// </summary>
    public class Puzzle2022Day04 : PuzzleBase
    {
        #region Data

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();

        }

        protected override string SolvePuzzlePartOne()
        {
            long result = 0;

            foreach (var set in PuzzleInput.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                if (CheckPairsFull(set)) result++;

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        private bool CheckPairsFull(string set)
        {
            var ranges = GetRanges(set);

            return ranges.Item1.ListContainsAllItems(ranges.Item2) || ranges.Item2.ListContainsAllItems(ranges.Item1);
        }

        private Tuple<List<int>, List<int>> GetRanges(string input)
        {
            var start1 = int.Parse(input.Split(',')[0].Split('-')[0]);
            var end1 = int.Parse(input.Split(',')[0].Split('-')[1]);
            var start2 = int.Parse(input.Split(',')[1].Split('-')[0]);
            var end2 = int.Parse(input.Split(',')[1].Split('-')[1]);

            Tuple<List<int>, List<int>> result = new Tuple<List<int>, List<int>>(
                new List<int>(Enumerable.Range(start1, end1 - start1 + 1)),
                new List<int>(Enumerable.Range(start2, end2 - start2 + 1)));

            return result;
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;

            foreach (var set in PuzzleInput.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                if (CheckPairsAny(set)) result++;

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        private bool CheckPairsAny(string set)
        {
            var ranges = GetRanges(set);

            return ranges.Item1.ListContainsAnyItem(ranges.Item2);
        }

        #endregion

    }
}
