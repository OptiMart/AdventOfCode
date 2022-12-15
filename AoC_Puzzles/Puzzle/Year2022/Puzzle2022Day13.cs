using AoC.Puzzles.Common.IntCodeComputer.Instructions;
using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        List<Signal> Signals = new();
        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();

            foreach (var item in PuzzleItems.Where(l => !string.IsNullOrWhiteSpace(l)))
            {
                Signals.Add(new(item));
            }
        }

        protected override string SolvePuzzlePartOne()
        {
            long result = 0;

            //string test1 = "[1,[2,[3,[4,[5,6,7]]]],8,9]";
            //string test2 = "[1,[2,[3,[4,[5,6,0]]]],8,9]";

            //Signal sig1 = new Signal(test1);
            //Signal sig2 = new Signal(test2);

            //var res = sig1.CompareTo(sig2);


            for (int i = 0; i < Signals.Count / 2; i++)
            {
                var test = Signals[i * 2].CompareTo(Signals[i * 2 + 1]);

                if (test < 0)
                {
                    result += i + 1;
                }
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;

            Signal div1 = new("[[2]]");
            Signal div2 = new("[[6]]");

            Signals.Add(div1);
            Signals.Add(div2);

            Signals.Sort();

            int res1= Signals.IndexOf(div1) + 1;
            int res2= Signals.IndexOf(div2) + 1;

            result = res1 * res2;

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        #endregion

    }

    internal class Signal : IComparable<Signal>
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
        public int? Value { get => _value; } // ?? Signals.FirstOrDefault()?.Value; }
        public List<Signal> Signals { get; set; } = new List<Signal>();

        public List<Signal> DecodeSignal(string input)
        {
            List<Signal> result = new List<Signal>();


            //if (input[0] == '[')
            //{
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
                        if (int.TryParse(input.Substring(start, i - start), out int val))
                            result.Add(new Signal(val));
                        else
                            result.Add(new Signal(input.Substring(start, i - start)));
                    }
                    start = i + 1;
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
                if (int.TryParse(input[start..], out int val))
                    result.Add(new Signal(val));
                else
                    result.Add(new Signal(input.Substring(start)));
            }
            //}
            //else
            //{
            //    foreach (var item in input.Split(','))
            //    {
            //        if (int.TryParse(item, out int val))
            //        {
            //            result.Add(new Signal(val));
            //        }
            //    }
            //}

            return result;
        }

        public int CompareTo(Signal? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null)
                return 1;

            // If both are Integers compare their values
            if (Value != null && other.Value != null)
                return (int)Value - (int)other.Value;

            // If both are Lists compare their elements
            if (Value == null && other.Value == null)
            {
                for (int i = 0; i < Signals.Count; i++)
                {
                    if (other.Signals.Count <= i)
                        return 1;

                    if (Signals[i].CompareTo(other.Signals[i]) == 0)
                        continue;

                    return Signals[i].CompareTo(other.Signals[i]);
                }

                return Signals.Count - other.Signals.Count;
            }

            if (Value == null && other.Value != null)
                return CompareTo(new Signal($"{other.Value}"));

            if (Value != null && other.Value == null)
                return new Signal($"[{Value}]").CompareTo(other);


            return 0;
        }

        public override string ToString()
        {
            if (Value == null)
                return $"[{String.Join(",", Signals)}]";

            return Value.ToString();
        }
    }
}
