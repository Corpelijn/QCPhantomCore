using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Imaging.Pixels
{
    public class RGBAPixel : IPixel
    {
        #region "Fields"

        private byte red;
        private byte green;
        private byte blue;
        private byte alpha;

        #endregion

        #region "Constructors"

        public RGBAPixel(byte red, byte green, byte blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = 255;
        }

        public RGBAPixel(byte red, byte green, byte blue, byte alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
        }

        public RGBAPixel(byte gray)
        {
            this.red = gray;
            this.green = gray;
            this.blue = gray;
            this.alpha = 255;
        }

        public RGBAPixel(byte gray, byte alpha)
        {
            this.red = gray;
            this.green = gray;
            this.blue = gray;
            this.alpha = alpha;
        }

        #endregion

        #region "Properties"

        public byte Red => red;

        public byte Green => green;

        public byte Blue => blue;

        public byte Alpha => alpha;

        public double Grayscale => 1.0 / 255 * ((red + green + blue) / 3);

        public uint Value => BitConverter.ToUInt32(new byte[] { red, green, blue, alpha }, 0);

        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public object Clone()
        {
            return new RGBAPixel(red, green, blue, alpha);
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
