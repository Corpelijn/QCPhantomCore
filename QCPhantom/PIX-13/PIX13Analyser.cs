using OpenCvSharp;
using QCAnalyser;
using QCAnalyser.Imaging;
using QCAnalyser.Imaging.Encoders;
using QCAnalyser.Imaging.Helpers;
using QCAnalyser.Imaging.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIX13
{
    /// <summary>
    /// An analyser class for the PIX-13 phantom. May also be suitable for the DIGIT-13 phantom
    /// </summary>
    public class PIX13Analyser : ImageAnalyser
    {
        #region "Fields"



        #endregion

        #region "Constructors"

        public PIX13Analyser(Image image) : base(image)
        {

        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        private Point[] GetStartingPoints()
        {
            List<Point> startPoints = new List<Point>();

            const int spacing = 30;


        }

        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public override void AnalyseImage()
        {

        }

        public override bool IsCorrectPhantom()
        {
            return false;
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
