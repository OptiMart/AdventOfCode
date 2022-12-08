using AoC.AdventOfCode.Common.ElvDevice;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2022
{
    /// <summary>
    /// No Space Left On Device
    /// </summary>
    public class Puzzle2022Day07 : PuzzleBase
    {
        #region Data
        private ElvDevice device;

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();
            PuzzleItems = LoadPuzzleItemsString("\n", true);

            device = new ElvDevice(70000000);
            device.ReadFilesystem(PuzzleItems);
        }

        protected override string SolvePuzzlePartOne()
        {
            long result = 0;
            int ubound = 100000;

            result = device.Filesystem.GetDirectorySizeSummary(x => x.Size <= ubound);

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;
            long neededSpace = 30000000;
            long test = neededSpace - device.FreeDiskSpace;

            result = device.Filesystem.GetDirectory(x => x.Size >= test).OrderBy(x => x.Size).First().Size;

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        #endregion

    }
}
