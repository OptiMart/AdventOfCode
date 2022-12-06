// See https://aka.ms/new-console-template for more information
using AoC.AdventOfCode.Puzzle.Base;

static void SolvePuzzles(int year = 0, int day = 0, int part = 0)
{
    var puzzles = PuzzleHelper.GetPuzzles(year, day);

    foreach (var puzzle in puzzles.OrderBy(x => x.Year * 100 + x.Day))
        puzzle.SolvePuzzle(part);

}

SolvePuzzles(2022, 5, 0);

Console.ReadKey();
