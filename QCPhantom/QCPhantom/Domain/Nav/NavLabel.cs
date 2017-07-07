using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCPhantom.Domain.Nav
{
    public class NavLabel : NavClickable
    {
        #region "Fields"

        private NavColor color;

        #endregion

        #region "Constructors"

        public NavLabel(string text, string controller, string action, NavColor color) : base(text, controller, action)
        {
            this.color = color;
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
            string color = "text-";
            if (this.color == NavColor.Red)
                color += "red";
            else if (this.color == NavColor.Yellow)
                color += "yellow";
            else if (this.color == NavColor.Blue)
                color += "aqua";

            return "<li><a href=\"#\"><i class=\"fa fa-circle-o " + color + "\"></i><span>" + text + "</span></a></li>";
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
