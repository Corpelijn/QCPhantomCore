using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace QCAnalyser.Image.Markings
{
    public class CircleMarking : ImageMarking
    {
        #region "Fields"



        #endregion

        #region "Constructors"

        public CircleMarking(Color color, Point center, int size, bool drawCenter = true, bool fill = false) : base(color)
        {
            GetPixels(center, size, drawCenter, fill);
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        private void GetPixels(Point center, int size, bool drawCenter, bool fill)
        {
            List<Point> pixels = new List<Point>(GetOutline(center, size));
            if (fill)
            {
                pixels.AddRange(GetFill(pixels.ToArray()));
            }
            else if (drawCenter)
                pixels.Add(center);

            this.pixels = pixels.ToArray();
        }

        private Point[] GetOutline(Point center, int size)
        {
            int xo = center.X, yo = center.Y; // center of circle
            double r, rr;

            r = size / 2;
            rr = Math.Pow(r, 2);

            List<Point> pixels = new List<Point>();

            for (int i = xo - (int)r; i <= xo + r; i++)
            {
                for (int j = yo - (int)r; j <= yo + r; j++)
                {
                    if (Math.Abs(Math.Pow(i - xo, 2) + Math.Pow(j - yo, 2) - rr) <= r)
                    {
                        pixels.Add(new Point(i, j));
                    }
                }
            }

            return pixels.ToArray();
        }

        private Point[] GetFill(Point[] outline)
        {
            throw new NotImplementedException();
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
