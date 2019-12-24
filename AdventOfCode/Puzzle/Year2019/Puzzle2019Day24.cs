using AoC.AdventOfCode.Common.IntCodeComputer;
using AoC.AdventOfCode.Common.Shuffle;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    /// <summary>
    /// Day 23: Category Six
    /// </summary>
    public class Puzzle2019Day24 : PuzzleBase
    {
        #region Data
        private bool[] _results = new bool[2 << 26];

        #endregion

        #region Methods
        protected override string SolvePuzzlePartOne()
        {
            ComputerNetwork nic = new ComputerNetwork(PuzzleInput, 50);
            nic.StartComputing(true);

            long res = nic.LastNATPacket.Item3;
            Console.WriteLine($"{res}");
            return res.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            ComputerNetwork nic = new ComputerNetwork(PuzzleInput, 50);
            nic.StartComputing(false);

            long res = nic.LastSentPacket.Item2;
            Console.WriteLine($"{res}");
            return res.ToString();
        }



        #endregion
    }
}
