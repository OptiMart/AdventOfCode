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
        #region Data
        private readonly string _inputFolder;

        #endregion

        #region Constructor
        protected PuzzleBase() : this(0, 0)
        { }

        protected PuzzleBase(int year, int day) : this(year, day, string.Empty)
        {
            _inputFolder = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        }

        protected PuzzleBase(int year, int day, string inputPath)
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
            return $@"D:\AdventofCode\{Year:0000}\Input_Day{Day:00}" + (part == 0 ? "" : $"_{part}") + ".txt";
        }

        public virtual long SolvePuzzle(int part = 0, bool loadInput = true)
        {
            long[] result = new long[] { 0, 0, 0 };
            Stopwatch watch = new Stopwatch();

            try
            {
                if (loadInput)
                    LoadPuzzleInputFromFile(GetInputPath());
            }
            catch (Exception)
            { 
                // Just continue
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"--- {Year} - Day {Day:00} ---");
            DoPreparations();

            if (part == 0 || part == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Result Part 1:");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                watch.Start();
                result[1] = SolvePuzzlePartOne();
                watch.Stop();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Calctime: {watch.ElapsedMilliseconds:N0} ms");
                Console.WriteLine();
            }

            if (part == 0 || part == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Result Part 2:");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                watch.Restart();
                result[2] = SolvePuzzlePartTwo();
                watch.Stop();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Calctime: {watch.ElapsedMilliseconds:N0} ms");

                Console.ResetColor();
                Console.WriteLine();
            }

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
