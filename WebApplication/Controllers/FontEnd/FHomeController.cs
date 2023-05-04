using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.FontEnd;
using WebApplication.Models;

namespace WebApplication.Controllers.FontEnd
{
    public class FHomeController : Controller
    {
        // GET: FHome
        ProductsDB proDB = new ProductsDB();
        CustomersDB cusDB = new CustomersDB();
        OrderPaymentDB orderDB = new OrderPaymentDB();
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
        public ActionResult Login00()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult ConductingPayment()
        {
            return View();
        }
        public ActionResult OrderLookup()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PaymentSuccess(string Id_order)
        {
            var order = orderDB.ListAll().Where(x => x.IdCustomer.Equals(Id_order));
            return View(order);
        }
        [HttpGet]
        public ActionResult SearchProducts(string search)
        {
            ViewData["search"] = search;
            var order = proDB.SearchProducts(search);
            return View(order);
            //return View();
        }
        public JsonResult List()
        {
            return Json(proDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Productdetails(int Id)
        {
            var Product = proDB.ListAll().Find(x => x.Id.Equals(Id));
            return View(Product);
        }
        [HttpPost]
        public JsonResult CreateCustomers(Users user)
        {
            return Json(cusDB.Add(user), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult BuyPayment(OrderPayment order, List<Carts> carts)
        {
            OrderPayment orderPayment = order;
            List<Carts> cartPayment = carts;
            int i;
            return Json(new { Id_order = orderDB.Add(orderPayment, cartPayment, out int succes), succes = succes }, JsonRequestBehavior.AllowGet); ;
        }

        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            //HttpCookie reqCookies = Request.Cookies["UserInfo-DangVien"];
            //login.password = GetMD5(login.password);
            //var data = Account.CheckAccount(login);
            if (CheckCustomersDB(username, password) != false)
            {
                ////add session
                Session["username"] = username;
                Session["password"] = password;
                return Json(new { connect = "1" }, JsonRequestBehavior.AllowGet);

                //return RedirectToAction("/BAdministrator");
            }
            else
            {
                ViewBag.check = 1;
                return Json(new { connect = "0" }, JsonRequestBehavior.AllowGet);

                //return PartialView("../Shared/Login");
            }
        }
        [HttpGet]
        public ActionResult logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("/");
        }
        public bool CheckCustomersDB(string username, string password)
        {
            WebApplication.BackEnd.AdministratorsDB adminDB = new WebApplication.BackEnd.AdministratorsDB();
            if (username != null && password != null)
            {
                var userPass = (cusDB.ListCusAll().Find(x => x.username.Equals(username)) == null ? "" : cusDB.ListCusAll().Find(x => x.username.Equals(username)).password);
                if (userPass == password)
                {
                    return true;
                }
            }
            return false;
        }

    }
}