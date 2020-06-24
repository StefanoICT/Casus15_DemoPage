using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casus15_DemoPage.FaceRecognition;
using Casus15_DemoPage.Models;

namespace Casus15_DemoPage.Controllers
{
    public class HomeController : Controller
    {
        public Point lookingAtScreen = new Point();
        public ActionResult Index()
        {
            ViewBag.Title = "Home";

            FaceOrientation orien = new FaceOrientation();
            var lll = orien.FaceOrient();
            
            //foreach (var face in orien.faceList){
            //    lookingAtScreen = orien.CountFacesLookingAtScreen(face);
            //}
            var test = orien.lookingAtBoard;

            ViewBag.Title = test;
            return View(test);
        }
    }
}
