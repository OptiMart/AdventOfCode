using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.SpaceMap
{
    public interface ICoord3D
    {
        int X { get; set; }
        int Y { get; set; }
        int Z { get; set; }
    }
}
