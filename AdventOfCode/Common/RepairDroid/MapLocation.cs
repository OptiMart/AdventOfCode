using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.RepairDroid
{
    public class MapLocation
    {
        public MapTile Tile { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public List<MapNeighbor> Neighbors { get; private set; } = new List<MapNeighbor>();
        public int PathFinding { get; set; } = int.MaxValue;

        #region Methods
        public int GetManhattanDistance(int x, int y)
        {
            return Math.Abs(CoordX - x) + Math.Abs(CoordY - y);
        }

        public MapDirection NextUnknownNeighbor()
        {
            // Search for unknown Naighbor
            foreach (int i in new int[] { 1, 3, 2, 4 })
            {
                if (!Neighbors.Any(x => x.Direction == (MapDirection)i))
                    return (MapDirection)i;
            }

            return MapDirection.None;
        }

        public List<MapDirection> NextSearchDirection()
        {
            List<MapDirection> result = new List<MapDirection>();

            var direct = NextUnknownNeighbor();

            if (direct != MapDirection.None)
            {
                result.Add(direct);
                return result;
            }

            foreach (var item in Neighbors)
            {
                if (item.Location.Tile == MapTile.Wall)
                    continue;
                
                var search = item.Location.NextSearchDirection();

                if (search.Any())
                {
                    result.Add(item.Direction);
                    result.AddRange(search);
                    return result;
                }
            }

            return result;
        }

        public List<MapDirection> FindWayToDestination(MapLocation destination, bool search)
        {
            List<MapDirection> result = new List<MapDirection>();

            if (search && this == destination)
            {
                result.Add(NextUnknownNeighbor());
                return result;
            }

            foreach (var item in Neighbors)
            {
                //if (item.Location == from)
                //    continue;

                if (item.Location.Tile == MapTile.Wall || item.Location.PathFinding <= PathFinding)
                    continue;

                item.Location.PathFinding = PathFinding + 1;

                if (item.Location == destination && !search)
                {
                    result.Add(item.Direction);
                    return result;
                }

                var hops = item.Location.FindWayToDestination(destination, search);

                if (hops.Any())
                {
                    result.Add(item.Direction);
                    result.AddRange(hops);
                    return result;
                }
            }

            return result;
        }
    }

    #endregion
}
