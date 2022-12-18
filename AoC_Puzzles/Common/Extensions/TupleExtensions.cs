using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Extensions
{
    public static class TupleExtensions
    {
        public static int ManhattanDistance(this Tuple<int, int> item1, Tuple<int, int> item2)
        {
            return Math.Abs(item1.Item1 - item2.Item1) + Math.Abs(item1.Item2 - item2.Item2);
        }

        public static int ManhattanDistance(this (int, int) item1, (int, int) item2)
        {
            return item1.ToTuple().ManhattanDistance(item2.ToTuple());
        }

    }
}
