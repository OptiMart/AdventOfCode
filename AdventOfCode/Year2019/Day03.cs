using AoC.AdventOfCode.Base;
using AoC.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Year2019
{
    class Day03 : PuzzleBase
    {
        #region Data
        private List<LinkedList<Line>> _lines;
        private List<Tuple<Point, int>> _crossings;

        #endregion

        #region Constructor
        public Day03() : base(2019, 3)
        { }

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            DigestInput();
            GetAllIntersections();
        }
        protected override int SolvePuzzlePartOne()
        {
            int res = GetMinManhattanDistance();
            Console.WriteLine($"{res}");
            return res;
        }

        protected override int SolvePuzzlePartTwo()
        {
            int res = GetMinWireDistance();
            Console.WriteLine($"{res}");
            return res;
        }

        private void DigestInput()
        {
            _lines = new List<LinkedList<Line>>();
            var wires = PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (var wire in wires)
            {
                LinkedList<Line> path = new LinkedList<Line>();

                var lines = wire.Split(',');

                foreach (var line in lines)
                {
                    AddNewLine(path, line);
                }

                _lines.Add(path);
            }
        }

        private void AddNewLine(LinkedList<Line> list, string vector)
        {
            Point start = list.Last?.Value.EndPoint ?? new Point();
            Line add = new Line(start, vector, list.Last?.Value.TotalDistance ?? 0);
            list.AddLast(add);
        }

        private void GetAllIntersections()
        {
            _crossings = new List<Tuple<Point, int>>();

            for (int i = 0; i < _lines.Count; i++)
            {
                for (int n = i + 1; n < _lines.Count; n++)
                {
                    FindIntersections(_lines[i], _lines[n]);
                }
            }
        }

        private void FindIntersections(LinkedList<Line> wireA, LinkedList<Line> wireB)
        {
            foreach (var lineA in wireA)
            {
                foreach (var lineB in wireB)
                {
                    var intersection = lineA.GetIntersection(lineB);

                    if (intersection != null && !(intersection.Item1.PointX == 0 && intersection.Item1.PointY == 0))
                    {
                        _crossings.Add(intersection);
                    }
                }
            }
        }

        private int GetMinManhattanDistance()
        {
            return _crossings.Min(x => x.Item1.ManhattanDistance);
        }

        private int GetMinWireDistance()
        {
            return _crossings.Min(x => x.Item2);
        }

        #endregion
    }
}
