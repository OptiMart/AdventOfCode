using AoC.Puzzles.Common.Monkeys;
using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2022
{
    /// <summary>
    /// Monkey in the Middle
    /// </summary>
    public class Puzzle2022Day11 : PuzzleBase
    {
        #region Data
        private List<Monkey> Monkeys = new List<Monkey>();

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();

            //foreach (var line in PuzzleItems)
            //{
            //    if (line.Substring(0, 6) == "Monkey" && int.TryParse(line.Substring(6).TakeWhile(c => char.IsDigit(c)).ToString(), out int num))
            //    {
            //        Monkeys.Add(new Monkey(num));
            //    }

            //    if (line.Substring(0, 10) == "  Starting items: ")
            //    {

            //    }

            //    if (line.Substring(0, 10) == "  Operation: ")
            //    {

            //    }

            //    if (line.Substring(0, 10) == "  Test: ")
            //    {

            //    }

            //    if (line.Substring(0, 10) == "    If true: throw to monkey ")
            //    {

            //    }

            //    if (line.Substring(0, 10) == "    If false: throw to monkey ")
            //    {

            //    }

            //}

        }

        protected override string SolvePuzzlePartOne()
        {
            long result = 0;

            InitMonkeys(3, new int[] { 2, 3, 5, 7, 11, 13, 17, 19 });

            for (int i = 0; i < 20; i++)
            {
                foreach (var monkey in Monkeys)
                {
                    monkey.ThrowAllItems(Monkeys);
                }
            }

            result = Monkeys.OrderByDescending(x => x.Throws).Take(2).Aggregate((long)1, (a, b) => a * b.Throws);

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;

            InitMonkeys(1, new int[] { 2, 3, 5, 7, 11, 13, 17, 19 });

            foreach (var monkey in Monkeys)
            {
                monkey.WorryFactor = 1;
            }

            for (int i = 0; i < 10000; i++)
            {
                foreach (var monkey in Monkeys)
                {
                    monkey.ThrowAllItems(Monkeys);
                }
            }

            result = Monkeys.OrderByDescending(x => x.Throws).Take(2).Aggregate((long)1, (a, b) => a * b.Throws);

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        public void InitMonkeys(int worry, IEnumerable<int> factors)
        {
            Monkeys.Clear();

            Monkeys.Add(new Monkey(0)
            {
                Items = new Queue<long>(new long[] { 75, 75, 98, 97, 79, 97, 64 }),
                Operation = (x => x * 13),
                Test = (x => x % 19 == 0 ? 2 : 7),
                WorryFactor = worry,
                Factors = factors.ToList()
            });

            Monkeys.Add(new Monkey(1)
            {
                Items = new Queue<long>(new long[] { 50, 99, 80, 84, 65, 95 }),
                Operation = (x => x + 2),
                Test = (x => x % 3 == 0 ? 4 : 5),
                WorryFactor = worry,
                Factors = factors.ToList()
            });

            Monkeys.Add(new Monkey(2)
            {
                Items = new Queue<long>(new long[] { 96, 74, 68, 96, 56, 71, 75, 53 }),
                Operation = (x => x + 1),
                Test = (x => x % 11 == 0 ? 7 : 3),
                WorryFactor = worry,
                Factors = factors.ToList()
            });

            Monkeys.Add(new Monkey(3)
            {
                Items = new Queue<long>(new long[] { 83, 96, 86, 58, 92 }),
                Operation = (x => x + 8),
                Test = (x => x % 17 == 0 ? 6 : 1),
                WorryFactor = worry,
                Factors = factors.ToList()
            });

            Monkeys.Add(new Monkey(4)
            {
                Items = new Queue<long>(new long[] { 99 }),
                Operation = (x => x * x),
                Test = (x => x % 5 == 0 ? 0 : 5),
                WorryFactor = worry,
                Factors = factors.ToList()
            });

            Monkeys.Add(new Monkey(5)
            {
                Items = new Queue<long>(new long[] { 60, 54, 83 }),
                Operation = (x => x + 4),
                Test = (x => x % 2 == 0 ? 2 : 0),
                WorryFactor = worry,
                Factors = factors.ToList()
            });

            Monkeys.Add(new Monkey(6)
            {
                Items = new Queue<long>(new long[] { 77, 67 }),
                Operation = (x => x * 17),
                Test = (x => x % 13 == 0 ? 4 : 1),
                WorryFactor = worry,
                Factors = factors.ToList()
            });

            Monkeys.Add(new Monkey(7)
            {
                Items = new Queue<long>(new long[] { 95, 65, 58, 76 }),
                Operation = (x => x + 5),
                Test = (x => x % 7 == 0 ? 3 : 6),
                WorryFactor = worry,
                Factors = factors.ToList()
            });
        }

        #endregion
    }
}
