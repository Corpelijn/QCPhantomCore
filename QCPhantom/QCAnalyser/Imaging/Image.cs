using QCAnalyser.Imaging.Encoders;
using QCAnalyser.Imaging.Pixels;
using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Imaging
{
    public class Image
    {
        #region "Fields"

        private int width;
        private int height;
        private IPixel[] pixels;

        #endregion

        #region "Constructors"

        public Image(int width, int height)
        {
            this.width = width;
            this.height = height;
            pixels = new IPixel[width * height];
        }

        #endregion

        #region "Properties"

        public int Width => width;

        public int Height => height;

        #endregion

        #region "Methods"

        public void SetPixel(int x, int y, IPixel p)
        {
            if (x < 0 || y < 0 || x >= width || y >= height)
                return;

            pixels[y * width + x] = p;
        }

        public IPixel GetPixel(int x, int y)
        {
            if (x < 0 || y < 0 || x >= width || y >= height)
                return new GrayPixel(0);

            return pixels[y * width + x];
        }

        public void SaveToFile(string filename, ImageFormat format)
        {
            ImageEncoder.EncodeImage(filename, format, width, height, pixels);
        }

        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"

        public static Image FromData(int width, int height, IPixel[] pixels)
        {
            return new Image(width, height) { pixels = pixels };
        }

        #endregion

        #region "Operators"



        #endregion
    }
}
