using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Image.Encoders
{
    public class ImageFormat
    {
        #region "Fields"

        public static readonly ImageFormat PNG = new ImageFormat(".png", typeof(PngEncoder));
        public static readonly ImageFormat BMP = new ImageFormat(".bmp", typeof(BmpEncoder));
        //public ImageFormat JPG = new ImageFormat(".jpg", typeof(PngJpgEncoder));

        private Type encoder;
        private string format;

        #endregion

        #region "Constructors"

        private ImageFormat(string format, Type type)
        {
            this.format = format;
            this.encoder = type;
        }

        #endregion

        #region "Properties"

        public string Format
        {
            get { return format; }
        }

        public Type Encoder
        {
            get { return encoder; }
        }

        #endregion

        #region "Methods"

        public string CheckFilename(string filename)
        {
            if (!filename.EndsWith(format))
                filename += format;

            return filename;
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
