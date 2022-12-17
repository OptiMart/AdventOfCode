using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2022
{
    /// <summary>
    /// Pyroclastic Flow
    /// </summary>
    public class Puzzle2022Day17 : PuzzleBase
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

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        #endregion

    }

    internal class Chamber
    {
        public Chamber()
        {

        }

        public int Width { get; init; }
    }

    internal class Rock
    {
        #region Constructor
        public Rock() { }

        #endregion

        #region Properties
        public List<(int x, int y)> Shape {get; init; }
        public (int x, int y) Position { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public bool IsStopped { get; set; }

        #endregion

        #region Methods
        public bool TryMove()
        {
            return false;
        }

        public void Move() { }
        #endregion
    }
}
