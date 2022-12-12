using AoC.Puzzles.Common.IntCodeComputer;
using AoC.Puzzles.Common.Shuffle;
using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AoC.Puzzles.Puzzle.Year2019
{
    public class Puzzle2019Day22 : PuzzleBase
    {
        #region Methods
        protected override string SolvePuzzlePartOne()
        {
            List<long> deck = GetNewDeck(10007);

            foreach (var instruction in PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                GetNextShuffleInstruction(deck, instruction);
            }

            long res = deck.IndexOf(2019);
            Console.WriteLine($"{res}");
            return res.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long deckSize = 119315717514047;
            long times = 101741582076661;
            long positionToFind = 2020;

            long a = 1;
            long b = 0;

            foreach (var instruction in PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                CondenseShuffleInstruction(instruction, ref a, ref b, ref deckSize);
            }

            BigInteger off = new BigInteger(b);
            off *= BigInteger.ModPow(new BigInteger(1 - a), new BigInteger(deckSize - 2), new BigInteger(deckSize));

            off %= new BigInteger(deckSize);

            var big = new BigInteger(positionToFind - long.Parse(off.ToString()));

            big *= BigInteger.ModPow(new BigInteger(a), new BigInteger(times) * new BigInteger(deckSize - 2), new BigInteger(deckSize));

            big += off;

            big %= new BigInteger(deckSize);

            var res = big.ToString();
            Console.WriteLine($"{res}");
            return res.ToString();
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

        private void CondenseShuffleInstruction(string instruction, ref long a, ref long b, ref long N)
        {
            if (instruction.StartsWith("deal into new stack"))
            {
                a = (-a) % N;
                b = (N - 1 - b) % N;
            }
            else if (instruction.StartsWith("cut"))
            {
                int.TryParse(instruction.Replace("cut ", ""), out int x);
                b = (b - x) % N;
            }
            else if (instruction.StartsWith("deal with increment"))
            {
                int.TryParse(instruction.Replace("deal with increment ", ""), out int x);
                a = a * x % N;
                b = b * x % N;
            }

        }

        #endregion
    }
}
