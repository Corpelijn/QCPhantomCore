using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Imaging.Kernel
{
    public class Kernel :IEnumerable<(int,int, int)>
    {
        #region "Fields"

        private int width;
        private int height;
        private int[] values;

        #endregion

        #region "Constructors"

        public Kernel(int width, int height, params int[] values)
        {
            this.width = width;
            this.height = height;
            this.values = values;
        }

        #endregion

        #region "Properties"

        public int CenterX => -width / 2;

        public int CenterY => -height / 2;

        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public IEnumerator<(int, int, int)> GetEnumerator()
        {
            int startX = CenterX, startY = CenterY;
            foreach (int k in values)
            {
                yield return (startX, startY, k);
                startX++;
                if(startX >= width)
                {
                    startX = 0;
                    startY++;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
