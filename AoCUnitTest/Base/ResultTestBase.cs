using System;
using System.IO;
using AoC.AdventOfCode.Puzzle.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoCUnitTest.Base
{
    [TestClass]
    [TestCategory("Result")]
    public abstract class ResultTestBase
    {
        #region Constructor
        protected ResultTestBase()
        {
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            Input = System.IO.File.ReadAllText(Path.Combine(_filePath, "Debug\\Source\\Inputs\\2019\\Input_Day01.txt"));

            Year = PuzzleBase.GetYear(this.GetType().Name);
            Day = PuzzleBase.GetDay(this.GetType().Name);
            Puzzle = PuzzleBase.GetPuzzle(Year, Day);
        }

        #endregion

        [TestInitialize()]
        public virtual void InitTest()
        {
        }


        #region Properties
        protected int Year = 0;
        protected int Day = 0;
        protected PuzzleBase Puzzle;
        protected string Input;
        protected int Part;

        #endregion

    }
}
