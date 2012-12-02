using System.Drawing;
using System.Drawing.Drawing2D;

namespace Recognition.Image
{
    public static class BitmapExtention
    {
        public static Bitmap Resize(this Bitmap image, int factor, InterpolationMode mode)
        {
            return Resize(image, new Size(image.Size.Width*factor, image.Size.Height*factor), mode);
        }

        public static Bitmap Resize(this Bitmap image, Size newSize, InterpolationMode mode)
        {
            var result = new Bitmap(newSize.Width, newSize.Height);
            var graphic = Graphics.FromImage(result);
            graphic.CompositingQuality = CompositingQuality.AssumeLinear;
            graphic.InterpolationMode = mode;
            var rectangle = new Rectangle(Point.Empty, newSize);
            graphic.DrawImage(image, rectangle);
            return result;
        }
    }
}
