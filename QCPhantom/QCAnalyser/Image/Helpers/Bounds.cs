using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Image.Helpers
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

        public void Expand(int xExpand, int yExpand)
        {
            if (xExpand > 0)
            {
                width += xExpand;
            }
            else if (xExpand < 0)
            {
                x += xExpand;
                width += Math.Abs(xExpand);
            }

            if (yExpand > 0)
            {
                height += yExpand;
            }
            else if (yExpand < 0)
            {
                y += yExpand;
                height += Math.Abs(yExpand);
            }
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
