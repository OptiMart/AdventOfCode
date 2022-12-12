using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2022
{
    /// <summary>
    /// Rucksack Reorganization
    /// </summary>
    public class Puzzle2022Day03 : PuzzleBase
    {
        #region Data
        private List<string> items = new List<string>();
        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();

            items = LoadPuzzleItemsString("\n", true);
        }

        protected override string SolvePuzzlePartOne()
        {
            long result = 0;

            foreach (var pack in items)
            {
                result += CalcValue(pack);
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;

            for (int i = 0; i < items.Count; i += 3)
            {
                result += CalcTeamValue(items.GetRange(i, 3));
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        private int CalcValue(string pack)
        {
            string set1 = pack.Substring(0, pack.Length / 2);
            string set2 = pack.Substring(pack.Length / 2, pack.Length/ 2);

            foreach (var chr in set1)
            {
                if (set2.Contains(chr))
                    return GetItemPriority(chr);
            }
            return 0;
        }

        private int CalcTeamValue(List<string> input)
        {
            string reference = input.OrderBy(x => x.Count()).FirstOrDefault();

            foreach (var chr in reference)
            {
                bool chk = true;
                foreach (var item in input.Where(x => x != reference))
                {
                    if (!item.Contains(chr))
                    {
                        chk = false;
                        break;
                    }
                }

                if (chk)
                    return GetItemPriority(chr);
            }

            return 0;
        }

        private int GetItemPriority(char chr)
        {
            return chr >= 'a' ? chr - 'a' + 1 : chr - 'A' + 27;
        }
        #endregion

    }
}
