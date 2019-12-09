using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.SpaceImage
{
    public class Image
    {
        #region Constructor
        public Image() : this(0, 0)
        { }

        public Image(int width, int heigth) : this(width, heigth, string.Empty)
        {

        }

        public Image(int width, int heigth, string data)
        {
            ImageWidth = width;
            ImageHeight = heigth;
            InitializeImage();
            if (!string.IsNullOrEmpty(data))
                LoadImageData(data);
        }

        #endregion

        #region Properties
        public int ImageWidth { get; private set; }
        public int ImageHeight { get; private set; }
        public int PixelCount => ImageWidth * ImageHeight;
        public List<ImageLayer> Layers { get; private set; }
        public int LayerCount => Layers.Count;

        #endregion

        #region Methods
        public void InitializeImage()
        {
            if (Layers is null)
                Layers = new List<ImageLayer>();
            else
                Layers.Clear();
        }

        public void LoadImageData(string data)
        {

            if (data.Length % (PixelCount) != 0)
                throw new ArgumentOutOfRangeException(nameof(data), "Anzahl Segmente kein vielfaches von Pixelanzahl");

            int maxLayers = data.Length / PixelCount;

            for (int i = 0; i < maxLayers; i++)
            {
                var layer = AddLayer(data.Substring(i * PixelCount, PixelCount));

                //for (int w = 0; w < ImageWidth; w++)
                //{
                //    for (int h = 0; h < ImageHeight; h++)
                //    {
                //        if (!int.TryParse(dat[i * PixelCount + h * ImageWidth + w], out layer.Pixels[w, h]))
                //            throw new InvalidCastException($"Ungültige Pixelinformation an Position {h * ImageWidth + w}");
                //    }
                //}
            }
        }

        public ImageLayer AddLayer(string data)
        {
            ImageLayer newLayer = new ImageLayer(ImageWidth, ImageHeight, LayerCount, data);
            Layers.Add(newLayer);
            return newLayer;
        }

        public ImageLayer GetLayerFewestInt(int number)
        {
            ImageLayer result = null;
            int min = int.MaxValue;

            foreach (var layer in Layers)
            {
                int count = layer.CountIntegers(number);

                if (count < min)
                {
                    result = layer;
                    min = count;
                }
            }

            return result;
        }

        public ImageLayer AggregateAllLayers()
        {
            ImageLayer result = new ImageLayer(ImageWidth, ImageHeight, -1);

            for (int w = 0; w < ImageWidth; w++)
            {
                for (int h = 0; h < ImageHeight; h++)
                {
                    int pixel = 2;
                    for (int l = 0; l < LayerCount; l++)
                    {
                        pixel = Layers[l].Pixels[w, h];

                        if (pixel != 2)
                            break;
                    }
                    result.Pixels[w, h] = pixel;
                }
            }

            return result;
        }

        #endregion
    }
}
