using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Puzzle2019Day04 : PuzzleBase
    {
        #region Data
        private int lbound = 0;
        private int ubound = 0;

        #endregion
        
        #region Constructor
        public Puzzle2019Day04() : base(2019, 4)
        { }

        #endregion

        #region Methods
        public override void LoadAdditionalParameter(string[] args)
        {
            int.TryParse(args[0], out lbound);
            int.TryParse(args[1], out ubound);
        }

        protected override void DoPreparations()
        {
            var input = PuzzleInput.Split('-');
            LoadAdditionalParameter(input);
        }

        protected override long SolvePuzzlePartOne()
        {
            int res = 0;

            for (int i = lbound; i <= ubound; i++)
            {
                if (IsSixDigits(i) && HasAdjacentSameInt(i) &&  NeverDecreses(i))
                    res++;
            }

            Console.WriteLine($"{res}");
            return res;

        }

        protected override long SolvePuzzlePartTwo()
        {
            int res = 0;

            for (int i = lbound; i <= ubound; i++)
            {
                if (IsSixDigits(i) && HasAdjacentSameInt(i) && NeverDecreses(i) && HasPairOfInt(i))
                    res++;
            }

            Console.WriteLine($"{res}");
            return res;
        }

        private bool IsSixDigits(int number)
        {
            return number >= Math.Pow(10,5) && number < Math.Pow(10,6);
        }

        private bool HasAdjacentSameInt(int number)
        {
            int prev = 10;
            do
            {
                var num = number % 10;

                if (num == prev)
                    return true;

                prev = num;
                number /= 10;
            } while (number > 0);

            return false;
        }

        private bool NeverDecreses(int number)
        {
            int prev = 10;
            do
            {
                var num = number % 10;

                if (num > prev)
                    return false;

                prev = num;
                number /= 10;
            } while (number > 0);

            return true;
        }

        private bool HasPairOfInt(int number)
        {
            int prev = 10;
            int count = 0;
            do
            {
                var num = number % 10;

                if (num != prev && count == 1)
                    return true;

                if (num == prev)
                    count++;
                else
                    count = 0;

                prev = num;
                number /= 10;
            } while (number > 0);

            if (count == 1)
                return true;
            
            return false;
        }

        #endregion
    }
}
