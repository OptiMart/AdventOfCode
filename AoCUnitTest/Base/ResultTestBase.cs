using System;
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
        { }

        #endregion

        #region Properties
        protected PuzzleBase Day;
        protected string Input;
        protected int Part;

        #endregion

    }
}
