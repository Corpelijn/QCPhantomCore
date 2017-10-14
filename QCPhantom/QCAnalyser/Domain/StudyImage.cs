using System;

namespace QCAnalyser.Domain
{
    /// <summary>
    /// A public object containing information about the image in a study
    /// </summary>
    public class StudyImage
    {
        #region "Fields"

        private long id;
        private string imageUID;
        private ImageStatus status;
        private Machine machine;
        private Detector detector;
        private string analyseMethod;
        private DateTime analyseTime;

        #endregion

        #region "Constructors"

        public StudyImage(int id, string imageUID, ImageStatus status, Machine machine, Detector detector, string analyseMethod, DateTime analyseTime)
        {
            this.id = id;
            this.imageUID = imageUID;
            this.status = status;
            this.machine = machine;
            this.detector = detector;
            this.analyseMethod = analyseMethod;
#warning Needs to be changed
            this.analyseTime = DateTime.Now;
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the uniquq id of the image in the database
        /// </summary>
        public long Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// Gets the ImageUID of the image and study
        /// </summary>
        public string ImageUID
        {
            get { return this.imageUID; }
        }

        /// <summary>
        /// Gets the status of the image after analysing
        /// </summary>
        public ImageStatus Status
        {
            get { return this.status; }
        }

        /// <summary>
        /// Gets the machine the image was taken on
        /// </summary>
        public Machine Machine
        {
            get { return this.machine; }
        }

        /// <summary>
        /// Gets the detector the image was taken on
        /// </summary>
        public Detector Detector
        {
            get { return this.detector; }
        }

        /// <summary>
        /// Gets the method used to analyse the image
        /// </summary>
        public string AnalyseMethod
        {
            get { return this.analyseMethod; }
        }

        /// <summary>
        /// Gets the date and time whe
        /// </summary>
        public DateTime AnalyseTime
        {
            get { return this.analyseTime; }
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