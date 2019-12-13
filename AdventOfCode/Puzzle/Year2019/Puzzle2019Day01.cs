using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Puzzle2019Day01 : PuzzleBase
    {
        #region Constructor
        public Puzzle2019Day01() : base(2019, 1)
        { }

        #endregion

        #region Methods
        protected override long SolvePuzzlePartOne()
        {
            long fuel = 0;

            foreach (var item in PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(item, out int mass))
                    fuel += CalcFuel(mass);
            }

            Console.WriteLine($"{fuel}");
            return fuel;
        }

        protected override long SolvePuzzlePartTwo()
        {
            long fuel = 0;

            foreach (var item in PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(item, out int mass))
                    fuel += CalcFuelRecurse(mass);
            }

            Console.WriteLine($"{fuel}");
            return fuel;
        }

        private int CalcFuel(int mass)
        {
            int res = mass / 3 - 2;
            return res > 0 ? res : 0;
        }

        private int CalcFuelRecurse(int mass)
        {
            if (mass <= 0)
                return 0;

            int fuel = CalcFuel(mass);

            return fuel + CalcFuelRecurse(fuel);
        }

        #endregion

    }
}
