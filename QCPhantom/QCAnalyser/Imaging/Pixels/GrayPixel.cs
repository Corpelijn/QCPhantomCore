using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Imaging.Pixels
{
    public class GrayPixel : IPixel
    {
        #region "Fields"

        private double gray;

        #endregion

        #region "Constructors"

        public GrayPixel(double gray)
        {
            this.gray = gray;
        }

        #endregion

        #region "Properties"

        public byte Red => (byte)(255 * gray);

        public byte Green => (byte)(255 * gray);

        public byte Blue => (byte)(255 * gray);

        public byte Alpha => 0;

        public double Grayscale => gray;

        public uint Value => (uint)(uint.MaxValue * gray);

        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public object Clone()
        {
            return new GrayPixel(gray);
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
