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
    /// Supply Stacks
    /// </summary>
    public class Puzzle2022Day05 : PuzzleBase
    {
        #region Data
        private Dictionary<int, Stack<string>> _stacks;
        private List<string> _input1;
        private List<string> _input2;

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();

            var puzzleItems = LoadPuzzleItemsString("\n", false);

            int split = puzzleItems.FindIndex(x => string.IsNullOrEmpty(x));
            _input1 = puzzleItems.GetRange(0, split - 1);
            _input2 = puzzleItems.GetRange(split, puzzleItems.Count - split).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            var lastNum = int.Parse(puzzleItems[split - 1].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Last());

            _stacks = new Dictionary<int, Stack<string>>();

            for (int i = 1; i <= lastNum; i++)
                _stacks.Add(i, new Stack<string>());
        }

        protected override string SolvePuzzlePartOne()
        {
            StringBuilder result = new StringBuilder();

            PopulateStacks(_input1);

            foreach (var code in _input2)
            {
                var instructions = code.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int source = int.Parse(instructions[3]);
                int target = int.Parse(instructions[5]);
                int count = int.Parse(instructions[1]);

                MoveItems(source, target, count);
            }

            foreach (var stack in _stacks)
            {
                result.Append(stack.Value.Peek());
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            StringBuilder result = new StringBuilder();

            PopulateStacks(_input1);

            foreach (var code in _input2)
            {
                var instructions = code.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int source = int.Parse(instructions[3]);
                int target = int.Parse(instructions[5]);
                int count = int.Parse(instructions[1]);

                MoveItemsInOrder(source, target, count);
            }

            foreach (var stack in _stacks)
            {
                result.Append(stack.Value.Peek());
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        private void PopulateStacks(List<string> input)
        {
            foreach (var stack in _stacks)
                stack.Value.Clear();

            //input.Reverse();
            for (int n = input.Count - 1; n >= 0; n--)
            {
                var line = input[n];
                for (int i = 1; i < line.Length; i += 4)
                {
                    int column = ((i - 1) / 4) + 1;
                    string item = line[i].ToString();

                    if (!string.IsNullOrWhiteSpace(item))
                        _stacks[column].Push(line[i].ToString());
                }
            }
        }

        private void MoveItems(int source, int target, int count)
        {
            for (int i = 0; i < count; i++)
            {
                _stacks[target].Push(_stacks[source].Pop());
            }
        }

        private void MoveItemsInOrder(int source, int target, int count)
        {
            Stack<string> temp = new Stack<string>();

            for (int i = 0; i < count; i++)
                temp.Push(_stacks[source].Pop());

            while (temp.Any())
                _stacks[target].Push(temp.Pop());
        }


        #endregion

    }
}
