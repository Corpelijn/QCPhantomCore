using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Image.Parsers
{
    public abstract class ImageParser
    {
        #region "Fields"



        #endregion

        #region "Constructors"

        protected ImageParser()
        {

        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"

        public abstract DICOMImage Parse();

        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
