using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Base
{
    public interface IPuzzleInput
    {
        int Year { get; }
        int Day { get; }
        void LoadPuzzleInput(string input);
        void LoadPuzzleInputFromFile(string input);
        void LoadAdditionalParameter(string[] args);
        int SolvePuzzle(int part = 0);
    }
}
