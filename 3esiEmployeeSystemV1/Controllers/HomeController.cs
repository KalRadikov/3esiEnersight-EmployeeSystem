using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using _3esiEmployeeSystemV1.ViewModels;
using _3esiEmployeeSystemV1.Models;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using _3esiEmployeeSystemV1.Models.Employee;
using ClosedXML.Excel;

namespace _3esiEmployeeSystemV1.Controllers
{
    public class HomeController : Controller
    {

        private EmployeeDBContext db = new EmployeeDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "This is the About Page";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //[HttpPost]
        //public ActionResult GetDefault(int? val)
        //{
        //    if (val != null)
        //    {
        //        if (val.Equals())
        //    }
        //    return Json(new { Success = "false" });
        //}

    }
}