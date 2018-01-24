using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Imaging.Helpers
{
    public class Point
    {
        #region "Fields"

        private int x;
        private int y;

        #endregion

        #region "Constructors"

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(Point source)
        {
            this.x = source.x;
            this.y = source.y;
        }

        #endregion

        #region "Properties"

        public int X => x;

        public int Y => y;

        #endregion

        #region "Methods"

        private Point Add(Point point)
        {
            return new Point(this.x + point.x, this.y + point.y);
        }

        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public override string ToString()
        {
            return "X = " + x + "; Y = " + y;
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"

        public static Point operator +(Point left, Point right)
        {
            return left.Add(right);
        }

        #endregion
    }
}
