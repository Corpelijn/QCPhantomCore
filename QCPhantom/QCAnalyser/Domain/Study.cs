using System;
using System.Collections.Generic;
using System.Text;

namespace QCAnalyser.Domain
{
    /// <summary>
    /// A public class to store the information of a study
    /// </summary>
    public class Study
    {
        #region "Fields"

        private long id;
        private string studyUID;
        private DateTime studyDate;
        private string pacsAccession;
        private Machine[] machines;
        private Detector[] detectors;
        private StudyImage[] images;

        #endregion

        #region "Constructors"

        public Study(int id, string studyUID, DateTime studyDate, string pacsAccession)
        {
            this.id = id;
            this.studyUID = studyUID;
            this.studyDate = studyDate;
            this.pacsAccession = pacsAccession;
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the unique database id of the study
        /// </summary>
        public long Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// Gets the studyUID of the study
        /// </summary>
        public string StudyUID
        {
            get { return this.studyUID; }
        }

        /// <summary>
        /// Gets the PACS Accessionnumber of the study
        /// </summary>
        public string PacsAccession
        {
            get { return this.pacsAccession; }
        }

        /// <summary>
        /// Gets the machines the images of this study were made on
        /// </summary>
        public Machine[] Machines
        {
            get { return this.machines; }
        }

        /// <summary>
        /// Gets the detectors the images of this study were take on
        /// </summary>
        public Detector[] Detectors
        {
            get { return this.detectors; }
        }

        /// <summary>
        /// Gets the image objects containing information of the images
        /// </summary>
        public StudyImage[] Images
        {
            get { return this.images; }
        }

        public DateTime StudyDate
        {
            get { return studyDate; }
        }

        #endregion

        #region "Methods"

        /// <summary>
        /// Adds an image to the array of images in the study
        /// </summary>
        /// <param name="image">The image information to add at the end of the array</param>
        public void AddImage(StudyImage image)
        {
            // Resize the array to the correct size
            if (images == null)
                images = new StudyImage[1];
            else
                Array.Resize(ref images, images.Length + 1);

            // Add the image information at the end of the array
            images[images.Length - 1] = image;

            // Update the machines and detectors of the study
            UpdateMachinesAndDetectors();
        }

        /// <summary>
        /// Updates the machines and detectors in the study from the containing images
        /// </summary>
        private void UpdateMachinesAndDetectors()
        {
            // Define new lists to store data
            List<Machine> foundMachines = new List<Machine>();
            List<Detector> foundDetectors = new List<Detector>();

            // Loop through the images in the study
            foreach (StudyImage image in images)
            {
                // Check if the machine exists in the list of already found machines; otherwise add it
                if (!foundMachines.Contains(image.Machine))
                    foundMachines.Add(image.Machine);
                // Check if the detector exists in the list of alread found detectors; otherwise add it
                if (!foundDetectors.Contains(image.Detector))
                    foundDetectors.Add(image.Detector);
            }

            // Set the lists to the arrays in the study
            this.machines = foundMachines.ToArray();
            this.detectors = foundDetectors.ToArray();
        }

        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"

        public static Study GenerateRandomStudy()
        {
            Random rand = new Random();
            Study study = new Study(rand.Next(0, 100), "1.3.12.2.1107.5.12.3.1044.8.0.5102" + rand.Next(10000000, 99999999), DateTime.Now, rand.Next(1000100000, 1000999999).ToString());

            Machine machine = new Machine(rand.Next(0, 100), "QC Light kamer " + rand.Next(1, 10), rand.Next(1000000, 9999999).ToString());
            Detector detector = new Detector(rand.Next(0, 100), "Detector " + rand.Next(1, 10), rand.Next(1000000, 9999999).ToString());

            StudyImage image = new StudyImage(rand.Next(0, 100), "1.3.12.2.1107.5.12.3.1044.6.0.2234" + rand.Next(10000000, 99999999).ToString(), ImageStatus.Good, machine, detector, "PIX-13 Automatic", DateTime.Now);
            study.AddImage(image);

            return study;
        }

        #endregion

        #region "Operators"



        #endregion
    }
}
