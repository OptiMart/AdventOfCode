using AoC.Puzzles.Common.SpaceMap;
using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2018
{
    public class Puzzle2018Day25 : PuzzleBase
    {
        #region Data
        private List<Point4D> map = new List<Point4D>();

        #endregion

        #region Constructor

        #endregion

        #region Methods
        protected override string SolvePuzzlePartOne()
        {
            long freq = 0;

            foreach (var item in PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                map.Add(new Point4D(item));
            }

            foreach (var item in map)
            {
                item.CheckAllNeighbours(map);
            }

            int res = 0;
            foreach (var item in map)
            {
                res++;
                if (item.MarkConstellation(res) != res)
                    res--;
            }

            Console.WriteLine($"{res}");
            return res.ToString();
        }

        protected override string SolvePuzzlePartTwo()
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
            return freq.ToString();
        }

        #endregion

    }
}
