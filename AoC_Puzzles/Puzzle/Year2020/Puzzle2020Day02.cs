using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2019
{
    public class Puzzle2020Day02 : PuzzleBase
    {
        private List<PassTest> _passTest;

        #region Methods

        protected override void DoPreparations()
        {
            _passTest = new List<PassTest>();

            foreach (var item in PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                _passTest.Add(new PassTest(item));
            }
        }

        protected override string SolvePuzzlePartOne()
        {
            int result = 0;

            foreach (var pass in _passTest)
            {
                if (pass.PasswordIsValidOne())
                    result++;
            }
            
            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            int result = 0;

            foreach (var pass in _passTest)
            {
                if (pass.PasswordIsValidTwo())
                    result++;
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        #endregion

        private class PassTest
        {
            public PassTest(string input)
            {
                DecodeInput(input);
            }

            public string Letter { get; set; }
            public int Minimum { get; set; }
            public int Maximum { get; set; }
            public string Password { get; set; }

            private void DecodeInput(string input)
            {
                string[] temp = input.Split("- :".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                Minimum = int.Parse(temp[0]);
                Maximum = int.Parse(temp[1]);
                Letter = temp[2];
                Password = temp[3];
            }

            public bool PasswordIsValidOne()
            {
                int occurance = Password.Count(x => x == Letter[0]);

                if (occurance >= Minimum && occurance <= Maximum)
                {
                    return true;
                }

                return false;
            }

            public bool PasswordIsValidTwo()
            {
                if (Letter[0] == Password[Minimum - 1] ^ Letter[0] == Password[Maximum - 1])
                    return true;

                return false;
            }
        }
    }
}
