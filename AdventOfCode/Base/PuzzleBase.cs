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
        Delegate DelSolver;

        #region Constructor
        protected PuzzleBase() : this(0, 0)
        { }

        protected PuzzleBase(int year, int day)
        {
            Year = year;
            Day = day;
        }

        #endregion

        public int Year { get; private set; }
        public int Day { get; private set; }
        public string PuzzleInput { get; set; }

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

        public virtual int SolvePuzzle(int part = 0)
        {
            return 0;
        }

        public delegate int DelSolvePuzzle(int part);
    }
}
