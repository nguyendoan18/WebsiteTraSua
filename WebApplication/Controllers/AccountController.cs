using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index(Login login)
        {
            try
            {
                return PartialView("../Shared/Login");
            }
            catch (Exception)
            {
                return PartialView("../Shared/Login");
            }

        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            //HttpCookie reqCookies = Request.Cookies["UserInfo-DangVien"];
            //login.password = GetMD5(login.password);
            //var data = Account.CheckAccount(login);
            if (CheckUserPass(username, password) != false)
            {
                ////add session
                Session["username"] = username;
                Session["password"] = password;
                return RedirectToAction("/BAdministrator");
            }
            else
            {
                ViewBag.check = 1;
                return PartialView("../Shared/Login");
            }
        }
        [HttpGet]
        public ActionResult logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("../BAdministrator");
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