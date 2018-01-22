using QCAnalyser.Imaging.Helpers;
using QCAnalyser.Imaging.Pixels;
using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Imaging.Markings
{
    public abstract class ImageMarking
    {
        #region "Fields"

        protected Point[] pixels;
        protected IPixel color;

        #endregion

        #region "Constructors"

        protected ImageMarking(IPixel color)
        {
            this.color = color;
        }

        #endregion

        #region "Properties"

        public IPixel Color
        {
            get { return color; }
        }

        public Point[] Pixels
        {
            get { return pixels; }
        }

        #endregion

        #region "Methods"



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
