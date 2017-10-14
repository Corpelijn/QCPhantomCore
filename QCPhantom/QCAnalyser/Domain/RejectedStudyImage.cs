using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Domain
{
    /// <summary>
    /// A public object to store a rejected image
    /// </summary>
    public class RejectedStudyImage : StudyImage
    {
        #region "Fields"

        private string reason;
        private string message;

        #endregion

        #region "Constructors"

        public RejectedStudyImage(int id, string imageUID, ImageStatus status, Machine machine, Detector detector, string analyseMethod, DateTime analyseTime, string reason, string message) 
            : base(id, imageUID, status, machine, detector, analyseMethod, analyseTime)
        {
            this.reason = reason;
            this.message = message;
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the reason why the image was rejected
        /// </summary>
        public string Reason
        {
            get { return this.reason; }
        }

        /// <summary>
        /// Gets the additional message given with the reason of rejection
        /// </summary>
        public string Message
        {
            get { return this.message; }
        }

        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
