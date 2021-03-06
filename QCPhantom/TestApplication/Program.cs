﻿using PIX13;
using QCAnalyser;
using QCAnalyser.Image;
using QCAnalyser.Image.Encoders;
using QCAnalyser.Image.Images;
using QCAnalyser.Image.Markings;
using QCAnalyser.Image.Parsers;
using System;
using System.Diagnostics;
using System.Drawing;
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
            DICOMImage image = parser.Parse();

            sw.Stop();

            Console.WriteLine("\n" + sw.ElapsedMilliseconds + " ms");

            sw.Reset();

            Console.WriteLine("Start Phantom detection");

            sw.Start();

            ImageAnalyser analyser = new PIX13Analyser(image);
            analyser.AnalyseImage();
            //analyser.IsCorrectPhantom();

            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds + " ms");

            sw.Reset();

            Console.WriteLine("Writing output image");

            sw.Start();

            //image.AddMarking(new CircleMarking(Color.FromArgb(255, 0, 0), new Point(100, 100), 30));
            image.SaveImage(filename, ImageFormat.PNG);

            sw.Stop();

            Console.WriteLine("\n" + sw.ElapsedMilliseconds + " ms");
            Console.WriteLine("Done!");

            Console.ReadKey();
        }
    }
}