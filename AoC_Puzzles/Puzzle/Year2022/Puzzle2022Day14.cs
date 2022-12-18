using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2022
{
    /// <summary>
    /// Regolith Reservoir
    /// </summary>
    public class Puzzle2022Day14 : PuzzleBase
    {
        #region Data
        private List<(int x, int y, string t)> Cave = new();
        private const string XYPattern = @"(?<x>\-?\d+),(?<y>\-?\d+)";
        private Regex XYRegex = new(XYPattern, RegexOptions.Compiled);
        private int FloorLevel;
        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();

            foreach (var line in PuzzleItems)
            //foreach (var line in "498,4 -> 498,6 -> 496,6\r\n503,4 -> 502,4 -> 502,9 -> 494,9".Split(Environment.NewLine))
            {
                Match start = XYRegex.Match(line);
                Match target = start.NextMatch();
                Cave.Add((int.Parse(start.Groups["x"].Value), int.Parse(start.Groups["y"].Value), "Rock"));

                while (target.Success)
                {
                    Cave.AddRange(GetRockPath((int.Parse(start.Groups["x"].Value), int.Parse(start.Groups["y"].Value)), (int.Parse(target.Groups["x"].Value), int.Parse(target.Groups["y"].Value)), "Rock"));
                    start = target;
                    target = target.NextMatch();
                }

            }

            Cave = Cave.Distinct().OrderBy(a => a.y).ThenBy(a => a.x).ToList();
            FloorLevel = Cave.Max(a => a.y) + 2;
        }

        private IEnumerable<(int x, int y, string t)> GetRockPath((int x, int y) start, (int x, int y) target, string type)
        {
            List<(int x, int y, string t)> result = new();

            int count = Math.Abs(start.x - target.x) + Math.Abs(start.y - target.y);

            if (start.x == target.x)
            {
                if (start.y < target.y)
                    result.AddRange(Enumerable.Range(start.y + 1, count).Select(i => (start.x, i, type)));
                else
                    result.AddRange(Enumerable.Range(target.y, count).Reverse().Select(i => (start.x, i, type)));
            }
            else if (start.y == target.y)
            {
                if (start.x < target.x)
                    result.AddRange(Enumerable.Range(start.x + 1, count).Select(i => (i, start.y, type)));
                else
                    result.AddRange(Enumerable.Range(target.x, count).Reverse().Select(i => (i, start.y, type)));
            }

            return result;
        }

        protected override string SolvePuzzlePartOne()
        {
            long result = 0;
            (int x, int y, string t) sand = new(500, 0, "Sand");
            (int x, int y, string t) test = GetNextSandSpot(sand);

            while (test != (0, 0, null))
            {
                Cave.Add(test);
                //DrawCave();
                test = GetNextSandSpot(sand);
            }
            DrawCave();
            result = Cave.Where(a => a.t == "Sand").Count();

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;
            (int x, int y, string t) sand = new(500, 0, "Sand");
            (int x, int y, string t) test = GetNextSandSpotWithFloor(sand);

            while (test != sand)
            {
                test = GetNextSandSpotWithFloor(sand);
                Cave.Add(test);
                //DrawCave();
            }
            DrawCave();
            result = Cave.Where(a => a.t == "Sand").Count();

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        private (int x, int y, string type) GetNextSandSpot((int x, int y, string type) start)
        {
            var test = Cave.Where(a => a.x == start.x && a.y >= start.y).OrderBy(b => b.y).FirstOrDefault();

            if (test == (0, 0, null))
                return test;

            if (test.y == start.y)
                return start;

            if (test.y > start.y)
            {
                var testl = Cave.FirstOrDefault(a => a.x == test.x - 1 && a.y == test.y);
                if (testl == (0, 0, null))
                    return GetNextSandSpot((start.x - 1, test.y, "test"));

                var testr = Cave.FirstOrDefault(a => a.x == test.x + 1 && a.y == test.y);
                if (testr == (0, 0, null))
                    return GetNextSandSpot((start.x + 1, test.y, "test"));

                //var testleft = GetNextSandSpot((start.x - 1, test.y, "test"));
                //if (testleft == (0, 0, null))
                //    return testleft;

                //if (testleft.y > test.y)
                //    return testleft;

                //var testright = GetNextSandSpot((start.x + 1, test.y, "test"));
                //if (testleft == (0, 0, null))
                //    return testleft;

                //if (testright.y > test.y)
                //    return testright;
            }

            return (test.x, test.y - 1, "Sand");
        }

        private (int x, int y, string type) GetNextSandSpotWithFloor((int x, int y, string type) start)
        {
            var test = Cave.Where(a => a.x == start.x && a.y >= start.y).OrderBy(b => b.y).FirstOrDefault();

            if (test == (0, 0, null))
            {
                Cave.Add((start.x, FloorLevel, "Floor"));
                return GetNextSandSpotWithFloor(start);
            }

            if (test.y == start.y)
                return start;

            if (test.y > start.y)
            {
                var testl = Cave.FirstOrDefault(a => a.x == test.x - 1 && a.y == test.y);
                if (testl == (0, 0, null))
                    return GetNextSandSpotWithFloor((start.x - 1, test.y, "test"));

                var testr = Cave.FirstOrDefault(a => a.x == test.x + 1 && a.y == test.y);
                if (testr == (0, 0, null))
                    return GetNextSandSpotWithFloor((start.x + 1, test.y, "test"));
            }

            return (test.x, test.y - 1, "Sand");

        }

        private void DrawCave()
        {
            int minX = Cave.Min(a => a.x);
            int maxX = Cave.Max(a => a.x);
            int minY = Cave.Min(a => a.y);
            int maxY = Cave.Max(a => a.y);

            Console.ResetColor();
            Console.Clear();
            for (int y = minY; y <= maxY; y++)
            {
                StringBuilder output = new();
                for (int x = minX; x <= maxX; x++)
                {
                    if (Cave.Contains((x, y, "Rock")))
                        output.Append("#");
                    else if (Cave.Contains((x, y, "Sand")))
                        output.Append("o");
                    else
                        output.Append(".");
                }
                Console.WriteLine(output);
            }
        }
        #endregion

    }
}
