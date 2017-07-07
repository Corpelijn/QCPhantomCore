using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCPhantom.Domain.Nav
{
    public class NavMenuItem : NavClickable
    {
        #region "Fields"

        private int id;
        private int parent;
        private string icon;
        private List<NavMenuItem> subItems;
        private List<Tuple<string, NavColor>> notifications;

        #endregion

        #region "Constructors"

        public NavMenuItem(string text, string controller, string action, string icon = "fa-circle", int id = -1, int parent = -1) : base(text, controller, action)
        {
            this.id = id;
            this.parent = parent;
            this.icon = icon;

            subItems = new List<NavMenuItem>();
            notifications = new List<Tuple<string, NavColor>>();

            if (parent != -1)
            {
                NavMenuItem item = Navbar.FindParent(parent);
                item.subItems.Add(this);
            }
        }

        #endregion

        #region "Properties"

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        #endregion

        #region "Methods"

        private string GetHref()
        {
            if (controller == "")
                return "/";
            return "/" + controller + "/" + action;
        }

        private string TopMostSingleHtml()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<li class=\"\">");
            sb.Append("<a href=\"").Append(GetHref()).Append("\">");
            sb.Append("<i class=\"fa " + icon + "\"></i> <span>" + text + "</span>");
            sb.Append("<span class=\"pull-right-container\">");
            if (notifications.Count > 0)
            {
                IEnumerable<Tuple<string, NavColor>> notifis = notifications.ToArray().Reverse();
                foreach (Tuple<string, NavColor> not in notifis)
                {
                    string color = "bg-" + Enum.GetName(typeof(NavColor), not.Item2).ToLower();
                    sb.Append("<small class=\"label pull-right " + color + "\">" + not.Item1 + "</small>");
                }
            }
            else if (subItems.Count > 0)
                sb.Append("<i class=\"fa fa-angle-left pull-right\"></i>");
            sb.Append("</span>");
            sb.Append("</a>");
            sb.Append("</li>");

            return sb.ToString();
        }

        private string TopMostTreeHtmlBegin()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<li class=\"treeview\">");
            sb.Append("<a href=\"").Append(GetHref()).Append("\">");
            sb.Append("<i class=\"fa " + icon + "\"></i>");
            sb.Append("<span> " + text + "</span>");
            sb.Append("<span class=\"pull-right-container\">");
            if (notifications.Count > 0)
            {
                IEnumerable<Tuple<string, NavColor>> notifis = notifications.ToArray().Reverse();
                foreach (Tuple<string, NavColor> not in notifis)
                {
                    string color = "bg-" + Enum.GetName(typeof(NavColor), not.Item2).ToLower();
                    sb.Append("<small class=\"label pull-right " + color + "\">" + not.Item1 + "</small>");
                }
            }
            else
                sb.Append("<i class=\"fa fa-angle-left pull-right\"></i>");
            sb.Append("</span>");
            sb.Append("</a>");
            sb.Append("<ul class=\"treeview-menu\">");

            return sb.ToString();
        }

        private string TopMostTreeHtmlEnd()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("</ul>");
            sb.Append("</li>");

            return sb.ToString();
        }

        private string SubMenuItemHtml()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<li class=\"\"><a href=\"").Append(GetHref()).Append("\"><i class=\"fa fa-circle-o\"></i>" + text + "</a></li>");

            return sb.ToString();
        }

        private string SubMenuSubMenuParentHtmlBegin()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<li class=\"\">");
            sb.Append("<a href=\"").Append(GetHref()).Append("\">");
            sb.Append("<i class=\"fa fa-circle-o\"></i>").Append(text);
            sb.Append("<span class=\"pull-right-container\">");
            sb.Append("<i class=\"fa fa-angle-left pull-right\"></i>");
            sb.Append("</span>");
            sb.Append("</a>");
            sb.Append("<ul class=\"treeview-menu\">");

            return sb.ToString();
        }

        private string SubMenuSubMenuParentHtmlEnd()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("</ul>");
            sb.Append("</li>");

            return sb.ToString();
        }

        public NavMenuItem AddNotification(string message, NavColor color)
        {
            notifications.Add(new Tuple<string, NavColor>(message, color));
            return this;
        }

        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public override string ToHtml()
        {
            if (isDrawn)
                return "";

            isDrawn = true;

            if (parent == -1 && subItems.Count == 0)
                return TopMostSingleHtml();
            else if (parent == -1 && subItems.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(TopMostTreeHtmlBegin());

                foreach (NavMenuItem item in subItems)
                {
                    sb.Append(item.ToHtml());
                }

                sb.Append(TopMostTreeHtmlEnd());

                return sb.ToString();
            }
            else if (parent != -1 && subItems.Count == 0)
            {
                return SubMenuItemHtml();
            }
            else if (parent != -1 && subItems.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(SubMenuSubMenuParentHtmlBegin());

                foreach (NavMenuItem item in subItems)
                {
                    sb.Append(item.ToHtml());
                }

                sb.Append(SubMenuSubMenuParentHtmlEnd());

                return sb.ToString();
            }
            return "";
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
