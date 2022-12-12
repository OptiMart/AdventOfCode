using System;
using System.Collections.Generic;
using System.Linq;
using AoC.AdventOfCode.Puzzle.Base;
using AoC.AdventOfCode.Puzzle.Year2019;
using AoCUnitTest.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoCUnitTest.Results
{
    [TestClass]
    [TestCategory("Y2019")]
    [TestCategory("Day02")]
    public class ResultTestPuzzle2019Day02 : ResultTestBase
    {
        [TestMethod]
        [TestCategory("Part1")]
        public void SolvePuzzle_SettingsPartOne_Good()
        {
            // Arrange
            Part = 1;
            string expected = "3790645";

            // Act
            Puzzle.LoadPuzzleInput(Input);
            var result = Puzzle.SolvePuzzle(Part, false).FirstOrDefault();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Part2")]
        public void SolvePuzzle_SettingsPartTwo_Good()
        {
            // Arrange
            Part = 2;
            string expected = "6577";

            // Act
            Puzzle.LoadPuzzleInput(Input);
            var result = Puzzle.SolvePuzzle(Part, false).FirstOrDefault();

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}
