using QCAnalyser.Image.Encoders;
using QCAnalyser.Image.Markings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace QCAnalyser.Image
{
    public class DICOMImage
    {
        #region "Fields"

        protected ushort[] pixels;
        protected int width;
        protected int height;
        private List<ImageMarking> markings;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Create a new, empty instance of a DICOMImage
        /// </summary>
        /// <param name="width">The amount of pixels on the x-axis</param>
        /// <param name="height">The amount of pixels on the y-axis</param>
        protected DICOMImage(int width, int height)
        {
            this.width = width;
            this.height = height;

            pixels = new ushort[width * height];
            markings = new List<ImageMarking>();
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the width of the image (Read-only)
        /// </summary>
        public int Width
        {
            get { return width; }
        }

        /// <summary>
        /// Gets the height of the image (Read-only)
        /// </summary>
        public int Height
        {
            get { return height; }
        }

        #endregion

        #region "Methods"

        /// <summary>
        /// Gets a pixel from the image a the given position
        /// </summary>
        /// <param name="x">The x coordinate of the pixel</param>
        /// <param name="y">The y coordinate of the pixel</param>
        /// <returns>The value of the pixel at the given position</returns>
        public ushort GetPixel(int x, int y)
        {
            return pixels[y * width + x];
        }

        /// <summary>
        /// Sets a pixel in the image at the given position
        /// </summary>
        /// <param name="x">The x coordinate of the pixel</param>
        /// <param name="y">The y coordinate of the pixel</param>
        /// <param name="value">The new value of the pixel</param>
        public void SetPixel(int x, int y, ushort value)
        {
            pixels[y * width + x] = value;
        }

        /// <summary>
        /// Write the image to a file
        /// </summary>
        /// <param name="filename">The destination filename for the image</param>
        /// <param name="format">The image format to store the image in</param>
        public void SaveImage(string filename, ImageFormat format)
        {
            if (markings.Count > 0)
            {
                ImageEncoder.EncodeImage(filename, format, width, height, pixels, markings.ToArray());
            }
            else
            {
                ImageEncoder.EncodeImage(filename, format, width, height, pixels);
            }
        }   
        
        public void AddMarking(ImageMarking marking)
        {
            markings.Add(marking);
        }

        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"

        /// <summary>
        /// Create a new DICOMImage from the given data.
        /// </summary>
        /// <param name="width">The width of the new image</param>
        /// <param name="height">The height of the new image</param>
        /// <param name="pixels">The pixels data of the new image. MIN: 0, MAX: 65535</param>
        /// <returns>A new instance of a DICOMImage</returns>
        public static DICOMImage FromData(int width, int height, ushort[] pixels)
        {
            DICOMImage image = new DICOMImage(width, height);
            image.pixels = pixels;
            return image;
        }

        #endregion

        #region "Operators"



        #endregion
    }
}
