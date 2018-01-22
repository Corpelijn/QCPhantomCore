using QCAnalyser.Imaging.Encoders;
using QCAnalyser.Imaging.Pixels;
using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Imaging.Kernel
{
    public class SobelEdgeDetection : IImageProcessor
    {
        #region "Fields"

        private Image image;

        #endregion

        #region "Constructors"

        public SobelEdgeDetection(Image image)
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

        public Image ProcessImage()
        {
            // Create a kernel processor
            IKernelProcessor processor = new KernelProcessor(image);
            
            // Create a horizontal and vertical kernel
            Kernel horizontalKernel = new Kernel(3, 3,
                1, 2, 1,
                0, 0, 0,
                -1, -2, -1);
            Kernel verticalKernel = new Kernel(3, 3,
                1, 0, -1,
                2, 0, -2,
                1, 0, -1);

            // Parse the image twice with the horizontal and vertical kernel
            Image horizontalEdges = processor.ProcessImage(horizontalKernel);
            Image verticalEdges = processor.ProcessImage(verticalKernel);

            Image edges = new Image(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    double Gx = horizontalEdges.GetPixel(x, y).Grayscale;
                    double Gy = verticalEdges.GetPixel(x, y).Grayscale;
                    edges.SetPixel(x, y, new GrayPixel(Math.Sqrt(Gx * Gx + Gy * Gy)));
                }
            }

            horizontalEdges.SaveToFile("./../Testdata/horizontal", ImageFormat.BMP);
            verticalEdges.SaveToFile("./../Testdata/vertical", ImageFormat.BMP);
            edges.SaveToFile("./../Testdata/edges", ImageFormat.BMP);

            return edges;
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
