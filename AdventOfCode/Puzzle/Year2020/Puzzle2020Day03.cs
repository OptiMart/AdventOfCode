using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Puzzle2020Day03 : PuzzleBase
    {
        #region Methods

        protected override void DoPreparations()
        {
        }

        protected override string SolvePuzzlePartOne()
        {
            int result = 0;
            int posx = 0;

            foreach (string item in PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (item[posx] == '#')
                    result++;

                posx = (posx + 3) % item.Length;
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            int result = 0;
            int rowN = 0;

            List<Tuple<int, int, int, int>> slopes = new List<Tuple<int, int, int, int>>()
            {
                new Tuple<int,int,int,int>(1,1,0,0),
                new Tuple<int,int,int,int>(3,1,0,0),
                new Tuple<int,int,int,int>(5,1,0,0),
                new Tuple<int,int,int,int>(7,1,0,0),
                new Tuple<int,int,int,int>(1,2,0,0),
            };

            int[] results = new int[5];

            foreach (string item in PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                int i = 0;
                foreach (var slope in slopes)
                {
                    if (rowN % slope.Item2 == 0)
                    {
                        if (item[slope.Item3] == '#')
                            results[i]++;
                    }

                    i++;
                }
                posx = (posx + 3) % item.Length;

                rowN++;
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        #endregion

    }
}
