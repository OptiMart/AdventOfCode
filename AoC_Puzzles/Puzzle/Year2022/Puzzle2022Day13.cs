using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2022
{
    /// <summary>
    /// Distress Signal
    /// </summary>
    public class Puzzle2022Day13 : PuzzleBase
    {
        #region Data
        List<Tuple<Signal, Signal>> Signals = new List<Tuple<Year2022.Signal, Year2022.Signal>>();
        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();

            foreach (var item in PuzzleItems.Where(l => !string.IsNullOrWhiteSpace(l)).Chunk(2))
            {
                var test = new Signal(item[0]);
                Signals.Add(new Tuple<Signal, Signal>(new Signal(item[0]), new Signal(item[1])));
            }
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

    class Signal : IComparable<Signal>
    {
        private int? _value;
        public Signal(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                Signals = DecodeSignal(input);
            }
        }
        public Signal(int value)
        {
            _value = value;
        }
        public int? Value { get => _value ?? Signals.FirstOrDefault()?.Value; }
        public List<Signal> Signals { get; set; } = new List<Signal>();

        public List<Signal> DecodeSignal(string input)
        {
            List<Signal> result = new List<Signal>();


            if (input[0] == '[')
            {
                int start = 0;
                int level = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '[')
                    {
                        if (level == 0)
                        {
                            start = i;
                        }
                        level++;
                    }

                    if (input[i] == ',' && level == 0)
                    {
                        if (start < i)
                        {
                            result.Add(new Signal(input.Substring(start + 1, i - start - 1)));
                        }
                        start = i;
                    }

                    if (input[i] == ']')
                    {
                        level--;
                        if (level == 0)
                        {
                            result.Add(new Signal(input.Substring(start + 1, i - start - 1)));
                            start = i + 1;
                        }
                    }
                }

                if (start < input.Length)
                {
                    result.Add(new Signal(input.Substring(start + 1)));
                }
            }
            else
            {
                foreach (var item in input.Split(','))
                {
                    if (int.TryParse(item, out int val))
                    {
                        result.Add(new Signal(val));
                    }
                }
            }

            return result;
        }

        public int CompareTo(Signal? other)
        {
            throw new NotImplementedException();
        }
    }
}
