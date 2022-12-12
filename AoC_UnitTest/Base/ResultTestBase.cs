using System;
using System.Collections.Generic;
using System.IO;
using AoC.AdventOfCode.Puzzle.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoCUnitTest.Base
{
    [TestClass]
    [TestCategory("Result")]
    public abstract class ResultTestBase
    {
        private string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

        #region Constructor
        protected ResultTestBase()
        {
            Year = PuzzleBase.GetYear(this.GetType().Name);
            Day = PuzzleBase.GetDay(this.GetType().Name);
            Puzzle = PuzzleHelper.GetPuzzle(Year, Day);

            Input = File.ReadAllText(Path.Combine(_filePath, $@"Debug\Source\Inputs\{Year}\Input_Day{Day:00}.txt"));
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
