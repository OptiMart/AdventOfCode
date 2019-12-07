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
        private List<Point> _crossings;

        #endregion

        #region Constructor
        public Day03() : base(2019, 3)
        { }

        #endregion

        #region Methods
        public override int SolvePuzzle(int part = 0)
        {
            DigestInput();
            GetAllIntersections();

            return GetMinDistance();
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
            Line add = new Line(start, vector);
            list.AddLast(add);
        }

        private void GetAllIntersections()
        {
            _crossings = new List<Point>();

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
                    var inter = lineA.GetIntersection(lineB);

                    if (inter != null && !(inter.PointX == 0 && inter.PointY == 0))
                    {
                        _crossings.Add(inter);
                    }
                }
            }
        }

        private int GetMinDistance()
        {
            return _crossings.Min(x => x.ManhattanDistance);
        }

        #endregion
    }
}
