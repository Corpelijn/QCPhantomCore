using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Image.Pixels
{
    public class DICOMPixel : Pixel
    {
        #region "Fields"

        private ushort color;

        #endregion

        #region "Constructors"

        public DICOMPixel(ushort color)
        {
            this.color = color;
        }

        #endregion

        #region "Properties"

        public ushort Color => color;

        public override byte R => (byte)(255.0 / ushort.MaxValue * color);

        public override byte G => (byte)(255.0 / ushort.MaxValue * color);

        public override byte B => (byte)(255.0 / ushort.MaxValue * color);

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
