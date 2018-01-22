using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Image.Pixels
{
    public class RGBPixel : Pixel
    {
        #region "Fields"

        private byte r;
        private byte g;
        private byte b;

        #endregion

        #region "Constructors"

        public RGBPixel(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        #endregion

        #region "Properties"

        public override byte R => r;

        public override byte G => g;

        public override byte B => b;

        #endregion

        #region "Methods"



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
