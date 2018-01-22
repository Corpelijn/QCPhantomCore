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

        public byte Red => 0;

        public byte Green => 0;

        public byte Blue => 0;

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
