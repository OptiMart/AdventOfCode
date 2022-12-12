using AoC.Puzzles.Common.Extensions;
using AoC.Puzzles.Common.Shuffle;
using AoC.Puzzles.Puzzle.Base;

namespace AoC.Puzzles.Puzzle.Year2015
{
    /// <summary>
    /// Calorie Counting
    /// </summary>
    public class Puzzle2015Day24 : PuzzleBase
    {
        #region Data
        private List<int> weights = new List<int>();

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();

            foreach (var item in PuzzleInput.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(item, out int val))
                    weights.Add(val);
            }
        }

        protected override string SolvePuzzlePartOne()
        {
            long result = 0;

            int sum = weights.Sum();
            int cnt = weights.Count();
            int weight = sum / 3;

            int lbound;
            for (lbound = 1; lbound <= cnt; lbound++)
            {
                if (weights.OrderByDescending(x => x).Take(lbound).Sum() >= weight)
                    break;
            }

            int ubound = cnt - lbound * 2;

            for (int n = lbound; n <= ubound; n++)
            {
                var all = Shuffle.GetKCombs(weights, n);
                var b = all.Count();
                var test = all.Where(x => x.Sum() == weight);
                var a = test.Count();
                foreach (var items in test)
                {
                    Console.WriteLine(items.PrintList("; "));
                    Console.WriteLine(items.Sum());
                }
            }


            //foreach (var items in Shuffle.GetPermutations(weights.OrderByDescending(x => x), ubound))
            //foreach (var items in test)
            //    {
            //    for (int i = lbound; i <= ubound; i++)
            //    {
            //        if (items.Take(i).Sum() == weight)
            //        {
            //            result++;
            //        }
            //    }
            //}

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        private void MeinTest(IEnumerable<int> list, int amount)
        {

        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        #endregion

    }
}
