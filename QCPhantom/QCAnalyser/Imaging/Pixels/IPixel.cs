using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Imaging.Pixels
{
    public interface IPixel : ICloneable
    {
        byte Red { get; }

        byte Green { get; }

        byte Blue { get; }

        byte Alpha { get; }

        double Grayscale { get; }

        uint Value { get; }
    }
}
