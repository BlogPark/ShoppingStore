using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingStore.Web.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult list(int id = 1, int tp = 1)
        {
            return View();
        }
    }
}
