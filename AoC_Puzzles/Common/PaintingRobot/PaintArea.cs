using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.PaintingRobot
{
    public class PaintArea
    {
        #region Data
        private readonly List<PaintSpot> paintSpots = new List<PaintSpot>();

        #endregion

        #region Constructor
        public PaintArea()
        { }

        #endregion

        #region Methods
        public PaintColor GetColorFromCoord(int x, int y)
        {
            var spot = paintSpots.FirstOrDefault(v => v.CoordX == x && v.CoordY == y);

            if (spot is null)
            {
                //AddSpot(x, y);
                return PaintColor.Black;
            }

            return spot.Color;
        }

        public void SetColorToCoord(int x, int y, PaintColor color)
        {
            var spot = paintSpots.FirstOrDefault(v => v.CoordX == x && v.CoordY == y);

            if (spot is null)
                AddSpot(x, y, color);
            else
                spot.Color = color;
        }

        private void AddSpot(int x, int y, PaintColor color = PaintColor.Black)
        {
            if (!paintSpots.Any(v => v.CoordX == x && v.CoordY == y))
                paintSpots.Add(new PaintSpot(x, y, color));
        }

        public int CountMarkedSpots()
        {
            return paintSpots.Count;
        }

        public override string ToString()
        {
            int maxX = paintSpots.Max(v => v.CoordX);
            int minX = paintSpots.Min(v => v.CoordX);
            int maxY = paintSpots.Max(v => v.CoordY);
            int minY = paintSpots.Min(v => v.CoordY);

            StringBuilder stringBuilder = new StringBuilder();

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    var spot = paintSpots.FirstOrDefault(v => v.CoordX == x && v.CoordY == y);

                    if (spot is null)
                        stringBuilder.Append('.');
                    else
                        stringBuilder.Append(spot.Color == PaintColor.White ? '#' : '.');
                }
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}
