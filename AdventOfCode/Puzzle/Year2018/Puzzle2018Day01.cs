using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2018
{
    public class Puzzle2018Day01 : PuzzleBase
    {
        #region Constructor

        #endregion

        #region Methods
        protected override long SolvePuzzlePartOne()
        {
            long freq = 0;

            foreach (var item in PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(item, out int val))
                    freq += val;
            }

            Console.WriteLine($"{freq}");
            return freq;
        }

        protected override long SolvePuzzlePartTwo()
        {
            List<int> freqs = new List<int>();
            int freq = 0;
            bool found = false;
            
            do
            {
                foreach (var item in PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (int.TryParse(item, out int val))
                        freq += val;

                    if (freqs.Contains(freq))
                        found = true;
                    else
                        freqs.Add(freq);
                }
            } while (!found);
            
            Console.WriteLine($"{freq}");
            return freq;
        }

        #endregion

    }
}
