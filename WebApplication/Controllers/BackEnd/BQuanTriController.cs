using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers.BackEnd
{
    public class BQuanTriController : Controller
    {
        // GET: BQuanTri
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}