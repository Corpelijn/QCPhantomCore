namespace QCAnalyser.Domain
{
    /// <summary>
    /// A public class containing information of a detector
    /// </summary>
    public class Detector
    {
        #region "Fields"

        private int id;
        private string name;
        private string serialNumber;
        private string publicName;
        private Machine[] defaultMachines;

        #endregion

        #region "Constructors"

        public Detector(int id, string name, string serialNumber)
        {
            this.id = id;
            this.name = name;
            this.serialNumber = serialNumber;

            this.publicName = this.ToString();
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the unique id of the detector in the database
        /// </summary>
        public int Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// Gets the name of the detector
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets the serialnumber of the detector
        /// </summary>
        public string SerialNumber
        {
            get { return this.serialNumber; }
        }

        /// <summary>
        /// Gets the default machines this detector is configured for
        /// </summary>
        public Machine[] DefaultMachines
        {
            get { return this.defaultMachines; }
        }

        public string PublicName
        {
            get { return publicName; }
        }

        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public override string ToString()
        {
            return this.name;
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}