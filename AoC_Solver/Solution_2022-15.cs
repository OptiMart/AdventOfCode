using AoC.Puzzles.Common.IntCodeComputer.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AoC.Puzzles.Common.Extensions;

namespace AoC2022
{
    public class Day15
    {
        const string XYPattern = @"x=(?<x>\-?\d+), y=(?<y>\-?\d+)";
        static readonly Regex XYRegex = new Regex(XYPattern, RegexOptions.Compiled);
        List<((int x, int y) sensor, (int x, int y) beacon, DeadZone deadZone)> Readings;
        HashSet<(int x, int y)> Beacons, Sensors, SensorsAndBeacons;
        public Day15()
        {
            Match m;
            string input = @"Sensor at x=2483411, y=3902983: closest beacon is at x=2289579, y=3633785
Sensor at x=3429446, y=303715: closest beacon is at x=2876111, y=-261280
Sensor at x=666423, y=3063763: closest beacon is at x=2264411, y=2779977
Sensor at x=3021606, y=145606: closest beacon is at x=2876111, y=-261280
Sensor at x=2707326, y=2596893: closest beacon is at x=2264411, y=2779977
Sensor at x=3103704, y=1560342: closest beacon is at x=2551409, y=2000000
Sensor at x=3497040, y=3018067: closest beacon is at x=3565168, y=2949938
Sensor at x=1708530, y=855013: closest beacon is at x=2551409, y=2000000
Sensor at x=3107437, y=3263465: closest beacon is at x=3404814, y=3120160
Sensor at x=2155249, y=2476196: closest beacon is at x=2264411, y=2779977
Sensor at x=3447897, y=3070850: closest beacon is at x=3404814, y=3120160
Sensor at x=2643048, y=3390796: closest beacon is at x=2289579, y=3633785
Sensor at x=3533132, y=3679388: closest beacon is at x=3404814, y=3120160
Sensor at x=3683790, y=3017900: closest beacon is at x=3565168, y=2949938
Sensor at x=1943208, y=3830506: closest beacon is at x=2289579, y=3633785
Sensor at x=3940100, y=3979653: closest beacon is at x=2846628, y=4143786
Sensor at x=3789719, y=1225738: closest beacon is at x=4072555, y=1179859
Sensor at x=3939775, y=578381: closest beacon is at x=4072555, y=1179859
Sensor at x=3880152, y=3327397: closest beacon is at x=3404814, y=3120160
Sensor at x=3280639, y=2446475: closest beacon is at x=3565168, y=2949938
Sensor at x=2348869, y=2240374: closest beacon is at x=2551409, y=2000000
Sensor at x=3727441, y=2797456: closest beacon is at x=3565168, y=2949938
Sensor at x=3973153, y=2034945: closest beacon is at x=4072555, y=1179859
Sensor at x=38670, y=785556: closest beacon is at x=311084, y=-402911
Sensor at x=3181909, y=2862960: closest beacon is at x=3565168, y=2949938
Sensor at x=3099490, y=3946226: closest beacon is at x=2846628, y=4143786";
            Readings = new List<((int x, int y) sensor, (int x, int y) beacon, DeadZone deadZone)>();
            foreach (var line in input.Split(Environment.NewLine))
            {
                m = XYRegex.Match(line);
                if (!m.Success) throw new ApplicationException("Can't parse XY");
                (int x, int y) sensor, beacon;
                sensor = (int.Parse(m.Groups["x"].Value), int.Parse(m.Groups["y"].Value));
                m = m.NextMatch();
                if (!m.Success) throw new ApplicationException("Can't parse XY");
                beacon = (int.Parse(m.Groups["x"].Value), int.Parse(m.Groups["y"].Value));
                Readings.Add((sensor, beacon, new DeadZone(sensor, beacon)));
            }
            Beacons = new HashSet<(int x, int y)>(Readings.Select(x => x.beacon));
            Sensors = new HashSet<(int x, int y)>(Readings.Select(x => x.sensor));
            SensorsAndBeacons = new HashSet<(int x, int y)>(Beacons.Union(Sensors));
            Part1();
            Part2();
        }
        public static int BuildDiamond((int x, int y) a, (int x, int y) b) => Math.Abs(b.x - a.x) + Math.Abs(b.y - a.y);
        void Part1()
        {
            const int YToCount = 2_000_000;//10;//
            var deadZones = new List<(int startX, int endX)>();
            foreach (var reading in Readings)
            {
                int distance = reading.sensor.ManhattanDistance(reading.beacon);
                Console.WriteLine($"S: {reading.sensor.x},{reading.sensor.y}, B: {reading.beacon.x},{reading.beacon.y}, D: {distance}");
                if (reading.deadZone.YAxes.Contains(YToCount)) deadZones.Add(reading.deadZone.XAtY(YToCount));
            }
            var result = DeadXCount(deadZones, new HashSet<int>(SensorsAndBeacons.Where(x => x.y == YToCount).Select(x => x.x)));
            Console.WriteLine($"Dead zones at {YToCount}: {result.count}");
        }
        void Part2()
        {
            const int MultiplyX = 4_000_000;
            const int MaxXY = 4_000_000;
            var deadZones = new List<(int startX, int endX)>();
            for (int y = MaxXY; y >= 0; --y)
            {
                deadZones.Clear();
                foreach (var reading in Readings)
                {
                    if (reading.deadZone.HasXInRangeAtY(y, 0, MaxXY)) deadZones.Add(reading.deadZone.XAtY(y, 0, MaxXY));
                }
                var excludeX = new HashSet<int>(SensorsAndBeacons.Where(x => x.y == y).Select(x => x.x));
                var countResult = DeadXCount(deadZones, excludeX);
                var result = countResult.count + excludeX.Count;
                if (result <= MaxXY)
                {
                    Console.WriteLine($"Possible at y {y}, gap at {countResult.lastGapX}, result: {((long)countResult.lastGapX * (long)MultiplyX) + (long)y}");
                    break;
                }
            }
        }
        (int count, int lastGapX) DeadXCount(List<(int startX, int endX)> deadLines, HashSet<int> excludedX)
        {
            int result = 0, lastGap = -1;
            var ordered = deadLines.OrderBy(x => x.startX).ThenBy(x => x.endX).ToList();
            (int startX, int endX) previous = (int.MinValue, int.MinValue);
            var nonOverlapping = new List<(int startX, int endX)>();
            foreach (var line in ordered)
            {
                if (line.startX > previous.endX)
                {
                    // no overlap
                    if (line.startX - previous.endX > 1)
                    {
                        lastGap = previous.endX + 1;
                    }
                    nonOverlapping.Add((line.startX, line.endX));
                    previous = line;
                }
                else if (line.endX > previous.endX)
                {
                    nonOverlapping.Add((previous.endX + 1, line.endX));
                    previous = line;
                }
                else
                {
                    //Console.WriteLine($"Skipping {line.startX}->{line.endX} because it falls within the previous");
                }
            }
            foreach (var line in nonOverlapping)
            {
                int lineCount = (line.endX - line.startX) + 1;
                foreach (var x in excludedX)
                {
                    if (line.startX <= x && line.endX >= x)
                    {
                        --lineCount;
                    }
                }
                result += lineCount;
            }
            return (result, lastGap);
        }
    }
    public class DeadZone
    {
        public int Radius { get; private set; }
        public (int x, int y) Sensor { get; private set; }
        public (int x, int y) Beacon { get; private set; }
        public (int x, int y) Top { get; private set; }
        public (int x, int y) Right { get; private set; }
        public (int x, int y) Bottom { get; private set; }
        public (int x, int y) Left { get; private set; }
        public HashSet<int> YAxes { get; private set; }
        public DeadZone((int x, int y) sensor, (int x, int y) beacon)
        {
            Sensor = sensor;
            Beacon = beacon;
            Radius = sensor.ManhattanDistance(beacon);
            Top = (sensor.x, sensor.y - Radius);
            Right = (sensor.x + Radius, beacon.y);
            Bottom = (sensor.x, sensor.y + Radius);
            Left = (sensor.x - Radius, sensor.y);
            YAxes = new HashSet<int>();
            for (int y = Top.y; y <= Bottom.y; ++y)
            {
                YAxes.Add(y);
            }
        }
        public bool HasXInRangeAtY(int y, int minX, int maxX)
        {
            if (YAxes.Contains(y))
            {
                int localRadius = Radius - Math.Abs(Sensor.y - y);
                int startX = Sensor.x - localRadius, endX = Sensor.x + localRadius;
                return startX <= maxX && endX >= minX;
            }
            return false;
        }
        public (int startX, int endX) XAtY(int y)
        {
            if (!YAxes.Contains(y)) throw new ArgumentException($"We don't have a dead zone at Y {y}");
            int localRadius = Radius - Math.Abs(Sensor.y - y);
            int startX = Sensor.x - localRadius, endX = Sensor.x + localRadius;
            return (startX, endX);
        }
        public (int startX, int endX) XAtY(int y, int minX, int maxX)
        {
            if (!YAxes.Contains(y)) throw new ArgumentException($"We don't have a dead zone at Y {y}");
            int localRadius = Radius - Math.Abs(Sensor.y - y);
            int startX = Sensor.x - localRadius, endX = Sensor.x + localRadius;
            if (startX <= maxX && endX >= minX)
            {
                return (Math.Max(startX, minX), Math.Min(endX, maxX));
            }
            else
            {
                throw new ArgumentException($"Out of range of Min/Max");
            }
        }
    }
}
