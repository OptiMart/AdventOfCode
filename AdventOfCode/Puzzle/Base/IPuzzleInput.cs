using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Base
{
    public interface IPuzzleInput
    {
        void LoadPuzzleInput(string input);
        void LoadPuzzleInputFromFile(string input);
        void LoadAdditionalParameter(string[] args);
        string SolvePuzzle(int part = 0, bool loadInput = true);
    }
}
