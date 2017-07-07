using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCPhantom.Domain.Nav
{
    public abstract class NavItem
    {
        #region "Fields"

        protected int uniqueId;
        protected string text;
        protected bool isDrawn;

        private static int nextUniqueId = 0;

        #endregion

        #region "Constructors"

        public NavItem(string text)
        {
            uniqueId = GetNextUniqueId();
            this.text = text;

            Navbar.AddItem(this);
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public int UniqueID
        {
            get { return uniqueId; }
        }

        #endregion

        #region "Abstract/Virtual Methods"

        public abstract string ToHtml();

        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"

        private static int GetNextUniqueId()
        {
            int next = nextUniqueId;
            nextUniqueId++;
            return next;
        }

        #endregion

        #region "Operators"



        #endregion
    }
}
