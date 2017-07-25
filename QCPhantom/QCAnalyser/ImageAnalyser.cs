using QCAnalyser.Image;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace QCAnalyser
{
    public abstract class ImageAnalyser
    {
        #region "Fields"

        protected DICOMImage image;

        private Point centerPixel;

        #endregion

        #region "Constructors"

        protected ImageAnalyser(DICOMImage image)
        {
            this.image = image;

            // Init some "constants"
            Init();
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the position of the center pixel
        /// </summary>
        protected Point Center
        {
            get { return centerPixel; }
        }

        #endregion

        #region "Methods"

        /// <summary>
        /// Initialize some "constants"
        /// </summary>
        private void Init()
        {
            this.centerPixel = new Point(image.Width / 2, image.Height / 2);
        }

        protected void GetMinMaxFromArea(Point center, int size, out int min, out int max)
        {
            min = image.GetPixel(center.X, center.Y);
            max = min;

            for (int i = center.X - size / 2; i < center.X + size / 2; i++)
            {
                for (int j = center.Y - size / 2; j < center.Y + size / 2; j++)
                {
                    ushort pixel = image.GetPixel(i, j);
                    if (pixel < min)
                        min = pixel;
                    else if (pixel > max)
                        max = pixel;
                }
            }
        }

        #endregion

        #region "Abstract/Virtual Methods"

        /// <summary>
        /// Check if the image is correct for this analyser
        /// </summary>
        /// <returns>True if the image is correct for the analyser; otherwise false</returns>
        public abstract bool IsCorrectPhantom();

        /// <summary>
        /// Runs the analyses on the image. 
        /// Results are available via the Results property
        /// </summary>
        public abstract void AnalyseImage();

        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
