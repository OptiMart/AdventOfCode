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
            return 0;
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
            for (int i = 0; i < _lines.Count - 1; i++)
            {
                for (int n = i + 1; n < _lines.Count - 1; n++)
                {
                    FindIntersections(_lines[i], _lines[n]);
                }
            }
        }

        private void FindIntersections(LinkedList<Line> wireA, LinkedList<Line> wireB)
        {
            foreach (var lineA in wireA)
            {
                foreach (var lineB in wireB.Where(x => x.HasIntersection(lineA)))
                {

                }
            }
        }

        #endregion
    }
}
