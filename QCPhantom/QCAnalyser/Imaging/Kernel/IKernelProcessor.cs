using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Imaging.Kernel
{
    interface IKernelProcessor
    {
        Image ProcessImage(Kernel kernel);
    }
}
