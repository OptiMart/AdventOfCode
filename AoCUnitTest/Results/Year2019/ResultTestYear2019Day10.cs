using System;
using AoC.AdventOfCode.Puzzle.Base;
using AoC.AdventOfCode.Puzzle.Year2019;
using AoCUnitTest.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoCUnitTest.Results
{
    [TestClass]
    [TestCategory("Y2019")]
    [TestCategory("Day10")]
    public class ResultTestYear2019Day10 : ResultTestBase
    {
        public ResultTestYear2019Day10() : base()
        {
            Day = new Puzzle2019Day10();
            Input = "..#..###....#####....###........#\r\n.##.##...#.#.......#......##....#\r\n#..#..##.#..###...##....#......##\r\n..####...#..##...####.#.......#.#\r\n...#.#.....##...#.####.#.###.#..#\r\n#..#..##.#.#.####.#.###.#.##.....\r\n#.##...##.....##.#......#.....##.\r\n.#..##.##.#..#....#...#...#...##.\r\n.#..#.....###.#..##.###.##.......\r\n.##...#..#####.#.#......####.....\r\n..##.#.#.#.###..#...#.#..##.#....\r\n.....#....#....##.####....#......\r\n.#..##.#.........#..#......###..#\r\n#.##....#.#..#.#....#.###...#....\r\n.##...##..#.#.#...###..#.#.#..###\r\n.#..##..##...##...#.#.#...#..#.#.\r\n.#..#..##.##...###.##.#......#...\r\n...#.....###.....#....#..#....#..\r\n.#...###..#......#.##.#...#.####.\r\n....#.##...##.#...#........#.#...\r\n..#.##....#..#.......##.##.....#.\r\n.#.#....###.#.#.#.#.#............\r\n#....####.##....#..###.##.#.#..#.\r\n......##....#.#.#...#...#..#.....\r\n...#.#..####.##.#.........###..##\r\n.......#....#.##.......#.#.###...\r\n...#..#.#.........#...###......#.\r\n.#.##.#.#.#.#........#.#.##..#...\r\n.......#.##.#...........#..#.#...\r\n.####....##..#..##.#.##.##..##...\r\n.#.#..###.#..#...#....#.###.#..#.\r\n............#...#...#.......#.#..\r\n.........###.#.....#..##..#.##...";
        }

        [TestMethod]
        [TestCategory("Part1")]
        public void SolvePuzzle_SettingsPartOne_Good()
        {
            // Arrange
            Part = 1;
            int expected = 314;

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
            int expected = 1513;

            // Act
            Day.LoadPuzzleInput(Input);
            var result = Day.SolvePuzzle(Part, false);

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}
