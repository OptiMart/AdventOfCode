using AoC.AdventOfCode.Common.IntCodeComputer;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Puzzle2019Day16 : PuzzleBase
    {
        #region Data
        private int[] basePattern = new int[4] { 0, 1, 0, -1 };

        #endregion

        #region Constructor
        public Puzzle2019Day16() : base(2019, 16)
        { }

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
        }

        protected override long SolvePuzzlePartOne()
        {
            var output = GetFFT(PuzzleInput, 100);
            int.TryParse(output.Substring(0, 8), out int res);
            Console.WriteLine($"{res}");
            return res;
        }

        protected override long SolvePuzzlePartTwo()
        {
            // Find performant way

            //SolveExternal();
            int.TryParse(PuzzleInput.Substring(0, 7), out int offset);
            StringBuilder message = new StringBuilder();
            message.Insert(0, PuzzleInput, 10_000);
            _ = message.Length;
            //string pattern = message.Substring(offset);

            for (int i = 0; i < 100; i++)
            {
                int sum = 0;
                for (int n = message.Length - 1; n >= offset; n--)
                {
                    int.TryParse(message[n].ToString(), out int pos);
                    sum += pos;
                    message.Remove(n, 1);
                    message.Insert(n, (sum % 10));
                }
                //message = temp1;
            }
            var result = message.ToString().Substring(offset, 8);
            //var output = GetFFT(message, 100);
            int res = 0;
            Console.WriteLine($"{res}");
            return res;
        }

        private string GetFFT(string input, int phases)
        {

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                int value = 0;
                for (int n = i; n < input.Length; n++)
                {
                    int fac2 = GetFFTFactor(i + 1, n + 1);
                    //int.TryParse(input.Substring(n, 1), out int fac1);
                    //    value += fac1 * fac2;

                    if (fac2 != 0 && int.TryParse(input.Substring(n, 1), out int fac1))
                        value += fac1 * fac2;
                }

                result.Append(Math.Abs(value) % 10);
            }

            if (phases > 1)
                return GetFFT(result.ToString(), --phases);

            return result.ToString();
        }

        private int GetFFTFactor(int element, int position)
        {
            int index = ((position + 4 * element) / element) % 4;
            return basePattern[index];
        }

        private int GetSumMod10(string value)
        {
            if (int.TryParse(value, out int val))
                return GetSumMod10(val);

            return -1;
        }

        private int GetSumMod10(int value)
        {
            return GetCrossSum(value) % 10;
        }

        private int GetCrossSum(int value)
        {
            if (value == 0)
                return 0;

            return value % 10 + GetCrossSum(value / 10);
        }


        private byte[] _cache;

        private void Round(ref byte[] input, int from = 0)
        {
            var longsum = 0;

            for (int k = from; k < input.Length; k++)
            {
                longsum += input[k];
            }

            for (int i = from; i < input.Length; i++)
            {
                _cache[i] = (byte)(longsum % 10);
                longsum -= input[i];
            }

            var tmp = input;
            input = _cache;
            _cache = tmp;
        }

        private void SolveExternal()
        {
            var input = PuzzleInput.Select(x => (byte)(x - '0')).ToArray();

            int repeats = 10_000;

            var adjustedArray = new byte[input.Length * repeats];

            for (int i = 0; i < repeats; i++)
            {
                Buffer.BlockCopy(input, 0, adjustedArray, input.Length * i, input.Length);
            }

            var offset = int.Parse(string.Join("", input.Take(7)));

            _cache = new byte[adjustedArray.Length];

            for (int i = 0; i < 100; i++)
            {
                Round(ref adjustedArray, offset);
            }

            Console.WriteLine(string.Join("", adjustedArray.Skip(offset).Take(8)));
        }
        #endregion
    }
}
