using QCAnalyser;
using QCAnalyser.Imaging;
using QCAnalyser.Imaging.Encoders;
using QCAnalyser.Imaging.Helpers;
using QCAnalyser.Imaging.Kernel;
using QCAnalyser.Imaging.Markings;
using QCAnalyser.Imaging.Pixels;
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

        private Point[] GetMeasuringPoints()
        {
            List<Point> points = new List<Point>();

            int spacing = image.Width / 30;

            Point up = new Point(0, -spacing);
            Point right = new Point(spacing, 0);
            Point down = new Point(0, spacing);
            Point left = new Point(-spacing, 0);

            Point direction = up;
            Point currentPosition = new Point(Center);
            Bounds bounds = new Bounds(Center.X, Center.Y, 1, 1);

            while (bounds.Top > 0 && bounds.Bottom < image.Height && bounds.Left > 0 && bounds.Right < image.Width)
            {
                currentPosition += direction;

                image.AddMarking(new CircleMarking(new RGBAPixel(255, 0, 0), currentPosition, 15, true));
                points.Add(currentPosition);

                if (bounds.IsOutsideBounds(currentPosition))
                {
                    if (direction == up)
                        direction = right;
                    else if (direction == right)
                        direction = down;
                    else if (direction == down)
                        direction = left;
                    else if (direction == left)
                        direction = up;
                }

                bounds.Expand(currentPosition);
            }

            return points.OrderBy(x => x.Y).ThenBy(x => x.X).ToArray();
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
            Point[] points = GetMeasuringPoints();

            return false;
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
