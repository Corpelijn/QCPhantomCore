using PIX13;
using QCAnalyser;
using QCAnalyser.Imaging;
using QCAnalyser.Imaging.Encoders;
using QCAnalyser.Imaging.Helpers;
using QCAnalyser.Imaging.Markings;
using QCAnalyser.Imaging.Parsers;
using QCAnalyser.Imaging.Pixels;
using System;
using System.Diagnostics;
using System.Threading;

namespace TestApplication
{
    class Program
    {
        const string filename = @"..\TestData\00000001.dcm";

        static void Main(string[] args)
        {
            Console.WriteLine("Read DICOM image file");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            ImageParser parser = new DICOMParser(filename);
            Image image = parser.Parse();

            sw.Stop();

            Console.WriteLine("\n" + sw.ElapsedMilliseconds + " ms");

            sw.Reset();

            Console.WriteLine("Start Phantom detection");

            sw.Start();

            ImageAnalyser analyser = new PIX13Analyser(image);
            analyser.IsCorrectPhantom();

            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds + " ms");

            sw.Reset();

            Console.WriteLine("Writing output image");

            sw.Start();

            image.AddMarking(new CircleMarking(new RGBAPixel(255,0,0), new Point(100, 100), 30));
            image.SaveToFile(filename, ImageFormat.BMP);

            sw.Stop();

            Console.WriteLine("\n" + sw.ElapsedMilliseconds + " ms");
            Console.WriteLine("Done!");

            Console.ReadKey();
        }
    }
}