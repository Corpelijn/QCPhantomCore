using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Imaging.Pixels
{
    public class U16Pixel : IPixel
    {
        #region "Fields"

        private ushort color;

        #endregion

        #region "Constructors"

        public U16Pixel(ushort color)
        {
            this.color = color;
        }

        #endregion

        #region "Properties"

        public byte Red => (byte)(255 * Grayscale);

        public byte Green => (byte)(255 * Grayscale);

        public byte Blue => (byte)(255 * Grayscale);

        public byte Alpha => 255;

        public uint Value => color;

        public double Grayscale => 1.0 / ushort.MaxValue * color;

        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public object Clone()
        {
            return new U16Pixel(this.color);
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
