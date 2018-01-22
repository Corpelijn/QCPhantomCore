using QCAnalyser.Imaging.Pixels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCAnalyser.Imaging.Kernel
{
    class KernelProcessor : IKernelProcessor
    {
        #region "Fields"

        private Image image;

        #endregion

        #region "Constructors"

        public KernelProcessor(Image image)
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

        public Image ProcessImage(Kernel kernel)
        {
            Image processed = new Image(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    List<double> grays = new List<double>();
                    foreach ((int, int, int) k in kernel)
                    {
                        grays.Add(image.GetPixel(x + k.Item1, y + k.Item2).Grayscale * k.Item3);
                    }

                    processed.SetPixel(x, y, new GrayPixel(grays.Average()));
                }
            }

            return processed;
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
