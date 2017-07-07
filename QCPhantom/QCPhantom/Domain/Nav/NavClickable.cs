using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCPhantom.Domain.Nav
{
    public abstract class NavClickable : NavItem
    {
        #region "Fields"

        protected string controller;
        protected string action;

        #endregion

        #region "Constructors"

        public NavClickable(string text, string controller, string action) : base(text)
        {
            this.controller = controller;
            this.action = action;
        }

        #endregion

        #region "Properties"

        public string Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public override abstract string ToHtml();

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
