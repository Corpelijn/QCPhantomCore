
using QCAnalyser.Imaging.Pixels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QCAnalyser.Imaging.Parsers
{
    public class PNMImageParser : ImageParser
    {
        #region "Fields"

        private string filename;
        private float multiplier;
        private IPixel[] pixelData;
        private int width;
        private int height;

        #endregion

        #region "Constructors"

        public PNMImageParser(string filename)
        {
            this.filename = filename;
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        private void WriteProgress(long status, long total)
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

            Console.Write("]     \r");
        }

        private void ReadData()
        {
            string imgData = File.ReadAllText(filename);
            string[] data = imgData.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Read the file header
            if (data[0] != "P2")
                throw new FormatException("Incorrect file format");

            // Read width and height
            width = Convert.ToInt32(data[1]);
            height = Convert.ToInt32(data[2]);

            // Calculate a multiplier
            int mult = Convert.ToInt32(data[3]);
            multiplier = (float)ushort.MaxValue / (float)mult;

            List<IPixel> pixels = new List<IPixel>();
            for (int i = 4; i < data.Length; i++)
            {
                pixels.Add(new U16Pixel(Convert.ToUInt16(data[i])));
                if (i % 500000 == 0)
                    WriteProgress(i, data.Length - 4);
            }

            pixelData = pixels.ToArray();

            WriteProgress(1, 1);
        }

        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public override Image Parse()
        {
            ReadData();

            return Image.FromData(width, height, pixelData);
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
