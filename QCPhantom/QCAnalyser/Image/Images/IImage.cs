using QCAnalyser.Image.Pixels;
using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Image.Images
{
    public interface IImage
    {
        int Width { get; }

        int Height { get; }

        Pixel[] Pixels { get; }
    }
}
