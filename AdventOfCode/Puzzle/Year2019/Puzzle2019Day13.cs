using AoC.AdventOfCode.Common.IntCodeComputer;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Puzzle2019Day13 : PuzzleBase
    {
        #region Data

        #endregion

        #region Methods
        protected override string SolvePuzzlePartOne()
        {
            Arcade cpu = new Arcade(PuzzleInput);
            cpu.StartGame(true);
            
            var res = cpu.Points.Count(p => p.Tile == Tiles.Block);
            Console.WriteLine($"{res}");
            return res.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            Arcade cpu = new Arcade(PuzzleInput);
            cpu.Memory.SaveAtAddress(0, 2);
            cpu.StartGame(true);
            var res = cpu.Score;
            Console.WriteLine($"{res}");
            return res.ToString();
        }

        #endregion
    }
}
