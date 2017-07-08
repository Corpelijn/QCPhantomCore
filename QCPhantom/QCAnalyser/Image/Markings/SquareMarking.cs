using QCAnalyser.Image.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace QCAnalyser.Image.Markings
{
    public class SquareMarking : ImageMarking
    {
        #region "Fields"



        #endregion

        #region "Constructors"

        public SquareMarking(Color color, Point center, int size, bool drawCenter = true, bool fill = false) : base(color)
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
            else if(drawCenter)
                pixels.Add(center);

            this.pixels = pixels.ToArray();
        }

        private Point[] GetOutline(Point center, int size)
        {
            List<Point> outline = new List<Point>();
            int halfsize = size / 2;

            Point lt = new Point(center.X - halfsize, center.Y - halfsize);
            Point rt = new Point(center.X + halfsize, center.Y - halfsize);
            Point lb = new Point(center.X - halfsize, center.Y + halfsize);
            Point rb = new Point(center.X + halfsize, center.Y + halfsize);

            outline.AddRange(BresenhamLine.GetLine(lt, lb));
            outline.AddRange(BresenhamLine.GetLine(lb, rb));
            outline.AddRange(BresenhamLine.GetLine(rb, rt));
            outline.AddRange(BresenhamLine.GetLine(rt, lt));

            return outline.Distinct().Where(x => x.X >= 0 && x.Y >= 0).ToArray();
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
