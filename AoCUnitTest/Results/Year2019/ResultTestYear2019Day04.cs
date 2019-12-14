using System;
using System.IO;
using AoC.AdventOfCode.Puzzle.Base;
using AoC.AdventOfCode.Puzzle.Year2019;
using AoCUnitTest.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoCUnitTest.Results
{
    [TestClass]
    [TestCategory("Y2019")]
    [TestCategory("Day04")]
    public class ResultTestYear2019Day04 : ResultTestBase
    {
        public ResultTestYear2019Day04() : base()
        {
            Day = new Puzzle2019Day04();
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            Input = System.IO.File.ReadAllText(Path.Combine(_filePath + "\\Source\\Inputs\\2019\\Input_Day4.txt"));
        }

        [TestMethod]
        [TestCategory("Part1")]
        public void SolvePuzzle_SettingsPartOne_Good()
        {
            // Arrange
            Part = 1;
            int expected = 1625;

            // Act
            Day.LoadPuzzleInput(Input);
            var result = Day.SolvePuzzle(Part, false);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Part2")]
        public void SolvePuzzle_SettingsPartTwo_Good()
        {
            // Arrange
            Part = 2;
            int expected = 1111;

            // Act
            Day.LoadPuzzleInput(Input);
            var result = Day.SolvePuzzle(Part, false);

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}
