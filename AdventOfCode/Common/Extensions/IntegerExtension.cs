using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Extensions
{
    internal static class IntegerExtension
    {
        public static int CrossSum(this long value)
        {
            int count = 0;
            while (value != 0)
            {
                if ((value & 1) == 1) count++;
                value >>= 1;
            }
            return count;
        }
    }
}
