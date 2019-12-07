using AoC.AdventOfCode.Base;
using AoC.AdventOfCode.Year2019;
using AoC.IntcodeComputer;
using AoC.IntcodeComputer.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.AdventOfCode
{
    static class Program
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText(@"D:\AdventofCode\Input_Day2_1.txt");
            var mem = new Memory(input);

            mem.SaveAtAddress(1, 12);
            mem.SaveAtAddress(2, 2);


            List<IInstructions> instructions = new List<IInstructions>()
            {
                new OpTermination(),
                new OpAddition(),
                new OpMultiplication(),
            };

            try
            {
                int result = -1;
                int position = 0;

                do
                {
                    var op = instructions.FirstOrDefault(x => x.CheckInstruction(mem, position));

                    if (op is null)
                        throw new InvalidOperationException($"Ungültige Operation an Position: {position}");
                    result = op.ExecuteInstruction(mem, ref position);
                } while (result != 99);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Fehler bei der Ausführung", ex);
            }

            List<PuzzleBase> puzzles = new List<PuzzleBase>()
            {
                new Day01(),
                new Day02(),
                new Day03(),
                new Day04(),
                new Day05(),
                new Day06(),
                new Day07(),
            };

            var day3 = new Day03();
            day3.LoadPuzzleInputFromFile(@"D:\AdventofCode\Input_Day3_Example2.txt");
            day3.LoadPuzzleInputFromFile(@"D:\AdventofCode\Input_Day3_1.txt");
            int result3 = day3.SolvePuzzle(2);


            var day4 = new Day04();
            var result4 = day4.SolvePuzzle();
        }
    }
}
