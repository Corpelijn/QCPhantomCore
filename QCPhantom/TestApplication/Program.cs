using QCAnalyser.Image;
using QCAnalyser.Image.DICOM;
using System;
using System.Diagnostics;
using System.Threading;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start parsing image data");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            ImageParser parser = new PNMImageParser(@"J:\LZR QCPhantom\DICOMOBJ\DICOMOBJ\image5.dcm.pnm");
            DICOMImage image = parser.Parse();

            sw.Stop();

            Console.WriteLine("\n" + sw.ElapsedMilliseconds + " ms");

            sw.Reset();
            sw.Start();

            //image.WritePng(@"J:\LZR QCPhantom\DICOMOBJ\DICOMOBJ\image5.dcm.png");
            image.WriteBmp(@"J:\LZR QCPhantom\DICOMOBJ\DICOMOBJ\image5.dcm.bmp");
            sw.Stop();

            Console.WriteLine("\n" + sw.ElapsedMilliseconds + " ms");

            Console.ReadKey();
        }
    }
}