using FreeImageAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace QCAnalyser.Image.DICOM
{
    public class DICOMImage
    {
        #region "Fields"

        protected ushort[] pixels;
        protected int width;
        protected int height;

        #endregion

        #region "Constructors"

        protected DICOMImage(int width, int height)
        {
            this.width = width;
            this.height = height;

            pixels = new ushort[width * height];
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        public ushort GetPixel(int x, int y)
        {
            return pixels[y * width + x];
        }

        public void SetPixel(int x, int y, ushort value)
        {
            pixels[y * width + x] = value;
        }

        public void WritePng(string filename)
        {
            FreeImageBitmap bitmap = new FreeImageBitmap(width, height);

            int currentIndex = pixels.Length - width;
            int x = 0, y = 0;
            int current = 0;
            while (currentIndex > 0)
            {
                ushort[] row = Subset(pixels, currentIndex, currentIndex + width);
                foreach (ushort pixel in row)
                {
                    char gray = (char)(255f / 65535f * pixel);
                    bitmap.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                    x++;
                    current++;
                }

                currentIndex -= width;
                x = 0;
                y++;

                if (current % 1000 == 0)
                    WriteProgress(current, pixels.Length);
            }

            WriteProgress(1, 1);


            bitmap.Save(filename);
        }

        public void WriteBmp(string filename)
        {
            FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write);

            WriteHeader(stream);

            int currentIndex = pixels.Length - width;
            int current = 0;
            while (currentIndex > 0)
            {
                ushort[] row = Subset(pixels, currentIndex, currentIndex + width);
                foreach (ushort pixel in row)
                {
                    byte b = (byte)(255f / 65535f * pixel);
                    stream.WriteByte(b);
                    stream.WriteByte(b);
                    stream.WriteByte(b);

                    current++;
                }

                int leftover = row.Length % 4;
                for (int i = 0; i < leftover; i++)
                {
                    stream.WriteByte(0);
                }
                currentIndex -= width;

                if (current % 50000 == 0)
                    WriteProgress(current, pixels.Length);
            }

            WriteProgress(1, 1);

            stream.Dispose();
        }

        private void WriteProgress(long status, long total)
        {
            float progress = 100f / (float)total * (float)status;

            Console.Write(progress.ToString("0.0") + "%\t[");
            int bars = (int)(50f / 100f * progress);
            for (int i = 0; i < bars; i++)
            {
                Console.Write("=");
            }
            if (status != total)
                Console.Write(">");
            for (int i = 0; i < 50 - bars; i++)
            {
                Console.Write(" ");
            }

            Console.Write("]    \r");
        }

        private void WriteHeader(FileStream stream)
        {
            int padding = (width % 4) * (pixels.Length / width);

            // BMP Header
            WriteData(stream, 0x42, 0x4d);
            WriteData(stream, BitConverter.GetBytes(122 + pixels.Length * 3 + padding));
            WriteData(stream, BitConverter.GetBytes(0));
            WriteData(stream, BitConverter.GetBytes(122));

            // DIB Header
            WriteData(stream, BitConverter.GetBytes(108));
            WriteData(stream, BitConverter.GetBytes(width));
            WriteData(stream, BitConverter.GetBytes(height));
            WriteData(stream, 1, 0);
            WriteData(stream, 24, 0);
            WriteData(stream, 0, 0, 0, 0);
            WriteData(stream, BitConverter.GetBytes(pixels.Length * 3 + padding));
            WriteData(stream, BitConverter.GetBytes(2835));
            WriteData(stream, BitConverter.GetBytes(2835));
            WriteData(stream, 0, 0, 0, 0);
            WriteData(stream, 0, 0, 0, 0);

            // Some needed data
            WriteData(stream, 0x42, 0x47, 0x52, 0x73);
            WriteData(stream, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        private void WriteData(FileStream stream, params byte[] data)
        {
            stream.Write(data, 0, data.Length);
        }

        private T[] Subset<T>(T[] array, int firstIndex, int lastIndex)
        {
            return array.Skip(firstIndex).Take(lastIndex - firstIndex).ToArray();
        }

        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"

        public static DICOMImage FromData(int width, int height, ushort[] pixels)
        {
            DICOMImage image = new DICOMImage(width, height);
            image.pixels = pixels;
            return image;
        }

        #endregion

        #region "Operators"



        #endregion
    }
}
