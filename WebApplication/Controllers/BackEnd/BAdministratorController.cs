using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            if (Session["username"] != null && CheckUserPass(Session["username"].ToString(), Session["password"].ToString()))
            {
                ViewData["ActionPage"] = (namepage == null ? "HomePage" : namepage);
                return PartialView();
            }
            else
            {
                return PartialView("../Shared/Login");
            }
            
        }

        [HttpPost]
        public JsonResult CreateAdministrators(Users user)
        {
            return Json(adminDB.Add(user), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateAdministrators(Users user)
        {
            return Json(adminDB.Update(user), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DeleteAdministrators(int Id)
        {
            return Json(adminDB.Delete(Id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListAdministrators()
        {
            return Json(adminDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Login(string username, string password)
        {
            CheckUserPass(username, password);
            ViewData["ActionPage"] = "HomePage";
            if (username == "" && password == "")
            {
                return RedirectToAction("../Shared/Login");
            }
            return PartialView();
        }
        public bool CheckUserPass(string username, string password)
        {

            WebApplication.BackEnd.AdministratorsDB adminDB = new WebApplication.BackEnd.AdministratorsDB();
            if (username != null && password != null)
            {
                var userPass = (adminDB.ListAll().Find(x => x.username.Equals(username)) == null ? "" : adminDB.ListAll().Find(x => x.username.Equals(username)).password);
                if (userPass == password)
                {
                    return true;
                }
            }
            return false;

        }
    }
}