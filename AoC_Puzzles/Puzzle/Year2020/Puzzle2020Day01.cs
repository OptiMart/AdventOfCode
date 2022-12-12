using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Puzzle2020Day01 : PuzzleBase
    {
        #region Methods
        protected override string SolvePuzzlePartOne()
        {
            long result = 0;

            string[] values = PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var itema in values)
            {
                if (int.TryParse(itema, out int valuea))
                {
                    foreach (var itemb in values)
                    {
                        if (int.TryParse(itemb, out int valueb) && valuea + valueb == 2020)
                        {
                            result = valuea * valueb;
                            break;
                        }
                    }
                }

                if (result != 0)
                {
                    break;
                }
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;

            string[] values = PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var itema in values)
            {
                if (int.TryParse(itema, out int valuea))
                {
                    foreach (var itemb in values)
                    {
                        if (int.TryParse(itemb, out int valueb) && valuea + valueb < 2020)
                        {
                            foreach (var itemc in values)
                            {
                                if (int.TryParse(itemc, out int valuec) && valuea + valueb + valuec == 2020)
                                {
                                    result = valuea * valueb * valuec;
                                    break;
                                }
                            }
                        }

                        if (result != 0)
                            break;

                    }
                }

                if (result != 0)
                    break;
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        #endregion

    }
}
