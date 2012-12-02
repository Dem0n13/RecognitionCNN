using System.Drawing;
using Recognition.Utils;

namespace Recognition.Image
{
    /// <summary>
    /// Базовый класс для представления растрового изображения
    /// </summary>
    /// <typeparam name="TPixel">Тип пиксела.</typeparam>
    public abstract class GreyScaleImage<TPixel> where TPixel : struct
    {
        #region Абстрактные члены для переопределения

        public abstract TPixel BackgroundPixel { get; }
        public abstract TPixel ForegroundPixel { get; }
        protected abstract Color PixelToColor(TPixel pixel);

        #endregion

        #region Публичные свойства, инициализируемые только создании изображения

        public int? Label { get; protected set; }
        
        /// <summary>
        /// Массив пикселов изображения.
        /// </summary>
        public TPixel[][] RawData { get; protected set; }

        /// <summary>
        /// Ширина изображения.
        /// </summary>
        public int Width { get; protected set; }

        /// <summary>
        /// Высота изображения.
        /// </summary>
        public int Height { get; protected set; }

        /// <summary>
        /// Суммарное количество пикселов изображения.
        /// </summary>
        public int Length
        {
            get { return Width*Height; }
        }

        #endregion

        /// <summary>
        /// Инициализирует изображение заданной ширины и высоты,
        /// заполненное фоновым значением пиксела
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        protected void InitializeCanvas(int width, int height)
        {
            RawData = ArrayHelper<TPixel>.Create2D(width, height, BackgroundPixel);

            Width = width;
            Height = height;
        }

        #region Универсальные конвертеры в типы .NET

        /// <summary>
        /// Возвращает объект <see cref="T:System.Drawing.Bitmap"/>, представляющий изображение.
        /// Использует переопределенный метод PixelToColor().
        /// </summary>
        /// <returns>Jбъект <see cref="T:System.Drawing.Bitmap"/>, представляющий изображение.</returns>
        public Bitmap ToBitmap()
        {
            var bitmap = new Bitmap(Width, Height);

            for (var y = 0; y < Height; y++)
                for (var x = 0; x < Width; x++)
                    bitmap.SetPixel(x, y, PixelToColor(RawData[y][x]));

            return bitmap;
        }

        /// <summary>
        /// Возвращает строку, которая представляет текущее изображение.
        /// Предоставляет данные о типе используемого пиксела, размеры изображения.
        /// </summary>
        /// <returns>
        /// Строка, представляющая текущее изображение.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return string.Format("{0}: {1}x{2} of {3}", GetType().Name, Width, Height, typeof (TPixel).Name);
        }

        #endregion
    }
}
