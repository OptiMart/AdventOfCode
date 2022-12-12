using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2021
{
    /// <summary>
    /// Calorie Counting
    /// </summary>
    public class Puzzle2021Day01 : PuzzleBase
    {
        #region Data
        private List<long> elves = new List<long>();

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();

            //long actVal = -1;
            //long cntInc = 0;

            //foreach (var item in PuzzleInput.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
            //{
            //    if (int.TryParse(item, out int val))
            //    {
            //        if (actVal < 0)
            //            actVal = val;

            //        if (actVal > val)
            //            cntInc++;
            //    }
            //}
        }

        protected override string SolvePuzzlePartOne()
        {
            long result = 0;
            long actVal = -1;

            foreach (var item in PuzzleInput.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(item, out int val))
                {
                    if (actVal < val && actVal > 0)
                        result++;

                    actVal = val;
                }
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = elves.OrderByDescending(x => x).ToList().Take(3).Sum();

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        #endregion

    }
}
