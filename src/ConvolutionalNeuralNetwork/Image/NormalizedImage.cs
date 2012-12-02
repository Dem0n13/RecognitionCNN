using System;
using System.Drawing;
using Recognition.NeuralNet;
using Recognition.Utils;

namespace Recognition.Image
{
    public sealed class NormalizedImage : GreyScaleImage<double>
    {
        public override double BackgroundPixel
        {
            get { return -1.0; }
        }

        public override double ForegroundPixel
        {
            get { return 1.0; }
        }

        #region Конструкторы

        public NormalizedImage(MNistImage srcImage)
        {
            Debug.Assert(srcImage != null);
            Debug.Assert(srcImage.Label != null);
            Debug.AssertNotNull(srcImage.RawData);

            InitializeCanvas(srcImage.Width, srcImage.Height);
            Label = srcImage.Label;

            // каждый пиксел исходного изображения:
            // сужаем цветовой спектр до 0-2 и смещаем фон
            for (var y = 0; y < RawData.Length; y++)
            {
                for (var x = 0; x < RawData[y].Length; x++)
                {
                    RawData[y][x] = srcImage.RawData[y][x]/127.5 - 1.0;
                }
            }
        }

        public NormalizedImage(Bitmap srcImage)
        {
            Debug.Assert(srcImage != null);

            InitializeCanvas(srcImage.Width, srcImage.Height);

            // каждый пиксел исходного изображения:
            // сужаем цветовой спектр до 0-2 и смещаем фон
            for (var y = 0; y < RawData.Length; y++)
            {
                for (var x = 0; x < RawData[y].Length; x++)
                {
                    var srcPixel = srcImage.GetPixel(x, y);
                    var convertedPixel = -2.0*srcPixel.GetBrightness() + 1;
                    RawData[y][x] = convertedPixel;
                }
            }
        }

        public NormalizedImage(Layer srcLayer)
        {
            Debug.AssertNotNull(srcLayer);
            Debug.AssertNotNull(srcLayer.Neurons);
            Debug.Assert(srcLayer.Neurons.Length > 0);

            var neurons = srcLayer.Neurons;
            const int maxRowsInColumn = 25;

            // подсчет количества строк и столбцов в изображении
            var rowCount = Math.Min(maxRowsInColumn, neurons.Length);
            var columnsCount = (int) Math.Ceiling((double) neurons.Length/maxRowsInColumn);

            // инициализируем новое поле, размеры которого вмещают в себя матрицу всех изображений с отступами
            InitializeCanvas(2*columnsCount, 2*rowCount);

            for (int y = 0, n = 0; y < rowCount; y++)
            {
                for (var x = 0; x < columnsCount && n < neurons.Length; x++, n++)
                {
                    RawData[2*y + 1][2*x + 1] = neurons[n].Output;
                }
            }
        }

        public NormalizedImage(Layer2D srcLayer)
        {
            Debug.AssertNotNull(srcLayer);
            Debug.AssertNotNull(srcLayer.Neurons2D);

            InitializeCanvas(srcLayer.Width, srcLayer.Height);

            for (var y = 0; y < RawData.Length; y++)
            {
                for (var x = 0; x < RawData[y].Length; x++)
                {
                    RawData[y][x] = srcLayer.Neurons2D[y][x].Output;
                }
            }
        }

        public NormalizedImage(ConvolutionalLayer srcLayer)
        {
            Debug.AssertNotNull(srcLayer);
            Debug.AssertNotNull(srcLayer.FeatureMaps);
            Debug.Assert(srcLayer.FeatureMaps.Length > 0);

            const int maxRowsInColumn = 10;
            var featureMaps = srcLayer.FeatureMaps;

            // подсчет количества строк и столбцов в изображении
            var rowCount = Math.Min(maxRowsInColumn, featureMaps.Length);
            var columnsCount = (int) Math.Ceiling((double) featureMaps.Length/maxRowsInColumn);

            // инициализируем новое поле, размеры которого вмещают в себя матрицу всех изображений с отступами
            InitializeCanvas((featureMaps[0].Width + 1)*columnsCount - 1,
                                 (featureMaps[0].Height + 1)*rowCount - 1);

            for (int y = 0, fm = 0; y < rowCount; y++)
            {
                for (var x = 0; x < columnsCount && fm < featureMaps.Length; x++, fm++)
                {
                    var image = new NormalizedImage(featureMaps[fm]);
                    ArrayHelper<double>.CopyData(image.RawData, RawData, y*(image.Height + 1), x*(image.Width + 1));
                }
            }
        }

        #endregion

        public void PadCanvas(int newWidth, int newHeight)
        {
            Debug.Assert(newWidth >= Width);
            Debug.Assert(newHeight >= Height);
            
            if (Width == newWidth && Height == newHeight) return;

            var oldData = RawData;
            var oldWidth = Width;
            var oldHeight = Height;

            InitializeCanvas(newWidth, newHeight);
            ArrayHelper<double>.CopyData(oldData, RawData, newHeight - oldHeight, newWidth - oldWidth);
        }

        protected override Color PixelToColor(double pixel)
        {
            // значение пиксела может быть масштабировано
            pixel = Math.Max(BackgroundPixel, pixel);
            pixel = Math.Min(ForegroundPixel, pixel);

            var grayValue = (byte) (127.5*(1.0 - pixel));
            return Color.FromArgb(255, grayValue, grayValue, grayValue);
        }
    }
}
