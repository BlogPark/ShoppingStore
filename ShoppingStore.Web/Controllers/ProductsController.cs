using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingStore.Web.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult itemdetail(int productid=1)
        {
            return View();
        }

    }
}
