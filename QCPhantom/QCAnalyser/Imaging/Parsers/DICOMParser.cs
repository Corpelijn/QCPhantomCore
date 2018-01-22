using Dicom;
using Dicom.Imaging;
using Dicom.Imaging.Render;
using QCAnalyser.Imaging.Pixels;
using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Imaging.Parsers
{
    public class DICOMParser : ImageParser
    {
        #region "Fields"

        private DicomImage image;

        #endregion

        #region "Constructors"

        public DICOMParser(string filename)
        {
            image = new DicomImage(filename);
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public override Image Parse()
        {
            // Read the pixel data from the image, frame 0
            IPixelData pixelData = PixelDataFactory.Create(image.PixelData, 0);

            // Get the pixels from the pixel data
            ushort[] pixels = ((GrayscalePixelDataU16)pixelData).Data;

            // Get the multiplier
            int min = image.PixelData.BitDepth.MinimumValue;
            int max = image.PixelData.BitDepth.MaximumValue;

            if (min != 0)
                throw new FormatException("Error in the minimum value of the pixel data");

            float multiplier = ushort.MaxValue / max;

            // Apply the multiplier to the pixels
            U16Pixel[] normalizedPixels = new U16Pixel[pixels.Length];
            for (int i = 0; i < pixels.Length; i++)
            {
                normalizedPixels[i] = new U16Pixel((ushort)(pixels[i] * multiplier));
            }

            return Image.FromData(image.Width, image.Height, normalizedPixels);
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
