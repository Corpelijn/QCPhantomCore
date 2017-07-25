﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace QCAnalyser.Image.Helpers
{
    public static class PointExtensions
    {
        public static Point Add(this Point p, Point add)
        {
            return new Point(p.X + add.X, p.Y + add.Y);
        }
    }
}
