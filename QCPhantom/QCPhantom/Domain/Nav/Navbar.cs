using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCPhantom.Domain.Nav
{
    public class Navbar
    {
        #region "Fields"

        private List<NavItem> items;

        private static List<NavItem> allItems = new List<NavItem>();

        #endregion

        #region "Constructors"

        public Navbar()
        {
            items = new List<NavItem>();

            Init();
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        private void Init()
        {
            allItems.Clear();

            items.Add(new NavHeader("Main Navigation"));
            items.Add(new NavMenuItem("Dashboard", "Home", "Index", "fa-dashboard"));
            items.Add(new NavMenuItem("Foto's ophalen", "Home", "Import", "fa-download"));
            items.Add(new NavMenuItem("Help", "Home", "Help", "fa-book"));

            items.Add(new NavHeader("Resultaten"));
            items.Add(new NavMenuItem("Overzicht", "Results", "Overview", "fa-table", id: 20));
            items.Add(new NavMenuItem("Grafieken", "Results", "Graph", "fa-bar-chart"));

            items.Add(new NavHeader("Configuratie"));
            items.Add(new NavMenuItem("Globale instellingen", "Settings", "Global", "fa-cog", id: 30));
            items.Add(new NavMenuItem("Apparaat instellingen", "Settings", "Devices", "fa-video-camera", id: 31));
            items.Add(new NavMenuItem("Detectors", "Settings", "Detector", "", parent: 31));
            items.Add(new NavMenuItem("Machine", "Settings", "Machine", "", parent: 31));
            items.Add(new NavMenuItem("Fantoom instellingen", "Settings", "", "fa-caret-square-o-left", id: 32));
            items.Add(new NavMenuItem("PIX-13 instellingen", "Settings", "PIX-13", "", parent: 32));

            // The original navigation menu (source: AdminLTE2)
            //items.Add(new NavHeader("Main navigation"));

            //items.Add(new NavMenuItem("Dashboard", "", "", id: 0, icon: "fa-dashboard"));
            //items.Add(new NavMenuItem("Dashboard v1", "Home", "Contact", parent: 0));
            //items.Add(new NavMenuItem("Dashboard v2", "Home", "Index", parent: 0));

            //items.Add(new NavMenuItem("Layout Options", "", "", id: 1, icon: "fa-files-o")
            //    .AddNotification("4", NavColor.Blue));
            //items.Add(new NavMenuItem("Top Navigation", "", "", parent: 1));
            //items.Add(new NavMenuItem("Boxed", "", "", parent: 1));
            //items.Add(new NavMenuItem("Fixed", "", "", parent: 1));
            //items.Add(new NavMenuItem("Collapsed Sidebar", "", "", parent: 1));

            //items.Add(new NavMenuItem("Widgets", "", "", "fa-th")
            //    .AddNotification("new", NavColor.Green));

            //items.Add(new NavMenuItem("Charts", "", "", "fa-pie-chart", id: 2));
            //items.Add(new NavMenuItem("ChartJS", "", "", parent: 2));
            //items.Add(new NavMenuItem("Morris", "", "", parent: 2));
            //items.Add(new NavMenuItem("Flot", "", "", parent: 2));
            //items.Add(new NavMenuItem("Inline charts", "", "", parent: 2));

            //items.Add(new NavMenuItem("UI Elements", "", "", "fa-laptop", id: 3));
            //items.Add(new NavMenuItem("General", "", "", parent: 3));
            //items.Add(new NavMenuItem("Icons", "", "", parent: 3));
            //items.Add(new NavMenuItem("Buttons", "", "", parent: 3));
            //items.Add(new NavMenuItem("Sliders", "", "", parent: 3));
            //items.Add(new NavMenuItem("Timeline", "", "", parent: 3));
            //items.Add(new NavMenuItem("Modals", "", "", parent: 3));

            //items.Add(new NavMenuItem("Forms", "", "", "fa-edit", id: 4));
            //items.Add(new NavMenuItem("General Elements", "", "", parent: 4));
            //items.Add(new NavMenuItem("Advanced Elements", "", "", parent: 4));
            //items.Add(new NavMenuItem("Editors", "", "", parent: 4));

            //items.Add(new NavMenuItem("Tables", "", "", "fa-table", id: 5));
            //items.Add(new NavMenuItem("Simple tables", "", "", parent: 5));
            //items.Add(new NavMenuItem("Data tables", "", "", parent: 5));

            //items.Add(new NavMenuItem("Calendar", "", "", "fa-calendar")
            //    .AddNotification("17", NavColor.Blue)
            //    .AddNotification("3", NavColor.Red));
            //items.Add(new NavMenuItem("Mailbox", "", "", "fa-envelope")
            //    .AddNotification("5", NavColor.Red)
            //    .AddNotification("16", NavColor.Green)
            //    .AddNotification("12", NavColor.Yellow));

            //items.Add(new NavMenuItem("Examples", "", "", "fa-folder", id: 6));
            //items.Add(new NavMenuItem("Invoice", "", "", parent: 6));
            //items.Add(new NavMenuItem("Profile", "", "", parent: 6));
            //items.Add(new NavMenuItem("Login", "", "", parent: 6));
            //items.Add(new NavMenuItem("Register", "", "", parent: 6));
            //items.Add(new NavMenuItem("Lockscreen", "", "", parent: 6));
            //items.Add(new NavMenuItem("404 Error", "", "", parent: 6));
            //items.Add(new NavMenuItem("500 Error", "", "", parent: 6));
            //items.Add(new NavMenuItem("Blank Page", "", "", parent: 6));
            //items.Add(new NavMenuItem("Pace Page", "", "", parent: 6));

            //items.Add(new NavMenuItem("Multilevel", "", "", "fa-share", id: 7));
            //items.Add(new NavMenuItem("Level One", "", "", parent: 7));
            //items.Add(new NavMenuItem("Level One", "", "", parent: 7, id: 8));
            //items.Add(new NavMenuItem("Level One", "", "", parent: 7));

            //items.Add(new NavMenuItem("Level Two", "", "", parent: 8));
            //items.Add(new NavMenuItem("Level Two", "", "", parent: 8, id: 9));

            //items.Add(new NavMenuItem("Level Three", "", "", parent: 9));
            //items.Add(new NavMenuItem("Level Three", "Home", "About", parent: 9));

            //items.Add(new NavMenuItem("Documentation", "", "", "fa-book"));

            //items.Add(new NavHeader("Labels"));
            //items.Add(new NavLabel("Important", "", "", NavColor.Red));
            //items.Add(new NavLabel("Warning", "", "", NavColor.Yellow));
            //items.Add(new NavLabel("Information", "", "", NavColor.Blue));
        }

        public string ToHtml()
        {
            StringBuilder sb = new StringBuilder();

            foreach (NavItem item in items)
            {
                sb.Append(item.ToHtml());
            }

            return sb.ToString();
        }

        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"

        public static NavMenuItem FindParent(int id)
        {
            NavItem[] array = allItems.Where(x => x.GetType() == typeof(NavMenuItem)).ToArray();
            NavMenuItem[] menuItems = new NavMenuItem[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                menuItems[i] = (NavMenuItem)array[i];
            }
            return menuItems.FirstOrDefault(x => x.Id == id);
        }

        public static void AddItem(NavItem item)
        {
            allItems.Add(item);
        }

        #endregion

        #region "Operators"



        #endregion
    }
}
