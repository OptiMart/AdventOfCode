using AoC.AdventOfCode.Base;
using AoC.SpaceImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Year2019
{
    public class Day08 : PuzzleBase
    {
        #region Data
        private Image image;

        #endregion
        
        #region Constructor
        public Day08() : base(2019, 8)
        { }

        #endregion

        #region Methods
        protected override int SolvePuzzlePartOne()
        {
            var layer = image.GetLayerFewestInt(0);
            int res = layer.CountIntegers(1) * layer.CountIntegers(2);
            Console.WriteLine($"{res}");
            return res;
        }

        protected override int SolvePuzzlePartTwo()
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
