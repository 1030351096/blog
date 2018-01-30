using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webCore.services;

namespace webApi.Controllers
{
    public class HomeController : Controller
    {
        private IBlogServices blogServices;
        public HomeController(IBlogServices blogServices)
        {
            this.blogServices = blogServices;
        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        [HttpPost]
        public ActionResult About(HttpPostedFileBase file)
        {
            var fileName = file.FileName;
            var filePath = Server.MapPath("/File/");
            file.SaveAs(Path.Combine(filePath, fileName));
            return View();
        }
        [OutputCache(Duration = 5, VaryByParam = "nono")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.time = DateTime.Now;
            Response.Cache.SetOmitVaryStar(true);
            return View();
        }

        [HttpGet]
        public JsonResult Getlist()
        {
            string[] list = new string[] { "1", "2" };
            return Json(new { list = list }, JsonRequestBehavior.AllowGet);
        }

    }
}