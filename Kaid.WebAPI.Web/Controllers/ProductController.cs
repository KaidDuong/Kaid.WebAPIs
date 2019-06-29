using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kaid.WebAPI.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Category(int productId)
        {
            return View();
        }

        public ActionResult Detail(int productId)
        {
            return View();
        }
    }
}