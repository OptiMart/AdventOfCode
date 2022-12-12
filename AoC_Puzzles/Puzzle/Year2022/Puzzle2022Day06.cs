using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2022
{
    /// <summary>
    /// Tuning Trouble
    /// </summary>
    public class Puzzle2022Day06 : PuzzleBase
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
            int len = 4;

            Queue<char> stack = new Queue<char>();

            for (int i = 0; i < PuzzleInput.Length; i++)
            {
                stack.Enqueue(PuzzleInput[i]);

                if (i >= len)
                {
                    stack.Dequeue();
                    if (stack.Distinct().Count() == len)
                    {
                        result = i + 1;
                        break;
                    }
                }
                
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;
            int len = 14;

            Queue<char> stack = new Queue<char>();

            for (int i = 0; i < PuzzleInput.Length; i++)
            {
                stack.Enqueue(PuzzleInput[i]);

                if (i >= len)
                {
                    stack.Dequeue();
                    if (stack.Distinct().Count() == len)
                    {
                        result = i + 1;
                        break;
                    }
                }

            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        #endregion

    }
}
