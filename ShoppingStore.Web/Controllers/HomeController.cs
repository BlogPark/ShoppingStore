using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingStore.BLL;
using System.Data;
using ShoppingStore.Web.Models;

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
            MenuCategoriesPModel model = new MenuCategoriesPModel();
            IndexCommonDataBLL bll = new IndexCommonDataBLL();
            DataSet ds = bll.GetFatherMenus();
            model.bigcategory=ds.Tables[0];
            model.subcategory=ds.Tables[1];
            model.brandtable=ds.Tables[2];
            return PartialView("_MenuPartial",model);
        }
        public ActionResult PageNavList()
        {
            IndexCommonDataBLL bll = new IndexCommonDataBLL();
            DataTable dt = bll.GetPageNavlist();
            return PartialView("_PageNavPartial",dt);
        }
    }
}
