using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Extensions
{
    public static class HashSetExtensions
    {
        public static int ManhattanDistance(this (int, int) item1, (int, int) item2)
        {
            return Math.Abs(item1.Item1 - item2.Item1) + Math.Abs(item1.Item2 - item2.Item2);
        }
    }
}
