using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QualityServices.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Top rated services";

            return View();
        }

        //[Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult About()
        {
            return RedirectToAction("Index", "BeautyHair");
        }
    }
}
