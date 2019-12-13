using AoC.AdventOfCode.Common.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.IntCodeComputer
{
    public enum Tiles
    {
        Empty = 0,
        Wall = 1,
        Block = 2,
        HorPaddle = 3,
        Ball = 4,
    }

    public class Arcade : Computer
    {
        #region Data
        private int startCursorX;
        private int startCursorY;

        #endregion

        #region Constructor
        public Arcade(string intCode) : base(intCode)
        {
            LoadDefaultInstructionSet();
        }

        #endregion

        #region Properties
        public List<Point> Points { get; private set; } = new List<Point>();
        public int Score { get; private set; } = 0;

        #endregion

        #region Methods
        public void StartGame(bool display = false)
        {
            if (display)
            {
                startCursorX = Console.CursorLeft;
                startCursorY = Console.CursorTop;
            }

            int res = -1;
            do
            {
                res = StartExecution();
                PrepareDisplay(OutputStack, display);

                var ballX = Points.FirstOrDefault(p => p.Tile == Tiles.Ball)?.PointX;
                var paddX = Points.FirstOrDefault(p => p.Tile == Tiles.HorPaddle)?.PointX;

                if (ballX is null || paddX is null)
                    return;

                int move = ballX < paddX ? -1 : ballX > paddX ? 1 : 0;

                InputStack.AddLast(move);
                //if (display)
                //    System.Threading.Thread.Sleep(1);
            } while (res !=  99);

            if (display)
            {
                Console.SetCursorPosition(0, startCursorY + Points.Max(v => v.PointY) + 1);
            }
        }

        private void PrepareDisplay(LinkedList<long> output, bool display = false)
        {
            do
            {
                int x = (int)output.First();
                output.RemoveFirst();
                int y = (int)output.First();
                output.RemoveFirst();
                int t = (int)output.First();
                output.RemoveFirst();

                if (x < 0)
                {
                    Score = t;
                    if (display)
                    {
                        Console.SetCursorPosition(startCursorX, startCursorY);
                        Console.Write($"{Score,10:#,###,##0} ");
                    }
                }
                else
                {
                    var point = Points.FirstOrDefault(p => p.PointX == x && p.PointY == y);
                    if (point is null)
                        Points.Add(new Point(x, y) { Tile = (Tiles)t });
                    else
                        point.Tile = (Tiles)t;

                    if (display)
                    {
                        Console.SetCursorPosition(startCursorX + x, startCursorY + y);
                        Console.Write(TileToCharConverter((Tiles)t));
                        Console.SetCursorPosition(startCursorX, startCursorY);
                    }
                }
            } while (output.Count != 0);
        }

        private char TileToCharConverter(Tiles tile)
        {
            switch (tile)
            {
                case Tiles.Empty:
                    return ' ';
                case Tiles.Wall:
                    return '#';
                case Tiles.Block:
                    return '.';
                case Tiles.HorPaddle:
                    return '_';
                case Tiles.Ball:
                    return 'o';
                default:
                    break;
            }

            return ' ';
        }

        public override string ToString()
        {
            int maxX = Points.Max(v => v.PointX);
            int minX = Points.Min(v => v.PointX);
            int maxY = Points.Max(v => v.PointY);
            int minY = Points.Min(v => v.PointY);

            StringBuilder stringBuilder = new StringBuilder();

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    var spot = Points.FirstOrDefault(v => v.PointX == x && v.PointY == y);

                    if (spot is null)
                        stringBuilder.Append(' ');
                    else
                        stringBuilder.Append(TileToCharConverter(spot.Tile));
                }
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}
