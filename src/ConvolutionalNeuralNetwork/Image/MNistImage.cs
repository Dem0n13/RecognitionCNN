using System.Drawing;
using Recognition.Utils;

namespace Recognition.Image
{
    public class MNistImage : GreyScaleImage<byte>
    {
        public override byte BackgroundPixel
        {
            get { return 0; }
        }

        public override byte ForegroundPixel
        {
            get { return 255; }
        }

        public MNistImage(int label, byte[][] data)
        {
            Debug.AssertNotNull(data);
            Debug.Assert(data.Length > 0);

            Label = label;

            InitializeCanvas(data.Length, data[0].Length);
            ArrayHelper<byte>.CopyData(data, RawData);
        }

        protected override Color PixelToColor(byte pixel)
        {
            var value = (byte)(255 - pixel);
            return Color.FromArgb(255, value, value, value);
        }
    }
}
