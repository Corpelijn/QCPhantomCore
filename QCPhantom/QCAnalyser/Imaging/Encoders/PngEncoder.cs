using FreeImageAPI;
using QCAnalyser.Imaging.Pixels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace QCAnalyser.Imaging.Encoders
{
    class PngEncoder : ImageEncoder
    {
        #region "Fields"



        #endregion

        #region "Constructors"

        public PngEncoder(string filename, int width, int height, IPixel[] pixels) : base(filename, width, height, pixels)
        {

        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public override void Write()
        {
            FreeImageBitmap bitmap = new FreeImageBitmap(width, height);

            int currentIndex = pixels.Length - width;
            int x = 0, y = 0;
            int current = 0;
            while (currentIndex >= 0)
            {
                IPixel[] row = Subset(pixels, currentIndex, currentIndex + width);
                foreach (IPixel pixel in row)
                {
                    bitmap.SetPixel(x, y, Color.FromArgb(pixel.Red, pixel.Green, pixel.Blue));
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

        private T[] Subset<T>(T[] array, int firstIndex, int lastIndex)
        {
            return array.Skip(firstIndex).Take(lastIndex - firstIndex).ToArray();
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
