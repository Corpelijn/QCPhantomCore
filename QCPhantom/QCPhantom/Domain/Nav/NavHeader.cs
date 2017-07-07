using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCPhantom.Domain.Nav
{
    public class NavHeader : NavItem
    {
        #region "Fields"



        #endregion

        #region "Constructors"

        public NavHeader(string text) : base(text)
        {

        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public override string ToHtml()
        {
            return "<li class=\"header\">" + text.ToUpper() + "</li>";
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
