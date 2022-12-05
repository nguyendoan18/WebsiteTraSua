using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BackEnd;
using WebApplication.Models;

namespace WebApplication.Controllers.BackEnd
{
    public class BProductController : Controller
    {
        // GET: BProduct
        ProductsDB proDB = new ProductsDB();

        public ActionResult Index(string namepage)
        {
            ViewData["ActionPage"] = (namepage==null ? "ShowProducts" : namepage);
            return PartialView();
        }
        

        [HttpPost]
        public JsonResult CreateProduct(Users user)
        {
            return Json(proDB.Add(user), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateProduct(Users user)
        {
            return Json(proDB.Update(user), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DeleteProduct(int Id)
        {
            return Json(proDB.Delete(Id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListProduct()
        {
            return Json(proDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
    }
}