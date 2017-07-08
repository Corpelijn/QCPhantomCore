﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace QCAnalyser.Image.Markings
{
    public abstract class ImageMarking
    {
        #region "Fields"

        protected Point[] pixels;
        protected Color color;

        #endregion

        #region "Constructors"

        protected ImageMarking(Color color)
        {
            this.color = color;
        }

        #endregion

        #region "Properties"

        public Color Color
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
