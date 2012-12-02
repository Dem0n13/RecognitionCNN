using System;
using System.IO;
using Recognition.Utils;

namespace Recognition.Image
{
    public static class MNistFileManager
    {
        public const int Idx1MagicNumber = 2049;
        public const int Idx3MagicNumber = 2051;

        public const int Idx1DataOffset = 8;
        public const int Idx3DataOffset = 16;

        public static MNistImage[] GetImageSet(string labelsPath, string imagesPath)
        {
            Debug.Assert(labelsPath != null && imagesPath != null);

            var imagesBytes = File.ReadAllBytes(imagesPath);
            if (ConvertFromBigEndian(imagesBytes, 0) != Idx3MagicNumber)
                throw new FormatException("Неверный формат файла изображений");

            var imagesCount = ConvertFromBigEndian(imagesBytes, sizeof (int));
            var imageHeight = ConvertFromBigEndian(imagesBytes, sizeof (int)*2);
            var imageWidth = ConvertFromBigEndian(imagesBytes, sizeof (int)*3);
            var imageLength = imageWidth*imageHeight;
            if (imagesCount != (imagesBytes.Length - Idx3DataOffset)/imageLength)
                throw new FormatException("Файл изображений поврежден");

            var labelsBytes = File.ReadAllBytes(labelsPath);
            if (ConvertFromBigEndian(labelsBytes, 0) != Idx1MagicNumber)
                throw new FormatException("Неверный формат файла подписей");

            var labelsCount = ConvertFromBigEndian(labelsBytes, sizeof (int));
            if (labelsCount != labelsBytes.Length - Idx1DataOffset)
                throw new FormatException("Файл подписей поврежден");

            if (imagesCount != labelsCount)
                throw new Exception("Количество изображений не совпадает с количеством подписей");

            // получаем все изображения
            var images = new MNistImage[imagesCount];
            for (var i = 0; i < images.Length; i++)
            {
                var label = (int) labelsBytes[Idx1DataOffset + i];
                Debug.Assert(label < 10, label.ToString());

                var imageBytes = new byte[imageWidth][];
                for (var r = 0; r < imageHeight; r++)
                {
                    imageBytes[r] = new byte[imageHeight];
                    Buffer.BlockCopy(imagesBytes, Idx3DataOffset + i*imageLength + r*imageWidth,
                                     imageBytes[r], 0, imageWidth);
                }

                images[i] = new MNistImage(label, imageBytes);
            }

            return images;
        }

        private static int ConvertFromBigEndian(byte[] value, int startIndex)
        {
            return ((((value[startIndex + 0] << 0x18) | (value[startIndex + 1] << 0x10)) |
                     (value[startIndex + 2] << 8)) | value[startIndex + 3]);
        }
    }
}
