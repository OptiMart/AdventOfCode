using AoC.Puzzles.Puzzle.Base;
using AoC.Puzzles.SpaceImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2019
{
    public class Puzzle2019Day08 : PuzzleBase
    {
        #region Data
        private Image image;

        #endregion
        
        #region Methods
        protected override string SolvePuzzlePartOne()
        {
            var layer = image.GetLayerFewestInt(0);
            int res = layer.CountIntegers(1) * layer.CountIntegers(2);
            //Console.WriteLine($"{res}");
            return res.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            var res = image.AggregateAllLayers();
            //Console.Write(res.ToString().Replace('0', ' ').Replace('1', '#'));
            return res.ToString();
        }

        protected override void DoPreparations()
        {
            image = new Image(25, 6, PuzzleInput);
        }

        #endregion
    }
}
