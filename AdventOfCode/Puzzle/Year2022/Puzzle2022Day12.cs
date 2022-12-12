using AoC.AdventOfCode.Common.Base;
using AoC.AdventOfCode.Common.HillClimbing;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2022
{
    /// <summary>
    /// Hill Climbing Algorithm
    /// </summary>
    public class Puzzle2022Day12 : PuzzleBase
    {
        #region Data
        UniversalMesh<HillSpot> hill = new UniversalMesh<HillSpot>();

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();

            //Console.Clear();
            //Console.ResetColor();
            for (int y = 0; y < PuzzleItems.Count; y++)
            {
                for (int x = 0; x < PuzzleItems[y].Length; x++)
                {
                    GenericNode<HillSpot> node = new GenericNode<HillSpot>(new HillSpot(x, y, PuzzleItems[y][x]));
                    hill.AddNode(node);

                    var prevx = hill.Nodes.FirstOrDefault(a => a.Node.X == node.Node.X - 1 && a.Node.Y == node.Node.Y);
                    var prevy = hill.Nodes.FirstOrDefault(a => a.Node.X == node.Node.X && a.Node.Y == node.Node.Y - 1);

                    if (prevx != null)
                    {
                        prevx.AddNeighbor(node);
                        node.AddNeighbor(prevx);
                    }

                    if (prevy != null)
                    {
                        prevy.AddNeighbor(node);
                        node.AddNeighbor(prevy);
                    }

                    //Console.SetCursorPosition(node.Node.X, node.Node.Y);
                    //Console.Write(node.Node.Value);
                }
            }

            //foreach (var node in hill.Nodes)
            //{
            //    for (int x = -1; x <= 1; x++)
            //    {
            //        for (int y = -1; y <= 1; y++)
            //        {
            //            if (x * y != 0)
            //                continue;

            //            var n = hill.Nodes.FirstOrDefault(a => a.Node.X == node.Node.X + x && a.Node.Y == node.Node.Y + y);
            //            node.AddNeighbor(n);
            //        }
            //    }
            //}
            Console.WriteLine();
        }

        protected override string SolvePuzzlePartOne()
        {
            var start = hill.Nodes.FirstOrDefault(x => x.Node.Value == 'S');
            var end = hill.Nodes.FirstOrDefault(x => x.Node.Value == 'E');

            var test = hill.GetShortestPath(start, end, (t, n) => t.Node.Height + 1 >= n.Node.Height);
            long result = test.Count - 1;

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            var start = hill.Nodes.FirstOrDefault(x => x.Node.Value == 'S');
            var end = hill.Nodes.FirstOrDefault(x => x.Node.Value == 'E');

            var test = hill.GetShortestPath(end, x => x.Node.Value == 'a', (n, t) => t.Node.Height + 1 >= n.Node.Height);
            long result = test.Count - 1;

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        #endregion

    }
}
