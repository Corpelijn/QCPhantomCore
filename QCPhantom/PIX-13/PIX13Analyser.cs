using QCAnalyser;
using QCAnalyser.Image;
using QCAnalyser.Image.Helpers;
using QCAnalyser.Image.Markings;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public PIX13Analyser(DICOMImage image) : base(image)
        {

        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        //old
        private Point[] GetSpiralPixels()
        {
            int stepSize = 50;

            int currentDirection = 0; // N=0, E=1, S=2, W=3
            Point currentPosition = Center;
            Bounds bounds = new Bounds(Center.X, Center.Y, 1, 1);

            while (bounds.Width < image.Width && bounds.Height < image.Height)
            {
                Point p = GetNextPosition(currentPosition, ref bounds, stepSize, ref currentDirection);

                image.AddMarking(new CircleMarking(Color.FromArgb(255, 0, 0), p, 15, true));
                currentPosition = p;
            }

            return null;
            //throw new NotImplementedException();
        }

        //old
        private Point GetNextPosition(Point currentPosition, ref Bounds bounds, int stepSize, ref int currentDirection)
        {
            int xDisplacement = 0;
            int yDisplacement = 0;
            if (currentDirection == 0)
                yDisplacement = -stepSize;
            else if (currentDirection == 1)
                xDisplacement = stepSize;
            else if (currentDirection == 2)
                yDisplacement = stepSize;
            else if (currentDirection == 3)
                xDisplacement = -stepSize;

            Point ret_val = new Point(currentPosition.X + xDisplacement, currentPosition.Y + yDisplacement);

            if (ret_val.X < bounds.Left ||
                ret_val.X > bounds.Right ||
                ret_val.Y < bounds.Top ||
                ret_val.Y > bounds.Bottom)
            {
                currentDirection++;
                if (currentDirection > 3)
                    currentDirection = 0;
                // Bounds are not scaled properly, fix please
                bounds.Expand(xDisplacement, yDisplacement);
            }

            return ret_val;
        }

        /// <summary>
        /// Gets a line from the start position in the specified direction (with steps) and returns the pixel values at the analysed points
        /// </summary>
        /// <param name="start">The start position of te line</param>
        /// <param name="direction">The stepsize/direction for each pixel to analyse on the line</param>
        /// <returns>Returns an array with pixel values found on the line from the start position in the specified direction</returns>
        private ushort[] GetDottedLine(Point start, Point direction)
        {
            List<ushort> line = new List<ushort>();

            Point current = start;
            while (current.X > 0 && current.Y > 0 && current.X < image.Width && current.Y < image.Height)
            {
                line.Add(image.GetPixel(current.X, current.Y));
                current = current.Add(direction);
            }

            return line.ToArray();
        }

        /// <summary>
        /// Measures the differences between each point on the line and marks them if they have a big difference (10%) with the previous point
        /// </summary>
        /// <param name="data">An array of pixel data to measure the differences on in linear order</param>
        /// <returns>Returns an array of booleans containing information of high differences</returns>
        private bool[] MeasureDifferences(ushort[] data)
        {
            ushort diffTenth = (ushort)((data.Max() - data.Min()) / 10);
            bool[] newData = new bool[data.Length - 1];

            for (int i = data.Length - 1; i >= 1; i--)
            {
                newData[i - 1] = data[i] > data[i - 1] + diffTenth || data[i] < data[i - 1] - diffTenth;
            }

            return newData;
        }

        /// <summary>
        /// Checks if there are any possible locations for the contrast blocks. If found it returns the pixels locations on the given line.
        /// </summary>
        /// <param name="direction">The direction from the given start positions to search in</param>
        /// <param name="startPositions">The start positions for the lines to search on</param>
        /// <returns>An array of pixel positions on the line where the contrast blocks could be</returns>
        private int[] FindPossibleContrastLocations(Point direction, params Point[] startPositions)
        {
            if (startPositions.Length < 2)
                return null;

            ushort[] firstLine = GetDottedLine(startPositions[0], direction);
            ushort[] secondLine = GetDottedLine(startPositions[1], direction);

            bool[] diffFirstLine = MeasureDifferences(firstLine);
            bool[] diffSecondLine = MeasureDifferences(secondLine);

            int[] flIndexes = diffFirstLine.Select((b, i) => b.Equals(true) ? i + 1 : -1).Where(i => i != -1).ToArray();
            int[] slIndexes = diffSecondLine.Select((b, i) => b.Equals(true) ? i + 1 : -1).Where(i => i != -1).ToArray();

            for (int i = 0; i < flIndexes.Length; i++)
            {
                this.image.AddMarking(new CircleMarking(Color.FromArgb(0, 255, 0), new Point(startPositions[0].X, startPositions[0].Y + flIndexes[i] * direction.Y), 10));
            }

            for (int i = 0; i < slIndexes.Length; i++)
            {
                this.image.AddMarking(new CircleMarking(Color.FromArgb(0, 255, 0), new Point(startPositions[1].X, startPositions[1].Y + slIndexes[i] * direction.Y), 10));
            }

            return null;
        }

        private void FindContrastBlocks()
        {
            // Setup some constants
            int stepSize = image.Width / 2 / 50;
            stepSize = stepSize < 1 ? 1 : stepSize;

            // Read some pixelData to find "dips" (possibly the contrastblocks)
            FindPossibleContrastLocations(new Point(0, -stepSize),
                                Center.Add(new Point((int)(image.Width * 0.1f), 0)),
                                Center.Add(new Point((int)(image.Width * -0.1f), 0))
                                );
            //ushort[] values;
            //values = GetDottedLine(Center.Add(new Point((int)(image.Width * 0.1f), 0)), new Point(0, -stepSize));
            //values = GetDottedLine(Center.Add(new Point((int)(-image.Width * 0.1f), 0)), new Point(0, -stepSize));
        }

        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public override void AnalyseImage()
        {
            throw new NotImplementedException();
        }

        public override bool IsCorrectPhantom()
        {
            //GetSpiralPixels();
            FindContrastBlocks();

            return false;
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
