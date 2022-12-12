using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2022
{
    /// <summary>
    /// Cathode-Ray Tube
    /// </summary>
    public class Puzzle2022Day10 : PuzzleBase
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
            long register = 1;
            long cycle = 0;

            foreach (var item in PuzzleItems)
            {
                if (item == "noop")
                {
                    cycle++;
                    
                    if (cycle % 40 == 20)
                        result += cycle * register;

                }
                else if (item.Split(' ')[0] == "addx" && int.TryParse(item.Split(' ')[1], out int val))
                {
                    cycle++;
                    if (cycle % 40 == 20)
                        result += cycle * register;

                    cycle++;
                    if (cycle % 40 == 20)
                        result += cycle * register;

                    register += val;
                }
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;

            int register = 1;
            int cycle = 0;

            foreach (var item in PuzzleItems)
            {
                if (item == "noop")
                {
                    PrintCRT(cycle++, register);
                }
                else if (item.Split(' ')[0] == "addx" && int.TryParse(item.Split(' ')[1], out int val))
                {
                    PrintCRT(cycle++, register);
                    PrintCRT(cycle++, register);
                    register += val;
                }
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected void PrintCRT(int cycle, int register)
        {
            if (cycle % 40 >= register - 1 && cycle % 40 <= register +1)
                Console.Write("#");
            else
                Console.Write(".");

            if (cycle % 40 == 39)
            {
                Console.WriteLine();
            }
        }

        #endregion

    }
}
