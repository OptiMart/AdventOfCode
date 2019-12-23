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
    public class Puzzle2019Day22 : PuzzleBase
    {
        #region Methods
        protected override long SolvePuzzlePartOne()
        {
            List<long> deck = GetNewDeck(10007);

            foreach (var instruction in PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                GetNextShuffleInstruction(deck, instruction);
            }

            long res = deck.IndexOf(2019);
            Console.WriteLine($"{res}");
            return res;
        }

        protected override long SolvePuzzlePartTwo()
        {
            List<long> deck = GetNewDeck(119315717514047);

            foreach (var instruction in PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                GetNextShuffleInstruction(deck, instruction);
            }

            long res = 0;
            Console.WriteLine($"{res}");
            return res;
        }

        private List<long> GetNewDeck(long size)
        {
            List<long> result = new List<long>();

            for (int i = 0; i < size; i++)
            {
                result.Add(i);
            }

            return result;
        }

        private void GetNextShuffleInstruction(List<long> deck, string instruction)
        {
            if (instruction.StartsWith("deal into new stack"))
            {
                Shuffle.DealIntoNew(deck);
            }
            else if (instruction.StartsWith("cut"))
            {
                int.TryParse(instruction.Replace("cut ", ""), out int value);
                Shuffle.CutNElements(deck, value);
            }
            else if (instruction.StartsWith("deal with increment"))
            {
                int.TryParse(instruction.Replace("deal with increment ", ""), out int value);
                Shuffle.DealIncrement(deck, value);
            }
        }

        #endregion
    }
}
