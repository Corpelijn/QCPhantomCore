using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Imaging.Helpers
{
    public class Bounds
    {
        #region "Fields"

        private int x;
        private int y;
        private int width;
        private int height;

        #endregion

        #region "Constructors"

        public Bounds(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        #endregion

        #region "Properties"

        public int Left
        {
            get { return x; }
        }

        public int Right
        {
            get { return x + width; }
        }

        public int Top
        {
            get { return y; }
        }

        public int Bottom
        {
            get { return y + height; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        #endregion

        #region "Methods"

        public bool IsOutsideBounds(Point point)
        {
            return (point.X < Left || point.Y < Top || point.X > Right || point.Y > Bottom);
        }

        public void Expand(Point farPoint)
        {
            if (farPoint.X > Right)
                width += farPoint.X - Right;
            if (farPoint.X < Left)
            {
                int diff = Left - farPoint.X;
                x -= diff;
                width += diff;
            }

            if (farPoint.Y > Bottom)
                height += farPoint.Y - Bottom;
            if (farPoint.Y < Top)
            {
                int diff = Top - farPoint.Y;
                y -= diff;
                height += diff;
            }
        }

        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public override string ToString()
        {
            return $"Left={Left};Right={Right};Top={Top};Bottom={Bottom}";
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
