namespace QCAnalyser.Domain
{
    /// <summary>
    /// A public class that stores the information of a machine
    /// </summary>
    public class Machine
    {
        #region "Fields"

        private int id;
        private string name;
        private string serialNumber;
        private string publicName;
        private Detector[] defaultDetectors;

        #endregion

        #region "Constructors"

        public Machine(int id, string name, string serialNumber)
        {
            this.id = id;
            this.name = name;
            this.serialNumber = serialNumber;

            this.publicName = this.ToString();
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the unique database id of the machine
        /// </summary>
        public int Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// Gets the name of the machine
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets the serialnumber of the machine
        /// </summary>
        public string SerialNumber
        {
            get { return this.serialNumber; }
        }

        /// <summary>
        /// Gets the detectors configured by default on this machine
        /// </summary>
        public Detector[] DefaultDetectors
        {
            get { return this.defaultDetectors; }
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