using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace QCAnalyser.Image.Helpers
{
    class BresenhamLine
    {
        #region "Fields"



        #endregion

        #region "Constructors"



        #endregion

        #region "Properties"



        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"

        /// <summary>
        /// Gets the points on the line from the start to the end points. The line is calculated by using the Bresenham Line algorithm.
        /// </summary>
        /// <param name="start">The first point of the line</param>
        /// <param name="end">The second point of the line</param>
        /// <returns>Returns an array of Point objects containing a line from start to end</returns>
        public static Point[] GetLine(Point start, Point end)
        {
            int x0 = start.X;
            int y0 = start.Y;
            int x1 = end.X;
            int y1 = end.Y;
            List<Point> line = new List<Point>();

            int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
            int err = (dx > dy ? dx : -dy) / 2, e2;
            while (true)
            {
                line.Add(new Point(x0, y0));
                if (x0 == x1 && y0 == y1) break;
                e2 = err;
                if (e2 > -dx) { err -= dy; x0 += sx; }
                if (e2 < dy) { err += dx; y0 += sy; }
            }
            return line.ToArray();
        }

        /// <summary>
        /// Gets the direction vector from the start point to the end point
        /// </summary>
        /// <param name="start">The start point of the vector</param>
        /// <param name="end">The end point/direction point to calculate the vector</param>
        /// <returns>Returns a Vector2 object containing the calculated vector</returns>
        public static Vector2 GetVector(Point start, Point end, bool aboveOne = false)
        { 
            Point p = new Point(end.X - start.X, end.Y - start.Y);

            // Get the high value
            int high;
            if (aboveOne)
                high = p.X > p.Y ? p.X : p.Y;
            else
                high = p.X < p.Y ? p.X : p.Y;

            return new Vector2(p.X / high, p.Y / high);
        }

        #endregion

        #region "Operators"



        #endregion
    }
}
