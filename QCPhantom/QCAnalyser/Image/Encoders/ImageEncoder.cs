using QCAnalyser.Image.Markings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace QCAnalyser.Image.Encoders
{
    abstract class ImageEncoder
    {
        #region "Fields"

        protected string filename;
        protected int width;
        protected int height;
        protected Color[] pixels;
        ImageMarking[] markings;

        #endregion

        #region "Constructors"

        protected ImageEncoder(string filename, int width, int height, ushort[] pixels)
        {
            this.filename = filename;
            this.width = width;
            this.height = height;

            ParsePixels(pixels);
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        private void ParsePixels(ushort[] pixels)
        {
            this.pixels = new Color[pixels.Length];

            for (int i = 0; i < pixels.Length; i++)
            {
                byte b = (byte)(255f / 65535f * pixels[i]);

                this.pixels[i] = Color.FromArgb(b, b, b);
            }
        }

        protected void WriteProgress(long status, long total)
        {
            float progress = 100f / (float)total * (float)status;

            Console.Write(progress.ToString("0.0") + "%\t[");
            int bars = (int)(50f / 100f * progress);
            for (int i = 0; i < bars; i++)
            {
                Console.Write("=");
            }
            if (status != total)
                Console.Write(">");
            else
                Console.Write("=");
            for (int i = 0; i < 50 - bars; i++)
            {
                Console.Write(" ");
            }

            Console.Write("]    \r");
        }

        public void AddMarkings(ImageMarking[] markings)
        {
            foreach(ImageMarking marking in markings)
            {
                Point[] pixels = marking.Pixels.Where(x => x.X >= 0 && x.X <= width && x.Y >= 0 && x.Y <= height).ToArray();
                for (int i = 0; i < pixels.Length; i++)
                {
                    this.pixels[pixels[i].Y * width + pixels[i].X] = marking.Color;
                }
            }
        }

        #endregion

        #region "Abstract/Virtual Methods"

        public abstract void Write();

        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"

        public static void EncodeImage(string filename, ImageFormat format, int width, int height, ushort[] pixelData)
        {
            filename = format.CheckFilename(filename);

            ImageEncoder encoder = (ImageEncoder)Activator.CreateInstance(format.Encoder, filename, width, height, pixelData);

            if (encoder != null)
            {
                encoder.Write();
            }
        }

        public static void EncodeImage(string filename, ImageFormat format, int width, int height, ushort[] pixelData, ImageMarking[] markings)
        {
            filename = format.CheckFilename(filename);

            ImageEncoder encoder = (ImageEncoder)Activator.CreateInstance(format.Encoder, filename, width, height, pixelData);
            encoder.AddMarkings(markings);

            if (encoder != null)
            {
                encoder.Write();
            }
        }

        #endregion

        #region "Operators"



        #endregion
    }
}
