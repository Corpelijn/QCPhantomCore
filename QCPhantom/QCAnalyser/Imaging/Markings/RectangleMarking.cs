using QCAnalyser.Imaging.Helpers;
using QCAnalyser.Imaging.Pixels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace QCAnalyser.Imaging.Markings
{
    public class RectangleMarking : ImageMarking
    {
        #region "Fields"



        #endregion

        #region "Constructors"

        public RectangleMarking(IPixel color, Point leftTop, Point leftBottom, Point rightTop, Point rightBottom, bool fill = false) : base(color)
        {
            GetPixels(leftTop, leftBottom, rightTop, rightBottom, fill);
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        private void GetPixels(Point lt, Point lb, Point rt, Point rb, bool fill)
        {
            List<Point> pixels = new List<Point>(GetOutline(lt, lb, rt, rb));
            if (fill)
            {
                pixels.AddRange(GetFill(pixels.ToArray()));
            }

            this.pixels = pixels.ToArray();
        }

        private Point[] GetOutline(Point lt, Point lb, Point rt, Point rb)
        {
            List<Point> outline = new List<Point>();

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
