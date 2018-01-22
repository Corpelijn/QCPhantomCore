using QCAnalyser.Imaging.Pixels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace QCAnalyser.Imaging.Helpers
{
    class Line
    {
        #region "Fields"

        private Point start;
        private Point end;

        #endregion

        #region "Constructors"

        public Line(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        /// <summary>
        /// Gets the values of the pixels at the given positions
        /// </summary>
        /// <param name="image">The image to get the pixels from</param>
        /// <returns>An array containing the pixel values</returns>
        public IPixel[] GetPixels(Image image)
        {
            Point[] pixels = BresenhamLine.GetLine(start, end);
            List<IPixel> pixelValues = new List<IPixel>();
            foreach(Point pixel in pixels)
            {
                pixelValues.Add(image.GetPixel(pixel.X, pixel.Y));
            }

            return pixelValues.ToArray();
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
