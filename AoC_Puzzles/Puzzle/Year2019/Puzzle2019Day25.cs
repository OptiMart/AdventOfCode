using AoC.Puzzles.Common.IntCodeComputer;
using AoC.Puzzles.Common.Shuffle;
using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC.Puzzles.Puzzle.Year2019
{
    /// <summary>
    /// Day 25: Cryostasis
    /// </summary>
    public class Puzzle2019Day25 : PuzzleBase
    {
        #region Data
        private List<string> _items = new List<string>() { "ornament", "astrolabe", "fuel cell", "hologram", "weather machine", "mug", "monolith", "bowl of rice" };

        #endregion

        #region Methods
        protected override string SolvePuzzlePartOne()
        {
            Computer cpu = new Computer(PuzzleInput);
            cpu.LoadDefaultInstructionSet();
            cpu.Initialize();
            GetEverythingInPosition(cpu);
            DropItem(cpu, _items);
            //Console.Write(cpu.GetAsciiOutput());
            _ = cpu.GetAsciiOutput();

            for (int i = 1; i < 8; i++)
            {
                foreach (var set in Shuffle.GetKCombs(_items, i))
                {
                    TakeItem(cpu, set.ToList());
                    _ = cpu.GetAsciiOutput();
                    cpu.WriteAsciiInput("north" + (char)10);
                    //Console.Write(cpu.GetAsciiOutput());
                    
                    if (cpu.LastExitCode == 99)
                    {
                        i = 9;
                        break;
                    }

                    DropItem(cpu, set.ToList());
                }
            }

            //RunComputerProgram(cpu);

            string res = Regex.Match(cpu.GetAsciiOutput(), @"\d+").Value;
            Console.WriteLine($"{res}");
            return res.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            string res = string.Empty;
            Console.WriteLine($"{res}");
            return res.ToString();
        }

        private void RunComputerProgram(Computer cpu)
        {
            int opCode = 0;

            cpu.StartExecution();
            GetEverythingInPosition(cpu);
            do
            {
                Console.Write(cpu.GetAsciiOutput());
                var input = Console.ReadLine() + (char)10;
                cpu.WriteAsciiInput(input, true);
            } while (cpu.LastExitCode != 99);

            Console.Write(cpu.GetAsciiOutput());
            Console.WriteLine("Program Terminated!");
        }

        private void GetEverythingInPosition(Computer cpu)
        {
            StringBuilder input = new StringBuilder();
            input.Append("west").Append((char)10);
            input.Append("take ornament").Append((char)10);
            input.Append("west").Append((char)10);
            input.Append("take astrolabe").Append((char)10);
            input.Append("north").Append((char)10);
            input.Append("take fuel cell").Append((char)10);
            input.Append("south").Append((char)10);
            input.Append("south").Append((char)10);
            input.Append("take hologram").Append((char)10);
            input.Append("north").Append((char)10);
            input.Append("east").Append((char)10);
            input.Append("south").Append((char)10);
            input.Append("east").Append((char)10);
            input.Append("take weather machine").Append((char)10);
            input.Append("west").Append((char)10);
            input.Append("north").Append((char)10);
            input.Append("east").Append((char)10);
            input.Append("east").Append((char)10);
            input.Append("take mug").Append((char)10);
            input.Append("north").Append((char)10);
            input.Append("take monolith").Append((char)10);
            input.Append("south").Append((char)10);
            input.Append("south").Append((char)10);
            input.Append("west").Append((char)10);
            input.Append("north").Append((char)10);
            input.Append("west").Append((char)10);
            input.Append("take bowl of rice").Append((char)10);
            input.Append("north").Append((char)10);
            input.Append("west").Append((char)10);

            cpu.WriteAsciiInput(input.ToString(), true);
        }

        private void DropItem(Computer cpu, List<string> items)
        {
            DoSomethingItem(cpu, items, "drop");
        }

        private void TakeItem(Computer cpu, List<string> items)
        {
            DoSomethingItem(cpu, items, "take");
        }

        private void DoSomethingItem(Computer cpu, List<string> items, string action)
        {
            if (!items.Any())
                return;

            StringBuilder input = new StringBuilder();

            foreach (var item in items)
            {
                input.Append(action).Append(" ").Append(item).Append((char)10);
            }

            cpu.WriteAsciiInput(input.ToString());
        }

        private IEnumerable<IEnumerable<T>> GetAllVariants<T>(IEnumerable<T> list, int length)
        {
            List<IEnumerable<T>> result = new List<IEnumerable<T>>();

            for (int i = 1; i <= length; i++)
            {
                result.AddRange(GetPermutations(list, i));
            }

            return result.AsEnumerable();
        }

        private IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        #endregion
    }
}
