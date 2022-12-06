using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            ViewData["ActionPage"] = (namepage == null ? "ShowProducts" : namepage);
            return PartialView();
        }


        [HttpPost]
        public JsonResult CreateProduct(Users user)
        {
            return Json(proDB.Add(user), JsonRequestBehavior.AllowGet);
        }
        public class FileUpload{
            Products product = new Products();
            HttpPostedFileBase image { get; set; }
        }

        [HttpPost, AllowAnonymous]
        public JsonResult UpdateProduct(Products product, HttpPostedFileBase image)
        {
            return Json(proDB.Update(new Products { Id = product.Id, 
                title = product.title,
                description = product.description,
                price = product.price,
                image = (image == null ? "" : image.FileName),
                category = product.category
            }), JsonRequestBehavior.AllowGet) ;
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
        public JsonResult ListCategory()
        {
            return Json(proDB.ListCategory(), JsonRequestBehavior.AllowGet);
        }
    }
}