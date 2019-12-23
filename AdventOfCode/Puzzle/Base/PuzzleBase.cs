using AoC.AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Base
{
    public abstract class PuzzleBase : IPuzzleInput
    {
        #region Data
        private readonly string _inputFolder;

        #endregion

        #region Constructor
        protected PuzzleBase() : this(string.Empty)
        { }

        protected PuzzleBase(string inputPath)
        {
            if (string.IsNullOrEmpty(inputPath))
                _inputFolder = Path.Combine(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory), "Input");
            else
                _inputFolder = inputPath;

            Year = GetYear();
            Day = GetDay();
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
            return Path.Combine(_inputFolder, $@"{Year:0000}\Input_Day{Day:00}" + (part == 0 ? "" : $"_{part}") + ".txt");
        }

        public virtual string SolvePuzzle(int part = 0, bool loadInput = true)
        {
            StringBuilder result = new StringBuilder();
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
                result.AppendLine(SolvePuzzlePartOne());
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
                result.AppendLine(SolvePuzzlePartTwo());
                watch.Stop();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Calctime: {watch.ElapsedMilliseconds:N0} ms");

                Console.ResetColor();
                Console.WriteLine();
            }

            return result.ToString();
        }

        protected virtual void DoPreparations()
        { }

        protected virtual string SolvePuzzlePartOne()
        {
            //string res = "tba";
            //Console.WriteLine($"{res}");
            return "tba";
        }

        protected virtual string SolvePuzzlePartTwo()
        {
            //string res = "tba";
            //Console.WriteLine($"{res}");
            return "tba";
        }

        public int GetYear()
        {
            return GetYear(this.GetType().Name);
        }

        public int GetDay()
        {
            return GetDay(this.GetType().Name);
        }

        private static int GetValueFromName(string name, string key)
        {
            string result = string.Empty;
            
            int start = name.IndexOf(key) + key.Length;
            result = new string(name.Substring(start).TakeWhile(c => char.IsDigit(c)).ToArray());

            if (int.TryParse(result,out int value))
                return value;

            return -1;
        }

        public static int GetYear(string name)
        {
            string key = "Puzzle";
            return GetValueFromName(name, key);
        }

        public static int GetDay(string name)
        {
            string key = "Day";
            return GetValueFromName(name, key);
        }

        public static int GetYear(Type type)
        {
            return GetYear(type.Name);
        }

        public static int GetDay(Type type)
        {
            return GetDay(type.Name);
        }

        public static List<PuzzleBase> GetPuzzles(int year = 0, int day = 0)
        {
            List<PuzzleBase> puzzles = new List<PuzzleBase>();

            foreach (var item in ReflectiveEnumerator.FindDerivedTypes(Assembly.GetExecutingAssembly(), typeof(PuzzleBase)))
            {
                if ((year == 0 || year == GetYear(item)) && (day == 0 || day == GetDay(item)))
                    puzzles.Add((PuzzleBase)Activator.CreateInstance(item));
            }

            return puzzles;
        }

        public static PuzzleBase GetPuzzle(int year, int day)
        {
            return GetPuzzles(year, day).OrderBy(x => x.Year * 100 + x.Day).FirstOrDefault();
        }

        #endregion

    }
}
