using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.SpaceImage
{
    public class ImageLayer
    {
        #region Constructor
        public ImageLayer() : this(0, 0)
        { }

        public ImageLayer(int width, int heigth)
        {
            ImageWidth = width;
            ImageHeight = heigth;
            InitializeImage();
        }
        public ImageLayer(int width, int heigth, int id) : this(width, heigth, id, string.Empty)
        { }

        public ImageLayer(int width, int heigth, int id, string data)
        {
            LayerID = id;
            ImageWidth = width;
            ImageHeight = heigth;
            InitializeImage();

            if (!string.IsNullOrEmpty(data))
                LoadImageData(data);
        }

        #endregion

        #region Properties
        public int LayerID { get; private set; }
        public int ImageWidth { get; private set; }
        public int ImageHeight { get; private set; }
        public int PixelCount => ImageWidth * ImageHeight;
        public int[,] Pixels { get; private set; }

        #endregion

        #region Methods
        public void InitializeImage()
        {
            Pixels = new int[ImageWidth, ImageHeight];
        }

        public void LoadImageData(string data)
        {
            if (data.Length != PixelCount)
                throw new ArgumentOutOfRangeException(nameof(data), $"Ungültige datenlänge. Erwartet {PixelCount}, übergeben {data.Length}");

            for (int w = 0; w < ImageWidth; w++)
            {
                for (int h = 0; h < ImageHeight; h++)
                {
                    if (!int.TryParse(data.Substring(h * ImageWidth + w, 1), out Pixels[w, h]))
                        throw new InvalidCastException($"Ungültige Pixelinformation an Position {h * ImageWidth + w}");
                }
            }
        }

        public int CountIntegers(int number)
        {
            int result = 0;

            for (int w = 0; w < ImageWidth; w++)
            {
                for (int h = 0; h < ImageHeight; h++)
                {
                    if (Pixels[w, h] == number)
                        result++;
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int h = 0; h < ImageHeight; h++)
            {
                for (int w = 0; w < ImageWidth; w++)
                {
                    result.Append(Pixels[w, h]);
                }
                result.AppendLine();
            }

            return result.ToString();
        }

        #endregion
    }
}
