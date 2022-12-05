using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication.BackEnd;
using WebApplication.Models;

namespace WebApplication.Controllers.BackEnd
{
    public class BAdministratorController : Controller
    {
        // GET: BAdministrator
        AdministratorsDB adminDB = new AdministratorsDB();
        [HttpGet]
        public ActionResult Index(string namepage)
        {
            ViewData["ActionPage"] = (namepage==null ? "HomePage" : namepage);
            return PartialView();
        }

        [HttpPost]
        public JsonResult CreateAdministrators(Users user)
        {
            return Json(adminDB.Add(user), JsonRequestBehavior.AllowGet);
        }
    }
}