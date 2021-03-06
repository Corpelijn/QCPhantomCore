﻿using QCAnalyser.Image.Helpers;
using QCAnalyser.Image.Pixels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace QCAnalyser.Image.Markings
{
    public class LineMarking : ImageMarking
    {
        #region "Fields"



        #endregion

        #region "Constructors"

        public LineMarking(Pixel color, Point start, Point end) :base(color)
        {
            GetPixels(start, end);
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        private void GetPixels(Point start, Point end)
        {
            pixels = BresenhamLine.GetLine(start, end);
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
