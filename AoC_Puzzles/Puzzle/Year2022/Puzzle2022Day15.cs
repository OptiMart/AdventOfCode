using AoC.Puzzles.Common.Base.Points;
using AoC.Puzzles.Common.IntCodeComputer.Instructions;
using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2022
{
    /// <summary>
    /// Beacon Exclusion Zone
    /// </summary>
    public class Puzzle2022Day15 : PuzzleBase
    {
        #region Data
        List<Sensor> Sensors = new List<Sensor>();

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();

            string testinput = @"Sensor at x=2, y=18: closest beacon is at x=-2, y=15
Sensor at x=9, y=16: closest beacon is at x=10, y=16
Sensor at x=13, y=2: closest beacon is at x=15, y=3
Sensor at x=12, y=14: closest beacon is at x=10, y=16
Sensor at x=10, y=20: closest beacon is at x=10, y=16
Sensor at x=14, y=17: closest beacon is at x=10, y=16
Sensor at x=8, y=7: closest beacon is at x=2, y=10
Sensor at x=2, y=0: closest beacon is at x=2, y=10
Sensor at x=0, y=11: closest beacon is at x=2, y=10
Sensor at x=20, y=14: closest beacon is at x=25, y=17
Sensor at x=17, y=20: closest beacon is at x=21, y=22
Sensor at x=16, y=7: closest beacon is at x=15, y=3
Sensor at x=14, y=3: closest beacon is at x=15, y=3
Sensor at x=20, y=1: closest beacon is at x=15, y=3";
            foreach (var line in PuzzleItems)
            //foreach (var line in testinput.Split(Environment.NewLine))
            {
                MatchCollection matches = Regex.Matches(line, @"\d+");

                if (matches.Count < 4)
                    continue;

                Sensors.Add(new Sensor(
                    int.Parse(matches[0].Value),
                    int.Parse(matches[1].Value),
                    int.Parse(matches[2].Value),
                    int.Parse(matches[3].Value)));
            }

            //Sensor test = new(15, 27, 14, 33);
            //var res = test.GetCoordsXWithoutBeacon(5);
        }

        protected override string SolvePuzzlePartOne()
        {
            long result = 0;
            int y = 2000000;
            
            List<Tuple<long, long>> test1 = new();
            List<int> test2 = new();

            foreach (var sensor in Sensors)
            {
                //var tup = sensor.GetCoordsXWithoutBeacon(y);
                //if (tup == null) continue;

                test1.Add(sensor.GetCoordsXWithoutBeacon(y));
                test2.AddRange(sensor.GetXCoordinatesWithoutBeacon(y));
            }

            //long min = Sensors.Where(x => x.GetMinX(y) != null).Min(x => x.GetMinX(y).Value);
            //long max = Sensors.Where(x => x.GetMinX(y) != null).Max(x => x.GetMaxX(y).Value);
            long min = test1.Where(x => x != null).Min(x => x.Item1);
            long max = test1.Where(x => x != null).Max(x => x.Item2);

            for (long x = min; x <= max; x++)
            {
                //if (Sensors.Any(a => a.IsInRange(x, y)) && !Sensors.Any(a => a.Beacon.X == x && a.Beacon.Y == y))
                //{
                //    result++;
                //}

                if (test1.Where(a => a != null).Any(a => a.Item1 <= x && x <= a.Item2) && !Sensors.Any(a => a.Beacon.X == x && a.Beacon.Y == y))
                {
                    result++;
                }
            }


            result = test2.Distinct().Count();

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        #endregion

    }

    [DebuggerDisplay("{X} / {Y} - {Range}")]
    internal class Sensor : BasePoint2D<long>
    {
        public Sensor(int x, int y, int bx, int by) : base(0)
        {
            X = x;
            Y = y;
            Beacon = new BasePoint2D<int>(0, bx, by);
            Value = GetManhattanDistance(Beacon);
        }

        public BasePoint2D<int> Beacon { get; set; }

        public Tuple<long, long>? GetCoordsXWithoutBeacon(int coordY)
        {
            if (!IsInRange(X, coordY))
                return null;

            long distx = Value - Math.Abs(coordY - Y);
            long startx = X - distx;

            //result.AddRange(Enumerable.Range((int)startx, (int)restx * 2 + 1));

            return new Tuple<long, long>(startx, startx + distx * 2);
        }

        public List<int> GetXCoordinatesWithoutBeacon(int coordY)
        {
            List<int> result = new List<int>();

            if (!IsInRange(X, coordY))
                return result;

            long distx = Value - Math.Abs(coordY - Y);
            long startx = X - distx;

            result.AddRange(Enumerable.Range((int)startx, (int)distx * 2 + 1));

            return result;
        }

        public long? GetMinX(int y)
        {
            long maxDist = GetManhattanDistance(Beacon);
            long disty = Math.Abs(y - Y);

            if (maxDist < disty)
                return null;

            return X - GetManhattanDistance(Beacon) - disty;
        }


        public long? GetMaxX(int y)
        {
            long maxDist = GetManhattanDistance(Beacon);
            long disty = Math.Abs(y - Y);

            if (maxDist < disty)
                return null;

            return X + GetManhattanDistance(Beacon) - disty;
        }

        public bool IsInRange(long x, long y)
        {
            return Math.Abs(X - x) + Math.Abs(Y - y) <= Value;
        }
    }
}
