using System;
using System.Collections.Generic;
using System.Text;
using QCAnalyser.Image.Images;

namespace QCAnalyser.Image.Kernel
{
    public class SobelEdgeDetection : IKernelImageProcessor
    {
        #region "Fields"

        private IImage image;

        #endregion

        #region "Constructors"

        public SobelEdgeDetection(IImage image)
        {
            this.image = image;
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public DrawableImage ProcessImage(Kernel kernel)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
