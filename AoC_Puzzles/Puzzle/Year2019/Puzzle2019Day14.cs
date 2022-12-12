using AoC.Puzzles.Common.IntCodeComputer;
using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AoC.Puzzles.Puzzle.Year2019
{
    public class Puzzle2019Day14 : PuzzleBase
    {
        #region Data
        private List<Reaction> recipes;

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            recipes = new List<Reaction>();

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
            var result = recipes.FirstOrDefault(x => x.Name == arr[1]);

            if (result is null)
            {
                result = new Reaction(arr[1]);
                recipes.Add(result);
            }

            return result;
        }

        protected override string SolvePuzzlePartOne()
        {
            var rezFuel = recipes.FirstOrDefault(x => x.Name == "FUEL");

            long res = 0;

            if (!(rezFuel is null))
                res = rezFuel.GetNeededReagent(1, "ORE");
            
            Console.WriteLine($"{res}");
            return res.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            var rezFuel = recipes.FirstOrDefault(x => x.Name == "FUEL");

            long cap = (long)Math.Pow(10, 12);
            long res = 0;

            // Find way that every problem can be 100% solved

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
            return res.ToString();
        }

        #endregion
        private void ClearRemaining()
        {
            recipes.ForEach(x => x.Remaining = 0);
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
