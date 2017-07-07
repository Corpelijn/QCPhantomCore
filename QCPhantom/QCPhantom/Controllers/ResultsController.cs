using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QCPhantom.Domain.Other;

namespace QCPhantom.Controllers
{
    public class ResultsController : Controller
    {
        [HttpGet]
        public IActionResult StudyResult(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Overview()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FilterResults()
        {
            return Json(new { name = "value" });
        }
    }
}