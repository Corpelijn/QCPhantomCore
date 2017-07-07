using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QCPhantom.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult _Topbar()
        {
            return PartialView();
        }

        public IActionResult _NavbarLeft()
        {
            return PartialView();
        }

        public IActionResult _NavbarRight()
        {
            return PartialView();
        }

        public IActionResult _Footer()
        {
            return PartialView();
        }
    }
}
