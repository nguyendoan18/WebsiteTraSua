using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.FontEnd;

namespace WebApplication.Controllers.FontEnd
{
    public class FHomeController : Controller
    {
        // GET: FHome
        ProductsDB proDB = new ProductsDB();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Introduce()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult News()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(proDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
    }
}