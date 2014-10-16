using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingStore.BLL;
using System.Data;

namespace ShoppingStore.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult defaultpage()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult BigCategoryList()
        {
            IndexCommonDataBLL bll = new IndexCommonDataBLL();
            DataTable bigcategorytable = bll.GetFatherMenus();
            return PartialView("_MenuPartial", bigcategorytable);
        }
    }
}
