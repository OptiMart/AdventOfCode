using AoC.AdventOfCode.Common.IntCodeComputer;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Puzzle2019Day14 : PuzzleBase
    {
        #region Data
        private List<Reaction> rezipies;

        #endregion

        #region Constructor
        public Puzzle2019Day14() : base(2019, 14)
        { }

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            rezipies = new List<Reaction>();

            foreach (var item in PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                var temp = item.Split(new[] { " => " }, StringSplitOptions.RemoveEmptyEntries);

                var result = CheckOrAddReaction(temp[1], out int resQuantity);
                result.Outcome = resQuantity;

                AddIngredients(result, temp[0]);
                
            }
        }

        private void AddIngredients(Reaction result, string input)
        {
            foreach (var item in input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries))
            {
                var ret = CheckOrAddReaction(item, out int quantity);
                result.Reagents.Add(ret, quantity);
            }
        }

        private Reaction CheckOrAddReaction(string value, out int quantity)
        {
            quantity = 0;
            var arr = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (arr.Length != 2)
                return null;

            int.TryParse(arr[0], out quantity);
            var result = rezipies.FirstOrDefault(x => x.Name == arr[1]);

            if (result is null)
            {
                result = new Reaction(arr[1]);
                rezipies.Add(result);
            }

            return result;
        }

        protected override long SolvePuzzlePartOne()
        {
            var rezFuel = rezipies.FirstOrDefault(x => x.Name == "FUEL");

            long res = 0;

            if (!(rezFuel is null))
                res = rezFuel.GetNeededReagent(1, "ORE");
            
            Console.WriteLine($"{res}");
            return res;
        }

        protected override long SolvePuzzlePartTwo()
        {
            var rezFuel = rezipies.FirstOrDefault(x => x.Name == "FUEL");

            long cap = (long)Math.Pow(10, 12);
            long res = 0;

            if (!(rezFuel is null))
            {
                res = 1;
                long ore = rezFuel.GetNeededReagent(res, "ORE");

                do
                {
                    ClearRemaining();

                    res = (res * cap / ore) + 1;
                    ore = rezFuel.GetNeededReagent(res, "ORE");
                } while (ore <= cap);

                res--;
            }

            Console.WriteLine($"{res}");
            return res;
        }

        #endregion
        private void ClearRemaining()
        {
            rezipies.ForEach(x => x.Remaining = 0);
        }
    }

    [DebuggerDisplay("{Name} - {Outcome}")]
    class Reaction
    {

        public Reaction(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Outcome { get; set; }
        public Dictionary<Reaction, int> Reagents { get; private set; } = new Dictionary<Reaction, int>();
        public int NeedCount { get; set; } = 0;
        public long Remaining { get; set; } = 0;

        public long GetNeededReagent(long needCount, string name)
        {
            long result = 0;
            long craft = (needCount - Remaining + Outcome - 1) / Outcome;
            Remaining = Remaining + craft * Outcome - needCount;
            
            foreach (var item in Reagents)
            {
                if (item.Key.Name == name)
                    result += craft * item.Value;
                else
                    result += item.Key.GetNeededReagent(item.Value * craft, name);
            }

            return result;
        }
    }
}
