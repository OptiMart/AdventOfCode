using AoC.AdventOfCode.Common.IntCodeComputer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.RepairDroid
{
    public class RepairDroid : Computer
    {
        private int xOffset = 21;
        private int yOffset = 21;
        private int minX;
        private int maxX;
        private int minY;
        private int maxY;

        #region Constructor
        public RepairDroid(string program) : base(program)
        {
            LoadDefaultInstructionSet();
        }

        #endregion

        #region Properties
        public List<MapLocation> Map { get; private set; }
        public MapLocation MapPosition { get; private set; }

        #endregion

        #region Methods
        public void InitializeMap()
        {
            MapPosition = new MapLocation()
            {
                CoordX = 21,
                CoordY = 21,
                Tile = MapTile.Start,
            };

            Map = new List<MapLocation>()
            {
                MapPosition
            };


        }

        public void CheckMap(bool visual = true)
        {
            InitializeMap();
            long totalMoves = 0;

            bool allChecked = false;

            if (visual)
                Console.Clear();

            do
            {
                var target = FindUnkownSpot();

                if (visual)
                {
                    PaintInfo(target, true);
                    System.Threading.Thread.Sleep(20);
                }

                Map.ForEach(x => x.PathFinding = int.MaxValue);
                MapPosition.PathFinding = 0;
                var test = MapPosition.FindWayToDestination(target, true);

                //var test = MapPosition.NextSearchDirection();

                foreach (var item in test)
                {
                    totalMoves++;
                    MoveDirection(item, visual);
                    System.Threading.Thread.Sleep(0);
                }

                if (!test.Any())
                    allChecked = true;

            } while (!allChecked);
            totalMoves++;
        }

        public int FindShortestWay()
        {
            var start = Map.FirstOrDefault(x => x.Tile == MapTile.Start);
            var target = Map.FirstOrDefault(x => x.Tile == MapTile.OxygenSystem);

            Map.ForEach(x => x.PathFinding = int.MaxValue);
            start.PathFinding = 0;
            var way = start.FindWayToDestination(target, false);
            return way.Count;

        }

        public int GetFarthestOxygenDistance()
        {
            var oxygen = Map.FirstOrDefault(x => x.Tile == MapTile.OxygenSystem);

            Map.ForEach(x => x.PathFinding = int.MaxValue);
            oxygen.PathFinding = 0;
            var maxPoint = FindFarthestPoint(oxygen);

            Map.ForEach(x => x.PathFinding = int.MaxValue);
            oxygen.PathFinding = 0;
            return oxygen.FindWayToDestination(maxPoint, false).Count;
        }

        public MapLocation FindFarthestPoint(MapLocation point)
        {
            int maxDistance = 0;
            MapLocation result = null;

            foreach (var item in Map.Where(x => x.Tile != MapTile.Wall))
            {
                Map.ForEach(x => x.PathFinding = int.MaxValue);
                item.PathFinding = 0;
                var test = item.FindWayToDestination(point, false);

                if (test.Count > maxDistance)
                {
                    maxDistance = test.Count;
                    result = item;
                }
            }

            return result;
        }

        private MapLocation FindUnkownSpot()
        {
            int minDistance = int.MaxValue;
            int minMoves = int.MaxValue;
            MapLocation result = null;

            foreach (var item in Map.Where(x => x.Tile != MapTile.Wall && x.NextUnknownNeighbor() != MapDirection.None))
            {
                int manhDist = item.GetManhattanDistance(MapPosition.CoordX, MapPosition.CoordY);

                if (manhDist < minDistance)
                {
                    Map.ForEach(x => x.PathFinding = int.MaxValue);
                    item.PathFinding = 0;
                    int moves = item.FindWayToDestination(MapPosition, false).Count;

                    if (moves == 0)
                        return item;

                    if (moves < minMoves)
                    {
                        minMoves = moves;
                        minDistance = manhDist;
                        result = item;
                    }
                }
            }

            return result;
        }

        private void MoveDirection(MapDirection direction, bool visual = false)
        {
            PushInput((int)direction);
            var opCode = StartExecution();

            if (opCode == 3 && OutputStack.Count == 1)
            {
                var moveResult = PopOutput();
                if (!(moveResult is null))
                    AnalyseMoveResult(direction, (long)moveResult, visual);
            }
        }

        private void AnalyseMoveResult(MapDirection direction, long result, bool visual = false)
        {
            GetDestinationCoords(direction, out int newX, out int newY);
            var wellKnown = MapPosition.Neighbors.FirstOrDefault(x => x.Direction == direction);
            var nextHop = Map.FirstOrDefault(x => x.CoordX == newX && x.CoordY == newY);

            if (wellKnown != null && nextHop != null && nextHop != wellKnown.Location)
                throw new DataMisalignedException("Map Error");

            if (wellKnown is null)
            {
                if (nextHop is null)
                {
                    nextHop = new MapLocation()
                    {
                        CoordX = newX,
                        CoordY = newY,
                        Tile = (MapTile)result,
                    };
                    Map.Add(nextHop);
                }
                //MapPosition.Neighbors.Add(new MapNeighbor()
                //{
                //    Direction = direction,
                //    Location = nextHop,
                //});
                //nextHop.Neighbors.Add(new MapNeighbor()
                //{
                //    Direction = GetOppisingDirection(direction),
                //    Location = MapPosition,
                //});
                UpdateNeighbors(nextHop);
            }
            else
            {
            }

            if (nextHop.Tile != MapTile.Wall)
            {
                var oldSpot = MapPosition;
                MapPosition = nextHop;

                if (visual)
                {
                    PaintInfo(oldSpot);
                    PaintInfo(MapPosition);
                }
            }
            else if (visual)
            {
                PaintInfo(nextHop);
            }
        }

        private void UpdateNeighbors(MapLocation newLocation)
        {
            foreach (var item in Map.Where(m => Math.Abs(m.CoordX - newLocation.CoordX) == 1 || Math.Abs(m.CoordY - newLocation.CoordY) == 1))
            {
                _ = item.CheckOrAddIfNeighbor(newLocation);
            }
        }

        private void GetDestinationCoords(MapDirection direction, out int x, out int y)
        {
            x = MapPosition.CoordX;
            y = MapPosition.CoordY;

            if (direction == MapDirection.North)
                y--;
            else if (direction == MapDirection.South)
                y++;
            else if (direction == MapDirection.West)
                x--;
            else if (direction == MapDirection.East)
                x++;
        }

        private MapDirection GetOppisingDirection(MapDirection direction)
        {
            if (direction == MapDirection.North)
                return MapDirection.South;
            else if (direction == MapDirection.South)
                return MapDirection.North;
            else if (direction == MapDirection.West)
                return MapDirection.East;
            else if (direction == MapDirection.East)
                return MapDirection.West;

            return 0;
        }

        private void PaintInfo(MapLocation location, bool isTarget = false)
        {
            Console.SetCursorPosition(location.CoordX, location.CoordY);

            if (isTarget)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(GetMapChar(location.Tile));
                Console.SetCursorPosition(location.CoordX, location.CoordY);
            }
            else
            {
                if (location.Tile == MapTile.Wall)
                    Console.BackgroundColor = ConsoleColor.White;
                else
                    Console.BackgroundColor = ConsoleColor.Black;

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(GetMapChar(location.Tile));
                Console.SetCursorPosition(location.CoordX, location.CoordY);
            }

            if (MapPosition == location)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('D');
            }

            Console.SetCursorPosition(0, 0);
            //Console.BackgroundColor = ConsoleColor.Black;
        }

        private char GetMapChar(MapTile mapTile)
        {
            if (mapTile == MapTile.Start)
                return 'S';
            else if (mapTile == MapTile.OxygenSystem)
                return 'O';
            else if (mapTile == MapTile.Empty)
                return '.';
            else if (mapTile == MapTile.Wall)
                return '#';

            return ' ';
        }

        #endregion
    }
}
