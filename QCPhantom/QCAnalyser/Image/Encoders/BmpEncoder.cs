using QCAnalyser.Image.Pixels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace QCAnalyser.Image.Encoders
{
    class BmpEncoder : ImageEncoder
    {
        #region "Fields"



        #endregion

        #region "Constructors"

        public BmpEncoder(string filename, int width, int height, ushort[] pixels) : base(filename, width, height, pixels)
        {

        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        /// <summary>
        /// Writes the current data in the DICOMImage to a bmp file (24-bits)
        /// </summary>
        /// <param name="filename">The destination filename</param>
        public override void Write()
        {
            FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write);

            WriteHeader(stream);

            WriteData(stream);

            stream.Dispose();
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

        private void WriteData(FileStream stream)
        {
            int currentIndex = pixels.Length - width;
            int current = 0;
            while (currentIndex >= 0)
            {
                Pixel[] row = Subset(pixels, currentIndex, currentIndex + width);
                foreach (Pixel pixel in row)
                {
                    stream.WriteByte(pixel.B);
                    stream.WriteByte(pixel.G);
                    stream.WriteByte(pixel.R);

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



        #endregion

        #region "Operators"



        #endregion
    }
}
