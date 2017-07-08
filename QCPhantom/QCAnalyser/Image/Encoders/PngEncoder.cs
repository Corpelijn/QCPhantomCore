using FreeImageAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace QCAnalyser.Image.Encoders
{
    class PngEncoder : ImageEncoder
    {
        #region "Fields"



        #endregion

        #region "Constructors"

        public PngEncoder(string filename, int width, int height, ushort[] pixels) :base(filename, width, height, pixels)
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
                Color[] row = Subset(pixels, currentIndex, currentIndex + width);
                foreach (Color pixel in row)
                {
                    bitmap.SetPixel(x, y, pixel);
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
