using QCAnalyser.Image.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Image.Kernel
{
    interface IKernelImageProcessor
    {
        DrawableImage ProcessImage(Kernel kernel);
    }
}
