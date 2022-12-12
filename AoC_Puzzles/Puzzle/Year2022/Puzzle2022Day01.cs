using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2022
{
    /// <summary>
    /// Calorie Counting
    /// </summary>
    public class Puzzle2022Day01 : PuzzleBase
    {
        #region Data
        private List<long> elves = new List<long>();

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();

            long aktCal = 0;
            long elvNum = 0;

            foreach (var item in PuzzleInput.Split(new[] { "\n" }, StringSplitOptions.None).Append(""))
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    if (elvNum > 0 && aktCal > 0)
                        elves.Add(aktCal);

                    aktCal = 0;
                }
                else if (int.TryParse(item, out int val))
                {
                    if (aktCal == 0)
                        elvNum++;

                    aktCal += val;
                }
            }
        }

        protected override string SolvePuzzlePartOne()
        {
            long result = elves.Max();

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
