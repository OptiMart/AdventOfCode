using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Base
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

        public virtual int SolvePuzzle(int part = 0)
        {
            int[] result = new int[] { 0, 0, 0 };

            try
            {
                LoadPuzzleInputFromFile(GetInputPath());
            }
            catch (Exception)
            { 
                // Just continue
            }

            Console.WriteLine($"--- {Year} - Day {Day} ---");
            DoPreparations();
            
            Console.WriteLine($"Result Part 1:");
            result[1] = SolvePuzzlePartOne();
            
            Console.WriteLine($"Result Part 2:");
            result[2] = SolvePuzzlePartTwo();

            return result[part];
        }

        protected virtual void DoPreparations()
        { }

        protected virtual int SolvePuzzlePartOne()
        {
            Console.WriteLine($"tba");
            return 0;
        }

        protected virtual int SolvePuzzlePartTwo()
        {
            Console.WriteLine($"tba");
            return 0;
        }

        #endregion

    }
}
