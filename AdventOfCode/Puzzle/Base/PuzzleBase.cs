using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Base
{
    public abstract class PuzzleBase : IPuzzleInput
    {
        #region Constructor
        protected PuzzleBase() : this(0, 0)
        { }

        protected PuzzleBase(int year, int day)
        {
            Year = year;
            Day = day;
        }

        #endregion

        #region Properties
        public int Year { get; private set; }
        public int Day { get; private set; }
        public string PuzzleInput { get; set; }

        #endregion

        #region Methods
        public virtual void LoadAdditionalParameter(string[] args)
        {
            throw new NotImplementedException();
        }

        public virtual void LoadPuzzleInput(string input)
        {
            PuzzleInput = input;
        }

        public virtual void LoadPuzzleInputFromFile(string input)
        {
            FileInfo fileInfo = new FileInfo(input);
            if (fileInfo.Exists)
                PuzzleInput = System.IO.File.ReadAllText(input);
            else
                throw new FileNotFoundException($"Datei {input} konnte nicht gefunden werden");
        }

        public string GetInputPath(int part = 0)
        {
            return $@"D:\AdventofCode\Input_Day{Day}" + (part == 0 ? "" : "_{part}") + ".txt";
        }

        public virtual long SolvePuzzle(int part = 0)
        {
            long[] result = new long[] { 0, 0, 0 };
            Stopwatch watch = new Stopwatch();

            try
            {
                LoadPuzzleInputFromFile(GetInputPath());
            }
            catch (Exception)
            { 
                // Just continue
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"--- {Year} - Day {Day:D2} ---");
            DoPreparations();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Result Part 1:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            watch.Start();
            result[1] = SolvePuzzlePartOne();
            watch.Stop();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Calctime: {watch.ElapsedMilliseconds:G} ms");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Result Part 2:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            watch.Restart();
            result[2] = SolvePuzzlePartTwo();
            watch.Stop();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Calctime: {watch.ElapsedMilliseconds:G} ms");

            Console.ResetColor();
            Console.WriteLine();

            return result[part];
        }

        protected virtual void DoPreparations()
        { }

        protected virtual long SolvePuzzlePartOne()
        {
            Console.WriteLine($"tba");
            return 0;
        }

        protected virtual long SolvePuzzlePartTwo()
        {
            Console.WriteLine($"tba");
            return 0;
        }

        #endregion

    }
}
