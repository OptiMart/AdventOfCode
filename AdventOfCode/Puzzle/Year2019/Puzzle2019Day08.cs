using AoC.AdventOfCode.Puzzle.Base;
using AoC.AdventOfCode.SpaceImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Puzzle2019Day08 : PuzzleBase
    {
        #region Data
        private Image image;

        #endregion
        
        #region Methods
        protected override long SolvePuzzlePartOne()
        {
            var layer = image.GetLayerFewestInt(0);
            int res = layer.CountIntegers(1) * layer.CountIntegers(2);
            Console.WriteLine($"{res}");
            return res;
        }

        protected override long SolvePuzzlePartTwo()
        {
            var result = image.AggregateAllLayers();
            Console.Write(result.ToString().Replace('0', ' ').Replace('1', '#'));
            return 0;
        }

        protected override void DoPreparations()
        {
            image = new Image(25, 6, PuzzleInput);
        }

        #endregion
    }
}
