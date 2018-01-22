using System;
using Microsoft.AspNetCore.Mvc;
using QCAnalyser.Domain;

namespace QCPhantom.Controllers
{
    public class ResultsController : Controller
    {
        private static Random rand = new Random();
        private static int staticid = -1;

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
        public IActionResult FilterResults(string orderby, string orderdirection, int index, int length)
        {
            object newData = new { url = "" };
            //if (staticid % 4 != 0)
            //    newData = new { url = "/Results/FilterResults?orderby=analysedate&orderdirection=asc&index=0&length=1" };

            return Json(new { studies = new object[] { Study.GenerateRandomStudy() }, data = newData });
        }

        private object GetImage()
        {
            return new { imageUID = "9234.9834.9849283.03498059348502.456", state = "In Orde", machine = "QC Light Kamer 5", detector = "Detector 4" };
        }

        private object GetStudy()
        {
            int r = rand.Next(1, 10);
            object[] images = new object[r];
            for (int i = 0; i < r; i++)
            {
                images[i] = GetImage();
            }

            return new { id = staticID, dateTime = "17 juni 2017 17:48", pacsAccession = "51234854", studyUID = "9234.9834.9849283.03498059348502.456", images = images };
        }

        public int staticID
        {
            get { staticid++; return staticid; }
        }
    }
}