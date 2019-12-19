using System;
using AoC.AdventOfCode.Puzzle.Base;
using AoC.AdventOfCode.Puzzle.Year2019;
using AoCUnitTest.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoCUnitTest.Results
{
    [TestClass]
    [TestCategory("Y2019")]
    [TestCategory("Day01")]
    public class ResultTestYear2019Day01 : ResultTestBase
    {
        public ResultTestYear2019Day01() : base()
        {
            //Puzzle = new Puzzle2019Day01();
            //Input = "118997\r\n63756\r\n124972\r\n141795\r\n111429\r\n53536\r\n50522\r\n143985\r\n62669\r\n77518\r\n60164\r\n72698\r\n123145\r\n57693\r\n87138\r\n82831\r\n53289\r\n60110\r\n115660\r\n51217\r\n117781\r\n81556\r\n103963\r\n89000\r\n109330\r\n100487\r\n136562\r\n145020\r\n140554\r\n102425\r\n93333\r\n75265\r\n55764\r\n70093\r\n73800\r\n81349\r\n141055\r\n56441\r\n141696\r\n89544\r\n106152\r\n98674\r\n100882\r\n137932\r\n88008\r\n149027\r\n92767\r\n113740\r\n79971\r\n85741\r\n126630\r\n75626\r\n125042\r\n69237\r\n147069\r\n60786\r\n63751\r\n144363\r\n81873\r\n107230\r\n90789\r\n81655\r\n144004\r\n74536\r\n126675\r\n147470\r\n123359\r\n68081\r\n136423\r\n94629\r\n58263\r\n122420\r\n143933\r\n148528\r\n129120\r\n78391\r\n74289\r\n106795\r\n143640\r\n59108\r\n64462\r\n78216\r\n56113\r\n64708\r\n82372\r\n115231\r\n74229\r\n130979\r\n83590\r\n76666\r\n93156\r\n138450\r\n71077\r\n128048\r\n65476\r\n85804\r\n145692\r\n106836\r\n70016\r\n113158";
        }

        [TestMethod]
        [TestCategory("Part1")]
        public void SolvePuzzle_SettingsPartOne_Good()
        {
            // Arrange
            Part = 1;
            int expected = 3256114;

            // Act
            Puzzle.LoadPuzzleInput(Input);
            var result = Puzzle.SolvePuzzle(Part, false);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Part2")]
        public void SolvePuzzle_SettingsPartTwo_Good()
        {
            // Arrange
            Part = 2;
            int expected = 4881302;

            // Act
            Puzzle.LoadPuzzleInput(Input);
            var result = Puzzle.SolvePuzzle(Part, false);

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}
